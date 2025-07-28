using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Renty.Domain.Entities{
public class User : IdentityUser
{
  
  
    [Required]
  [StringLength(15)]
  public string FirstName { get; set; }

    [Required]
  [StringLength(15)]
  public string LastName { get; set; }

  [Required]
  [ForeignKey("CountryId")]
  public int CountryId { get; set; }


  public Country? Country { get; set; }

  [Required]
  [ForeignKey("CityId")]
  public int CityId { get; set; }
  public City? City { get; set; }

  [Required]
  [ForeignKey("AreaId")]
  public int AreaId { get; set; }
  public Area? Area { get; set; }

  public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
   public ICollection<Product> Products { get; set; } = new HashSet<Product>();
  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
}
}