using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;

namespace Renty.Infrastructure.Data{
public class ApplicationDbContext : IdentityDbContext<User>
{

           public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Product> Products { get; set; }  
 public DbSet<Image> Images { get; set; }
public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    
 

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

modelBuilder.Entity<User>()
        .HasMany(r=>r.Ratings).WithOne(u=>u.User).OnDelete(DeleteBehavior.NoAction);
        base.OnModelCreating(modelBuilder);
    }

}
}