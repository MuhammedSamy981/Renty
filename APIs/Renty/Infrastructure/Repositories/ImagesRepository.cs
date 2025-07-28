using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class ImagesRepository : GenericRepository<Image>,IImagesRepository
{
    
    private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }


    public async Task<List<Image>> GetAllByProductIdAsync(int? id)
    {
        return await _context.Set<Image>().AsNoTracking().Where(p=>p.ProductId==id).ToListAsync();
    }
}
}