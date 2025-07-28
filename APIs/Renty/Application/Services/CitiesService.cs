using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{

    public class CitiesService : ICitiesService
    {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CitiesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }

    public async Task<List<CityDto>> GetAllAsync()
    {
        var cities =await _unitOfWork.CitiesRepository.GetAllAsync();

           return _mapper.Map<List<CityDto>>(cities);
    }

    public async Task<CityDto?> GetByIdAsync(int id)
    {
        var city =await _unitOfWork.CitiesRepository.GetByIdAsync(id);
        if (city != null)
        {
             return _mapper.Map<CityDto>(city);
        }
        return null;
    }


    public async Task AddAsync(CityAddDto cityDTO)
    {

        var city = _mapper.Map<City>(cityDTO);
       await _unitOfWork.CitiesRepository.AddAsync(city);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(CityUpdateDto cityDTO)
    {
       var city = _mapper.Map<City>(cityDTO);
       await _unitOfWork.CitiesRepository.UpdateAsync(city);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var city=await _unitOfWork.CitiesRepository.GetByIdAsync(id);
        if(city==null)
        {
            return false;
        }
       await _unitOfWork.CitiesRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

        public async Task<List<CityDto>> GetAllByCountryIdAsync(int id)
        {
        var city =await _unitOfWork.CitiesRepository.GetAllByCountryIdAsync(id);
        if (city != null)
        {
             return _mapper.Map<List<CityDto>>(city);
        }
        return null;
        }

    }

}