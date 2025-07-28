using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{
    public class AreasService : IAreasService
    {
            private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AreasService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }

    public async Task<List<AreaDto>> GetAllAsync()
    {
        var areas =await _unitOfWork.AreasRepository.GetAllAsync();

           return _mapper.Map<List<AreaDto>>(areas);
    }

    public async Task<AreaDto?> GetByIdAsync(int id)
    {
        var area =await _unitOfWork.AreasRepository.GetByIdAsync(id);
        if (area != null)
        {
             return _mapper.Map<AreaDto>(area);
        }
        return null;
    }


    public async Task AddAsync(AreaAddDto areaDTO)
    {

        var area = _mapper.Map<Area>(areaDTO);
       await _unitOfWork.AreasRepository.AddAsync(area);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(AreaUpdateDto areaDTO)
    {
       var area = _mapper.Map<Area>(areaDTO);
       await _unitOfWork.AreasRepository.UpdateAsync(area);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var area=await _unitOfWork.AreasRepository.GetByIdAsync(id);
        if(area==null)
        {
            return false;
        }
       await _unitOfWork.AreasRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

        public async Task<List<AreaDto>> GetAllByCityIdAsync(int id)
        {
        var area =await _unitOfWork.AreasRepository.GetAllByCityIdAsync(id);
        if (area != null)
        {
             return _mapper.Map<List<AreaDto>>(area);
        }
        return null;
        }

        public async Task<List<AreaDto>> GetAllByCityNameAsync(string name)
        {
            var area =await _unitOfWork.AreasRepository.GetAllByCityNameAsync(name);
        if (area != null)
        {
             return _mapper.Map<List<AreaDto>>(area);
        }
        return null;
        }
    }
}