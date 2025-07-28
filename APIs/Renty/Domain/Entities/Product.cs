
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renty.Domain.Entities
{
public class Product
{
  [Key]
  public int Id{ get; set; }

  [Required]
  [StringLength(30)]
  public string Name { get; set; }= string.Empty;

  [Required]
  [ForeignKey("CategoryId")]
  public int CategoryId{ get; set; }
  public Category? Category{ get; set; }

  [Required]
  public decimal Price { get; set; }

  [Required]
  public string Description { get; set; }= string.Empty;

  public DateTime AddingDate { get; set; }
  
    public string Status { get; set; }=string.Empty;
  public ICollection<Image> Images{ get; set; }=new HashSet<Image>();
  public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
    [Required]
  [ForeignKey("UserId")]
  public string? UserId { get; set; }

  public User? User { get; set; }

  
}
}