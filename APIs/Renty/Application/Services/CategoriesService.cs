using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{
    public class CategoriesService : ICategoriesService
    {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories =await _unitOfWork.CategoriesRepository.GetAllAsync();

           return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category =await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
        if (category != null)
        {
             return _mapper.Map<CategoryDto>(category);
        }
        return null;
    }


    public async Task AddAsync(CategoryAddDto categoryDTO)
    {

        var category = _mapper.Map<Category>(categoryDTO);
       await _unitOfWork.CategoriesRepository.AddAsync(category);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto categoryDTO)
    {
       var category = _mapper.Map<Category>(categoryDTO);
       await _unitOfWork.CategoriesRepository.UpdateAsync(category);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category=await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
        if(category==null)
        {
            return false;
        }
       await _unitOfWork.CategoriesRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }


    }
}