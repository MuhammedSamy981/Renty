using Renty.Domain.Entities;
using Renty.Domain.Models;

namespace Renty.Domain.Interfaces{
public interface IProductsRepository:IGenericRepository<Product>
{
     new Task<List<Product>> GetAllAsync();
     Task<List<Product>> GetAllByNameAsync(string name);
     Task<List<Product>> GetAllFilteredsAsync(Filters filters);           
     Task<Product?> GetAllDetailsByIdAsync(int? Id,string? userId);
     Task<List<Product>> GetAllByUserIdAsync(string id);
}
}