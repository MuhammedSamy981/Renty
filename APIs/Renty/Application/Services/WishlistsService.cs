using AutoMapper;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;

namespace Renty.Application.Services
{

    public class WishlistsService : IWishlistsService
    {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WishlistsService(IUnitOfWork unitOfWork,IMapper mapper)
        {        
        _unitOfWork = unitOfWork;
           _mapper = mapper;
    }


        public async Task<WishlistDto?> GetByIdAsync(string? userId)
        {
          var wishlist =await _unitOfWork.WishlistsRepository.GetByIdAsync(userId);  
        if (wishlist != null)
        {
           var products= new List<Product>();
           
           foreach(var productId in wishlist!.ProductIds)
           {
             var product= await _unitOfWork.ProductsRepository.GetAllDetailsByIdAsync(productId,userId);
             if(product!=null)
             {
               products.Add(product);
             }
           }
            var wishlistWithProducts=new WishlistDto
          {
            Id=wishlist.Id,
            Products= _mapper.Map<List<ProductDto>>(products)
          };
             return wishlistWithProducts;
        }
        return null;
        }

        public async Task<bool> AddToListAsync(WishlistUpdateOrCreateDto listToAdd)
        {
                  var wishlist = _mapper.Map<Wishlist>(listToAdd);
               var result= await _unitOfWork.WishlistsRepository.AddToListAsync(wishlist);
        return result;
        }

        public async Task<bool> RemoveFromListAsync(WishlistUpdateOrCreateDto listToRemove)
        {
                var wishlist = _mapper.Map<Wishlist>(listToRemove);
                var result= await _unitOfWork.WishlistsRepository.RemoveFromListAsync(wishlist);
        return result;
        }

        public async Task<bool> DeleteAsync(string? userId)
        {
                    var wishlist=await _unitOfWork.WishlistsRepository.GetByIdAsync(userId);
        if(wishlist==null)
        {
            return false;
        }
       await _unitOfWork.WishlistsRepository.DeleteAsync(userId);
        return true;
        }
    }

}