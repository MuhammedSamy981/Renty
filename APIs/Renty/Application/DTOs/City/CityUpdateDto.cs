
using Renty.Domain.Entities;

namespace Renty.Application.DTOs{
public class CityUpdateDto
{
  public int Id{ get; set; }
  public string Name{ get; set; } = string.Empty;
  public int CountryId{ get; set; }
}
}