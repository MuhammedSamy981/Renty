using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data{
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var categories = new List<Category>
        {
new Category{Id=1,Name="Electrical Appliances"},
new Category{Id=2,Name="Clothes"},
new Category{Id=3,Name="Bags"},
new Category{Id=4,Name="Shoes"},
new Category{Id=5,Name="Books"},
new Category{Id=6,Name="Laptops"},
new Category{Id=7,Name="Mobiles & Tablets"},
new Category{Id=8,Name="Bikes & Motorcycles"},
new Category{Id=9,Name="Electronic Games"},
new Category{Id=10,Name="Kitchen Tools"},
new Category{Id=11,Name="Furniture & Decor"},
new Category{Id=12,Name="Sports Tools"},
new Category{Id=13,Name="Cameras"},
new Category{Id=14,Name="Cars & Trucks"},
new Category{Id=15,Name="Hunting Tools and Equipment"},
new Category{Id=16,Name="Medical Tools and Equipment"}
        };
        builder.HasData(categories);

        builder
        .HasMany(p=>p.Products).WithOne(s=>s.Category).OnDelete(DeleteBehavior.NoAction);
    }
}
}