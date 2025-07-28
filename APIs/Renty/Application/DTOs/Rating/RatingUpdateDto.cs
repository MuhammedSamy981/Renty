
namespace Renty.Application.DTOs{
public class RatingUpdateDto
{

  public int Id{ get; set; }
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public int productId{ get; set; }
   public string? UserId { get; set; }

}
}
