using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data{
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        var countries=new List<Country>
        {
           new Country{Id=1,Name="EGYPT"}
        };
        builder.HasData(countries);

       builder.HasMany(u=>u.Users).WithOne(c=>c.Country).OnDelete(DeleteBehavior.NoAction);
    }
}
}
