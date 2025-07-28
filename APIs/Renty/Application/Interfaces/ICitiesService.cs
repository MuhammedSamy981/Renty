using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface ICitiesService
{
    Task<List<CityDto>> GetAllAsync();
    Task<CityDto?> GetByIdAsync(int id);
    Task AddAsync(CityAddDto cityDTO);
    Task<bool> UpdateAsync(CityUpdateDto cityDTO);
    Task<bool> DeleteAsync(int id);
    Task<List<CityDto>> GetAllByCountryIdAsync(int id);
}
}