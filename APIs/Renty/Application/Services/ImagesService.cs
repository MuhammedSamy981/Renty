
using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{
public class ImagesService : IImagesService
{

            private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ImagesService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }

    public async Task<List<ImageDto>> GetAllAsync()
    {
        var images =await _unitOfWork.ImagesRepository.GetAllAsync();

           return _mapper.Map<List<ImageDto>>(images);
    }

    public async Task<ImageDto?> GetByIdAsync(int id)
    {
        var Image =await _unitOfWork.ImagesRepository.GetByIdAsync(id);
        if (Image != null)
        {
             return _mapper.Map<ImageDto>(Image);
        }
        return null;
    }


    public async Task AddAsync(ImageAddDto imageDTO)
    {

        var image = _mapper.Map<Image>(imageDTO);
       await _unitOfWork.ImagesRepository.AddAsync(image);
await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(ImageUpdateDto imageDTO)
    {
       var image = _mapper.Map<Image>(imageDTO);
       await _unitOfWork.ImagesRepository.UpdateAsync(image);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var image=await _unitOfWork.ImagesRepository.GetByIdAsync(id);
        if(image==null)
        {
            return false;
        }
       await _unitOfWork.ImagesRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }


            public async Task<List<ImageDto>> GetAllByProductIdAsync(int? id)
            {
                var images = await _unitOfWork.ImagesRepository.GetAllByProductIdAsync(id);
                return _mapper.Map<List<ImageDto>>(images);
            }




        //    public async Task<bool> DeleteAsync(int id)
        //    {
        //        var image = await unitOfWork.ImagesRepository.GetByIdAsync(id);
        //        if (image == null)
        //        {
        //            return false;
        //        }

        //        unitOfWork.ImagesRepository.DeleteById(id);
        //        await unitOfWork.SaveChangesAsync();
        //        return true;
        //    }


    }
}