
using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{
public class RatingsService : IRatingsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RatingsService(IUnitOfWork unitOfWork,IMapper mapper)
        {
         
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }
    
    public async Task<List<RatingDto>> GetAllAsync()
    {
        var ratings =await _unitOfWork.RatingsRepository.GetAllAsync();

           return _mapper.Map<List<RatingDto>>(ratings);
    }

    public async Task<RatingDto?> GetByIdAsync(int id)
    {
        var rating =await _unitOfWork.RatingsRepository.GetByIdAsync(id);
        if (rating != null)
        {
             return _mapper.Map<RatingDto>(rating);
        }
        return null;
    }


    public async Task AddAsync(RatingAddDto ratingDTO)
    {

        var rating = _mapper.Map<Rating>(ratingDTO);
       await _unitOfWork.RatingsRepository.AddAsync(rating);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(RatingUpdateDto ratingDTO)
    {
       var rating = _mapper.Map<Rating>(ratingDTO);
       await _unitOfWork.RatingsRepository.UpdateAsync(rating);
      await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var rating=await _unitOfWork.RatingsRepository.GetByIdAsync(id);
        if(rating==null)
        {
            return false;
        }
       await _unitOfWork.RatingsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

public async Task<RatingDto?> GetSpecificAsync(string userId,int productId)
{
        var rating =await _unitOfWork.RatingsRepository.GetSpecificAsync(userId,productId);
        if (rating != null)
        {
             return _mapper.Map<RatingDto>(rating);
        }
        return null;
}

    public async Task<bool> ReportCommentAsync(int ratingId,bool status)
    {
        var rating = await _unitOfWork.RatingsRepository.GetByIdAsync(ratingId);
        if(rating==null)
        {
            return false;
        }
        rating.Report = status;
         await _unitOfWork.RatingsRepository.UpdateAsync(rating);
         await _unitOfWork.SaveChangesAsync();
         return true;
    }

        public async Task<List<RatingDto>> GetAllReportedCommentsAsync()
        {
                 var ratings =await _unitOfWork.RatingsRepository.GetAllReportedCommentsAsync();

           return _mapper.Map<List<RatingDto>>(ratings);
        }

            public async Task<bool> RemoveCommentAsync(int ratingId)
    {
        var rating = await _unitOfWork.RatingsRepository.GetByIdAsync(ratingId);
        if(rating==null)
        {
            return false;
        }
        rating.Comment = "This comment has been removed";
        //"This comment has been removed because it violates the website's rules";
         await _unitOfWork.RatingsRepository.UpdateAsync(rating);
         await _unitOfWork.SaveChangesAsync();
         return true;
    }
    }
}