﻿namespace Renty.Application.DTOs{

public class UserDto
{
          public string FirstName { get; set; }= string.Empty;
  public string LastName { get; set; }= string.Empty;
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

      public int Country { get; set; }
  public int City { get; set; }
  public int Area { get; set; }
   // public IList<string>? Roles { get; set; }
}
}
