
using AutoMapper;
using FluentValidation;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Domain.Models;

namespace Renty.Application.Services
{
public class ProductsService : IProductsService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Product> _productValidator;
    private readonly IMapper _mapper;
    

    public ProductsService(IUnitOfWork unitOfWork,IMapper mapper,  IValidator<Product> productValidator )
        {
            
        _unitOfWork = unitOfWork;
           _mapper = mapper;
        _productValidator = productValidator;
          
    }
    
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products =await _unitOfWork.ProductsRepository.GetAllAsync();

           return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDetailDto?> GetAllDetailsByIdAsync(int? id, string? userId)
    {
        var product =await _unitOfWork.ProductsRepository.GetAllDetailsByIdAsync(id,userId);
        if (product != null)
        {
             return _mapper.Map<ProductDetailDto>(product);
        }
        return null;
    }


    public async Task AddAsync(ProductAddDto productDTO)
    {

        var product = _mapper.Map<Product>(productDTO);
                    var validationResult = await _productValidator.ValidateAsync(product);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
                
       await _unitOfWork.ProductsRepository.AddAsync(product);
       await _unitOfWork.SaveChangesAsync();

    }

    public async Task<bool> UpdateAsync(ProductUpdateDto productDTO)
    {  
/*       var product = _unitOfWork.ProductsRepository.GetByIdAsync(productDTO.ID);
     var productToUpdate=  _mapper.Map<ProductUpdateDto>(product);
     var productUpdated=_mapper.Map<Product>(productToUpdate);*/

      var product = _mapper.Map<Product>(productDTO);
                           var validationResult = await _productValidator.ValidateAsync(product);//productUpdated);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
       await _unitOfWork.ProductsRepository.UpdateAsync(product);//productUpdated);
       await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product=await _unitOfWork.ProductsRepository.GetByIdAsync(id);
        if(product==null)
        {
            return false;
        }
       await _unitOfWork.ProductsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

/*   public async Task<List<GetAllPaginatedProductsDTO>> GetAllPaginatedAsync(int pageSize,int pageNumber)
    {
        var products=await unitOfWork.ProductsRepository.GetAllAsync();

         int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>products.Count-listStart)
      {
        pageSize=products.Count-listStart;
      }
        return products.Select(p=>new GetAllPaginatedProductsDTO
        {
            ID=p.ID,
            Name=p.Name,
            Price=p.Price.ToString(),
            Status=p.Status,
            AddingDate=p.AddingDate.ToString(),
            CategoryID=p.CategoryID,
            UserID=p.UserID
        }).ToList().GetRange(listStart,pageSize);
    }*/

    public async Task<List<ProductDto>> GetAllByNameAsync(string name)
    {
        var products=await _unitOfWork.ProductsRepository.GetAllByNameAsync(name);
        return _mapper.Map<List<ProductDto>>(products);
    }
        

    public async Task<List<ProductDto>> GetAllByUserIdAsync(string id)
    {
        var products=await _unitOfWork.ProductsRepository.GetAllByUserIdAsync(id);
          return _mapper.Map<List<ProductDto>>(products);
    }


    public async Task EditStatusAsync(int id, string status)
    {
        var product =await _unitOfWork.ProductsRepository.GetByIdAsync(id);
        if (product != null)
        {
            product.Status = status.Trim();
           await _unitOfWork.ProductsRepository.UpdateAsync(product);
           await _unitOfWork.SaveChangesAsync();
        }

    }

        public async Task<List<ProductDto>> GetAllFilteredsAsync(Filters filters)
        {
            var products=await _unitOfWork.ProductsRepository.GetAllFilteredsAsync(filters);
        return _mapper.Map<List<ProductDto>>(products);
        }
    }
}