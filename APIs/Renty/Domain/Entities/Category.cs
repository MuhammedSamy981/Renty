
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities
{
public class Category
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int Id{ get; set; }

  [Required]
  public string Name { get; set; }= string.Empty;

  public ICollection<Product> Products{ get; set; }=new HashSet<Product>();

}
}
