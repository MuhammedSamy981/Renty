using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data{
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        var cities = new List<City>
         {
           new City{Id=1,Name="Cairo",CountryId=1},
new City{Id=2,Name="Giza",CountryId=1},
new City{Id=3,Name="Alexandria",CountryId=1},
new City{Id=4,Name="Dakahlia",CountryId=1},
new City{Id=5,Name="Red Sea",CountryId=1},
new City{Id=6,Name="Beheira",CountryId=1},
new City{Id=7,Name="Fayoum",CountryId=1},
new City{Id=8,Name="Gharbia",CountryId=1},
new City{Id=9,Name="Ismailia",CountryId=1},
new City{Id=10,Name="Monofia",CountryId=1},
new City{Id=11,Name="Minya",CountryId=1},
new City{Id=12,Name="Qalyubia",CountryId=1},
new City{Id=13,Name="New Valley",CountryId=1},
new City{Id=14,Name="Suez",CountryId=1},
new City{Id=15,Name="Aswan",CountryId=1},
new City{Id=16,Name="Assiut",CountryId=1},
new City{Id=17,Name="Beni Suef",CountryId=1},
new City{Id=18,Name="Port SaId",CountryId=1},
new City{Id=19,Name="Damietta",CountryId=1},
new City{Id=20,Name="Sharqia",CountryId=1},
new City{Id=21,Name="South Sinai",CountryId=1},
new City{Id=22,Name="Kafr El Sheikh",CountryId=1},
new City{Id=23,Name="Matrouh",CountryId=1},
new City{Id=24,Name="Luxor",CountryId=1},
new City{Id=25,Name="Qena",CountryId=1},
new City{Id=26,Name="North Sinai",CountryId=1},
new City{Id=27,Name="Sohag", CountryId=1}
        };
        builder.HasData(cities);

        builder.HasMany(u=>u.Users).WithOne(c=>c.City).OnDelete(DeleteBehavior.NoAction);
    }
}
}