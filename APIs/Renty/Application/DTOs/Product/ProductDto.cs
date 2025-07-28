namespace Renty.Application.DTOs{
public class ProductDto
{
  public int Id{ get; set; }
  public string Name { get; set; }= string.Empty;
  public string CategoryName { get; set; }= string.Empty;
  public decimal Price { get; set; }
  public string InterfaceImageUrl { get; set; }=string.Empty;
  public double OverallRating { get; set; }
  public int ClientsCount{ get; set; }
    public string Status { get; set; }=string.Empty;
  public DateTime AddingDate { get; set; }

}
}