using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface ICategoriesService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task AddAsync(CategoryAddDto categoryDTO);
    Task<bool> UpdateAsync(CategoryUpdateDto categoryDTO);
    Task<bool> DeleteAsync(int id);

    
}
}