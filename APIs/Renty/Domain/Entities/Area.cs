
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities{
public class Area
{
  [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]

  public int Id{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;
  [Required]
  [ForeignKey("CityId")]
  public int CityId{ get; set; }
  public City? City{ get; set; }
  public ICollection<User> Users=new HashSet<User>();
}}
