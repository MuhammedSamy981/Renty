
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities{
public class Country
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;
  public ICollection<City> Cities { get; set; } = new HashSet<City>();
  public ICollection<User> Users { get; set; } = new HashSet<User>();
}
}
