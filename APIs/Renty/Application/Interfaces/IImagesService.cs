using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface IImagesService
{
    Task<List<ImageDto>> GetAllAsync();
    Task<ImageDto?> GetByIdAsync(int id);
    Task AddAsync(ImageAddDto ImageDTO);
    Task<bool> UpdateAsync(ImageUpdateDto ImageDTO);
    Task<bool> DeleteAsync(int id);
    Task<List<ImageDto>> GetAllByProductIdAsync(int? id);

}
}