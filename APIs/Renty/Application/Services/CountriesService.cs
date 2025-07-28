using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{
public class CountriesService : ICountriesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountriesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }

    public async Task<List<CountryDto>> GetAllAsync()
    {
        var countries =await _unitOfWork.CountriesRepository.GetAllAsync();

           return _mapper.Map<List<CountryDto>>(countries);
    }

    public async Task<CountryDto?> GetByIdAsync(int Id)
    {
        var country =await _unitOfWork.CountriesRepository.GetByIdAsync(Id);
        if (country != null)
        {
             return _mapper.Map<CountryDto>(country);
        }
        return null;
    }



    public async Task AddAsync(CountryAddDto countryDTO)
    {

        var country = _mapper.Map<Country>(countryDTO);
       await _unitOfWork.CountriesRepository.AddAsync(country);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(CountryUpdateDto countryDTO)
    {
       var country = _mapper.Map<Country>(countryDTO);
       await _unitOfWork.CountriesRepository.UpdateAsync(country);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        var country=await _unitOfWork.CountriesRepository.GetByIdAsync(Id);
        if(country==null)
        {
            return false;
        }
       await _unitOfWork.CountriesRepository.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
}