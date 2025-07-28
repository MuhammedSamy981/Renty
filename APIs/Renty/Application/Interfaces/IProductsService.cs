using Renty.Application.DTOs;
using Renty.Domain.Models;

namespace Renty.Application.Interfaces{
public interface IProductsService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<List<ProductDto>> GetAllFilteredsAsync(Filters filters);
    Task<ProductDetailDto?> GetAllDetailsByIdAsync(int? id, string? userId);
    Task AddAsync(ProductAddDto productDto);
    Task<bool> UpdateAsync(ProductUpdateDto productDto);
    Task<bool> DeleteAsync(int id);
    Task<List<ProductDto>> GetAllByNameAsync(string name);
    Task<List<ProductDto>> GetAllByUserIdAsync(string id);
    Task EditStatusAsync(int id, string status);
}
}