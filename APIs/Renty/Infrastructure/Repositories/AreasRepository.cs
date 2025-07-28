using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class AreasRepository : GenericRepository<Area>,IAreasRepository
{      
      private readonly ApplicationDbContext _context;

        public AreasRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }

    public async Task<List<Area>> GetAllByCityIdAsync(int id)
    {
        return await _context.Set<Area>()
        .Where(a=>a.CityId==id).AsNoTracking().ToListAsync();
    }

    public async Task<List<Area>> GetAllByCityNameAsync(string name)
    {
           return await _context.Set<Area>()
        .Where(a=>a.City!.Name==name).AsNoTracking().ToListAsync();
    }
}
}