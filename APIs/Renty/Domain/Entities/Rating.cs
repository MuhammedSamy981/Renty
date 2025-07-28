
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities{
public class Rating
{
  [Key]
  public int Id{ get; set; }

  [Required]
  public int Value{ get; set; }

 
  public string Comment { get; set; }= string.Empty;

  [StringLength(100)]
  public string Datetime { get; set; }= string.Empty;
  
  public bool Report { get; set; }
  
  [Required]
  [ForeignKey("ProductId")]
  public int ProductId{ get; set; }
  public Product? Product{ get; set; }
  
  [Required]
  [ForeignKey("UserId")]
  public string? UserId { get; set; }
  public User? User{ get; set; }

}
}