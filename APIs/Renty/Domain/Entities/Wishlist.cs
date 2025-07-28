

namespace Renty.Domain.Entities
{
public class Wishlist
{
  public string? Id { get; set; }

 public ICollection<int> ProductIds{ get; set; }=new HashSet<int>();

}

}