using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface IRatingsService
{
        Task<List<RatingDto>> GetAllAsync();
    Task<RatingDto?> GetByIdAsync(int id);
    Task AddAsync(RatingAddDto ratingDTO);
    Task<bool> UpdateAsync(RatingUpdateDto ratingDTO);
    Task<bool> DeleteAsync(int id);   
    
            Task<List<RatingDto>> GetAllReportedCommentsAsync();
     Task<RatingDto?> GetSpecificAsync(string userId,int productId);
                Task<bool> ReportCommentAsync(int ratingId, bool status);
                Task<bool> RemoveCommentAsync(int ratingId);

}
}