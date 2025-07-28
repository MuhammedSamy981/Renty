using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface IAreasService
{
    Task<List<AreaDto>> GetAllAsync();
    Task<AreaDto?> GetByIdAsync(int id);
    Task AddAsync(AreaAddDto areaDTO);
    Task<bool> UpdateAsync(AreaUpdateDto areaDTO);
    Task<bool> DeleteAsync(int id);
    Task<List<AreaDto>> GetAllByCityIdAsync(int id);
    Task<List<AreaDto>> GetAllByCityNameAsync(string name);

}
}