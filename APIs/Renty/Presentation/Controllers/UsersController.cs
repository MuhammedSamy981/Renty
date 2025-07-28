using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Renty.Application.DTOs;
using Renty.Application.Services;
using Renty.Domain.Entities;
using Renty.Domain.Models;


public class UsersController : ODataController
{
    const string pattern="odata/Users";
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly CourierEmailService _courieremailService;


    public UsersController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        CourierEmailService courieremailService,
        IConfiguration configuration)
    {
        _courieremailService = courieremailService;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

/*    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(Message message)
    {
        var result = await _courieremailService.SendAsync(message);
        return result ? Ok("Email sent.") : StatusCode(500, "Failed to send email.");
    }*/


    [Authorize(Policy = "UserPolicy")]
    [HttpGet(pattern+"/CurrentUserInfo")]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        var userContext=HttpContext.User;

        if (userContext.Identity?.IsAuthenticated != true)
        {
            return Unauthorized();
        }

        var userId = userContext.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        var user = await _userManager.FindByIdAsync(userId!);
        if (user == null) return NotFound();

        var roles = await _userManager.GetRolesAsync(user);

        return Ok(new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName!,
            LastName = user.LastName!,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber!,
            Country = user.CountryId,
            City = user.CityId,
            Area = user.AreaId,

        });
    }



    [HttpPost(pattern+"/Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var user = new User
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CountryId = model.CountryId,
            CityId = model.CityId,
            AreaId = model.AreaId
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User"); // Assign default role
            return Ok(new { Message = "User registered successfully!" });
        }

        return BadRequest(result.Errors);
    }

    [EnableRateLimiting("AuthLimit")]
    [HttpPost(pattern+"/Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var refreshToken = GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    AccessToken = GenerateJwtToken(user, roles),
                    RefreshToken = refreshToken
                });
            }
        }

        return Unauthorized();
    }


    [Authorize(Policy = "UserPolicy")]
    [HttpPut(pattern+"/AccountUpdate")]
    public async Task<IActionResult> UpdateAccount([FromBody] AccountUpdateDto account)
    {
        var user = await _userManager.FindByIdAsync(account.Id);
        if (user == null)
        {
            return BadRequest();
        }

        user.UserName = account.Email;
        user.Email = account.Email;
        user.FirstName = account.FirstName;
        user.LastName = account.LastName;
        user.PhoneNumber = account.PhoneNumber;
        user.CountryId = account.CountryId;
        user.CityId = account.CityId;
        user.AreaId = account.AreaId;

        var result = await _userManager.UpdateAsync(user);
        if (result == null)
        {
            return NotFound();
        }

        return Updated(result);
    }

[Authorize(Policy = "ManagerPolicy")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        await _userManager.DeleteAsync(user);
        return NoContent();
    }


    private string GenerateJwtToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, roles.First()),
            new Claim(JwtRegisteredClaimNames.Aud,user.PhoneNumber!),
            //new Claim(JwtRegisteredClaimNames.Aud, String.Join(",",roles.ToArray())),
            new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
            //new Claim(ClaimTypes.Email,user.Email!),
            new Claim(ClaimTypes.Role,roles.First())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]));

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    [HttpPost(pattern+"/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenModel)
    {
        var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
        if (principal == null)
            return BadRequest("Invalid access token");

        var userId = principal.FindFirstValue(JwtRegisteredClaimNames.Jti);
        var user = await _userManager.FindByIdAsync(userId!);


        if (user == null || user.RefreshToken != tokenModel.RefreshToken
        || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return BadRequest("Invalid refresh token");

        // Generate new JWT
        var roles = await _userManager.GetRolesAsync(user);
        var newJwtToken = GenerateJwtToken(user, roles);
        var newRefreshToken = GenerateRefreshToken();

        // Update refresh token in DB
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return Ok(new
        {
            AccessToken = newJwtToken,
            RefreshToken = newRefreshToken
        });
    }


    private string GenerateRefreshToken()
    {
        /*var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);*/
        var randomBytes = RandomNumberGenerator.GetBytes(64);
        return Convert.ToBase64String(randomBytes);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false // We check expiry manually
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        return principal;
    }



    [HttpPost(pattern+"/forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return Ok(); // Don't reveal if user exists (security best practice)

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = $"http://localhost:4200/user/reset-password?email={user.Email}&token={token}";
        Console.WriteLine("\n\n" + resetLink + "\n\n");

        var message = new Message
        {
            Email = model.Email,
            Template = "GWFF9E7QMA47T2K3WCRHX5BY6RDC",
            Link = resetLink
        };

        await _courieremailService.SendAsync(message);

        return Ok(new { Message = "Password reset link sent to email." });
    }


    [HttpPost(pattern + "/reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) return BadRequest("Invalid request.");

        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        if (result.Succeeded)
            return Ok(new { Message = "Password reset successfully!" });

        return BadRequest(result.Errors);
    }
    
    /*
        public void SendEmailViaOutlookSMTP()
       {
           try
           {
               // Outlook SMTP server settings
               string smtpServer = "smtp-mail.outlook.com"; // For Outlook.com/Hotmail accounts
               // Alternative for Office 365: "smtp.office365.com"
               int port = 587; // Outlook SMTP port (587 for TLS)

               // Your Outlook email credentials
               string fromEmail = "MohamedSamy981226@outlook.com";
               string password = "MOHAMEDsamy981034347749";

               // Recipient
               string toEmail = "mohamed981226@gmail.com";

               // Create SMTP client
               using (SmtpClient client = new SmtpClient(smtpServer, port))
               {
                   client.EnableSsl = true; // Outlook requires SSL
                   client.DeliveryMethod = SmtpDeliveryMethod.Network;
                   client.UseDefaultCredentials = false;
                   client.Credentials = new NetworkCredential(fromEmail, password);

                   // Create mail message
                   using (MailMessage mail = new MailMessage(fromEmail, toEmail))
                   {
                       mail.Subject = "Test Email via Outlook SMTP";
                       mail.Body = "This email was sent using Outlook's SMTP server in C#.";
                       mail.IsBodyHtml = false; // Set to true for HTML emails

                       // Optional: Add attachments
                       // mail.Attachments.Add(new Attachment(@"C:\path\to\file.txt"));

                       // Send email
                       client.Send(mail);
                       Console.WriteLine("Email sent successfully via Outlook SMTP!");
                   }
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error sending email: {ex.Message}");
           }
       }
    */




    [EnableRateLimiting("AuthLimit")]
    [HttpPost(pattern + "/SocialLogin")]
    public async Task<IActionResult> LoginSocial([FromBody] SocialLoginDto model)
    {
        if (model == null) return BadRequest();

        // Create or get user
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {

            user = new User
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CountryId = model.CountryId,
                CityId = model.CityId,
                AreaId = model.AreaId
            };
            string password = model.FirstName + Guid.NewGuid().ToString() + model.LastName;
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        var roles = await _userManager.GetRolesAsync(user);
        var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new
            {
                AccessToken = GenerateJwtToken(user, roles),
                RefreshToken = refreshToken
            });

    }

}
