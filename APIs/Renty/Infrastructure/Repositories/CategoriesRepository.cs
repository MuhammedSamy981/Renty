using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class CategoriesRepository : GenericRepository<Category>,ICategoriesRepository
{
    private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }


    }
}