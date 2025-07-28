using System.Security.Claims;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Renty.Application.Interfaces;
using Renty.Application.Mappings;
using Renty.Application.Services;
using Renty.Application.Validators;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;
using Renty.Infrastructure.Repositories;
using Renty.Infrastructure.UnitOfWork;
using Renty.Presentation.Middlewares;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
const string allowAllPolicy="AllowAllPolicy";


#region Identity

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    }
    )
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);
#endregion


#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
    };
});

#endregion


#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerPolicy",
        p => p.RequireClaim(ClaimTypes.Role, "Manager"));
    options.AddPolicy("AdminPolicy",
        p => p.RequireClaim(ClaimTypes.Role, "Admin","Manager"));
    options.AddPolicy("UserPolicy",
        p => p.RequireClaim(ClaimTypes.Role, "User"));
});

#endregion


#region Database

string? connectionString = builder.Configuration.GetConnectionString("Renty");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

#endregion


#region Redis-cloud
var configurationOptions= new ConfigurationOptions
            {
                EndPoints = { {builder.Configuration["Redis:EndPoints:Url"]!
                ,int.Parse(builder.Configuration["Redis:EndPoints:Port"]!)} },
                User =  builder.Configuration["Redis:User"],
                Password = builder.Configuration["Redis:Password"],
                AbortOnConnectFail=false
            };
builder.Services.AddSingleton<IConnectionMultiplexer>(con=>
     ConnectionMultiplexer.Connect(configurationOptions)
);
#endregion

#region Repositories
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IAreasRepository, AreasRepository>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddScoped<IRatingsRepository, RatingsRepository>();
builder.Services.AddScoped<IWishlistsRepository, WishlistsRepository>();
#endregion

#region Unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region App Services
builder.Services.AddScoped<IProductsService,ProductsService>();
builder.Services.AddScoped<ICategoriesService,CategoriesService>();
builder.Services.AddScoped<ICountriesService,CountriesService>();
builder.Services.AddScoped<ICitiesService,CitiesService>();
builder.Services.AddScoped<IAreasService,AreasService>();
builder.Services.AddScoped<IImagesService,ImagesService>();
builder.Services.AddScoped<IRatingsService,RatingsService>();
builder.Services.AddScoped<IWishlistsService,WishlistsService>();
#endregion

#region Courier Service
builder.Services.AddHttpClient<CourierEmailService>();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

#region FluentValidation
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
#endregion

#region RateLimiter
// Fixed window rate limiting (e.g., 5 requests per minute for auth endpoints)
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("AuthLimit", opt =>
    {
        opt.Window = TimeSpan.FromMinutes(1);
        opt.PermitLimit = 5;
        opt.QueueLimit = 0; // Reject excess requests immediately
    });
});

#endregion

#region Cors
builder.Services.AddCors(options=>
{
  options.AddPolicy(allowAllPolicy,builder=>
  {
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
  });
});
#endregion

#region OData
var modelBuilder = new ODataConventionModelBuilder();
var userEntityType=modelBuilder.EntitySet<User>("Users").EntityType;
var productEntityType=modelBuilder.EntitySet<Product>("Products").EntityType;
var categoryEntityType=modelBuilder.EntitySet<Category>("Categories").EntityType;
var countryEntityType=modelBuilder.EntitySet<Country>("Countries").EntityType;
var cityEntityType=modelBuilder.EntitySet<City>("Cities").EntityType;
var areaEntityType=modelBuilder.EntitySet<Area>("Areas").EntityType;
var imageEntityType=modelBuilder.EntitySet<Image>("Images").EntityType;
var ratingEntityType=modelBuilder.EntitySet<Rating>("Ratings").EntityType;
var wishlisEntityType=modelBuilder.EntitySet<Wishlist>("Wishlists").EntityType;
var edmModel = modelBuilder.GetEdmModel();


builder.Services.AddControllers().AddOData(
    options => options.EnableQueryFeatures(maxTopValue:100)
    .SkipToken()
    .AddRouteComponents(routePrefix: "odata", model:edmModel
    //This configuration to create a secure paging
    ,configureServices: services =>{
        //services.AddSingleton<SkipTokenHandler, CustomSkipTokenHandler>();
    }));
#endregion

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Secure API", Version = "v1" });
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRateLimiter();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuditLogMiddleware>();
app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseCors(allowAllPolicy);
app.MapControllers();


#region Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var context = services.GetRequiredService<ApplicationDbContext>();
        await ApplicationDbHelper.SeedDataAsync(userManager,roleManager, context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
#endregion

app.Run();
