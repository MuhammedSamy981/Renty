using Microsoft.EntityFrameworkCore;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
    public class RatingsRepository : GenericRepository<Rating>, IRatingsRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Rating>> GetAllReportedCommentsAsync()
        {

            return await _context.Set<Rating>().Include(r => r.User).AsNoTracking()
            .Where(r => r.Report == true && r.Comment != "This comment has been removed").ToListAsync();
        }


        public async Task<List<Rating>> GetAllByUserId(string userId)
        {
            var user = await _context.Set<Rating>().AsNoTracking().Where(r => r.UserId == userId).ToListAsync();
            return user;
        }

        public async Task<Rating?> GetSpecificAsync(string userId, int productId)
        {
            var rating = await _context.Set<Rating>().Include(r => r.User).FirstOrDefaultAsync(r => r.UserId == userId
            && r.ProductId == productId);
            return rating;
        }  
    
}
}