
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities{
public class City
{
  [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]

  public int Id{ get; set; }

  [Required]
  public string Name{ get; set; } = string.Empty;

  [Required]
  [ForeignKey("CountryId")]
  public int CountryId{ get; set; }
  public Country? Country{ get; set; }
  public ICollection<Area> Areas { get; set; }= new HashSet<Area>();
  public ICollection<User> Users { get; set; }= new HashSet<User>();
}
}
