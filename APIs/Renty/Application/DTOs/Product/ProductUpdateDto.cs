
namespace Renty.Application.DTOs{
public class ProductUpdateDto
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int CategoryId{ get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }= string.Empty;
  public string? UserId{ get; set; }

}
}