
namespace Renty.Application.DTOs{
public class RatingAddDto
{
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public int ProductId{ get; set; }
   public string UserId { get; set; }
}
}
