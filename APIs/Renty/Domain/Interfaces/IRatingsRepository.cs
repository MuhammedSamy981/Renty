using Renty.Domain.Entities;

namespace Renty.Domain.Interfaces{
public interface IRatingsRepository:IGenericRepository<Rating>
{
   Task<List<Rating>> GetAllReportedCommentsAsync();
   Task<List<Rating>> GetAllByUserId(string userId);
   Task<Rating?> GetSpecificAsync(string userId,int productId);
}
}