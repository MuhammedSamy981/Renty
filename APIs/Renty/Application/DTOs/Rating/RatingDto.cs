
namespace Renty.Application.DTOs{
public class RatingDto
{

  public int Id{ get; set; }
  public string FullName{ get; set; }= string.Empty;
  public int Value{ get; set; }
  public string Comment { get; set; }= string.Empty;
  public string Datetime { get; set; }= string.Empty;
  public int ProductId{ get; set; }
  public string? UserId { get; set; }

}
}
