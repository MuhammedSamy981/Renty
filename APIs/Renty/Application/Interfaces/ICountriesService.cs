using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{

public interface ICountriesService
{
    Task<List<CountryDto>> GetAllAsync();
    Task<CountryDto?> GetByIdAsync(int id);
    Task AddAsync(CountryAddDto countryDTO);
    Task<bool> UpdateAsync(CountryUpdateDto countryDTO);
    Task<bool> DeleteAsync(int id);
}
}