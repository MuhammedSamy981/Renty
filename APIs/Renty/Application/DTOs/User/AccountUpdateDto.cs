namespace Renty.Application.DTOs{

public class AccountUpdateDto
{
      public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; }= string.Empty;
  public string LastName { get; set; }= string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

         public int CountryId { get; set; }
  public int CityId { get; set; }
  public int AreaId { get; set; }
}
}
