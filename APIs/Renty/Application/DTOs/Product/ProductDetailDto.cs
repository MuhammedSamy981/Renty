namespace Renty.Application.DTOs
{

  public class ProductDetailDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public CategoryDto? Category { get; set; }
    public List<ImageDto>? Images { get; set; }
    public List<RatingDto>? Ratings { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public UserDetailDto? User { get; set; }
    public DateTime AddingDate { get; set; }
  }

}