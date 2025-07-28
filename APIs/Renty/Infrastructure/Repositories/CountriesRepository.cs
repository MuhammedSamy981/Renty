using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class CountriesRepository : GenericRepository<Country>,ICountriesRepository
{
      private readonly ApplicationDbContext _context;

        public CountriesRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }

}
}