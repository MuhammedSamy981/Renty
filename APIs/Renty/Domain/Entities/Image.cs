using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities
{
public class Image
{
  [Key]
  public int Id{ get; set; }

  [Required]
  public string Url { get; set; }= string.Empty;

  [Required]
  [ForeignKey("ProductId")]
  public int ProductId{ get; set; }
  public Product? Product{ get; set; }

}

}
