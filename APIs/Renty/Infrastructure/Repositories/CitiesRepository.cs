
using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class CitiesRepository : GenericRepository<City>,ICitiesRepository
{
      private readonly ApplicationDbContext _context;

        public CitiesRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }

    public async Task<List<City>> GetAllByCountryIdAsync(int id)
    {
        return await _context.Set<City>()
        .Where(s=>s.CountryId==id).AsNoTracking().ToListAsync();
    }
}
}