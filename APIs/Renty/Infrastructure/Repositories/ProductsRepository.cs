
using Microsoft.EntityFrameworkCore;
using Renty.Application.DTOs;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using Renty.Domain.Models;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.Repositories
{
public class ProductsRepository : GenericRepository<Product>,IProductsRepository
{
        private readonly ApplicationDbContext _context;

        public ProductsRepository(ApplicationDbContext context): base(context)
       {
           _context = context;
       }

   public async new Task<List<Product>> GetAllAsync()
    {
        return await  _context.Set<Product>().Include(p => p.Category).AsSplitQuery()
        .Include(p=>p.Ratings).AsSplitQuery().AsNoTracking().ToListAsync();
    }
    public async Task<List<Product>> GetAllByNameAsync(string name)
    {   
      var products=await _context.Set<Product>().Include(p=>p.Category)
      .Where(p=>p.Name.Contains(name.Trim()))
      .OrderByDescending(p=>p.Id).AsNoTracking().ToListAsync();
         return products;
    }
    public async Task<List<Product>> GetAllFilteredsAsync(Filters filters)
    {
                            
      var products= (filters.ProductName!="" && filters.ProductName!=null) ?
      _context.Set<Product>().Where(p=>p.Name.Contains(filters.ProductName)):
      _context.Set<Product>();
       
/*    var filterdProducts=(filters.CountryId == 0 && filters.CategoryId == 0) ? 
                    products: 
                    (filters.CityId == 0 && filters.CountryId != 0 && filters.CategoryId == 0) ?  
                    products.Where(p=>p.CountryId==filters.CountryId):
                    (filters.CityId  == 0 && filters.CountryId != 0 && filters.CategoryId != 0) ?
                    products.Where(p=>p.CategoryId==filters.CategoryId &&p.CountryId==filters.CountryId):
                    (filters.AreaId == 0 && filters.CityId  != 0 && filters.CountryId != 0 && filters.CategoryId == 0) ?
                    products.Where(p=>p.CountryId==filters.CountryId && p.CityId ==filters.CityId ) :
                    (filters.AreaId == 0 && filters.CityId  != 0 && filters.CountryId != 0 && filters.CategoryId != 0) ? 
                    products.Where(p=>p.CategoryId==filters.CategoryId &&p.CountryId==filters.CountryId&&p.CityId ==filters.CityId ) :
                    products.Where(p=>p.CategoryId==filters.CategoryId && p.CountryId==filters.CountryId
                    && p.CityId ==filters.CityId  && p.AreaId==filters.AreaId);*/

 var filterdProducts=(filters.AreaId == 0 && filters.CategoryId == 0) ?
                    products :
                    (filters.AreaId == 0 && filters.CategoryId != 0) ? 
                    products.Where(p=>p.CategoryId==filters.CategoryId) :
                    (filters.AreaId != 0 && filters.CategoryId == 0) ? 
                    products.Where(p=>p.User!.AreaId==filters.AreaId) :
                    products.Include(p=>p.User).ThenInclude(u=>u.Area)
                    .Where(p=>p.CategoryId==filters.CategoryId && p.User!.AreaId==filters.AreaId);

        return await filterdProducts.Where(p=>p.Status=="accepted")
        .Include(p=>p.Category).AsSplitQuery().Include(p=>p.Images).AsSplitQuery().Include(p=>p.Ratings)
        .OrderByDescending(s=>s.Ratings.Select(r=>r.Value).Average()).AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetAllDetailsByIdAsync(int? Id,string? userId)
    {
         return await _context.Set<Product>().Include(p => p.Category)
         .Include(p => p.Images).Include(p => p.User)
         .Include(p => p.Ratings).ThenInclude(r => r.User)
         .Include(p => p.User).ThenInclude(u => u.Country)
         .Include(p => p.User).ThenInclude(u => u.City)
         .Include(p => p.User).ThenInclude(u => u.Area)
         .Where(p=>p.Status=="accepted" || p.UserId==userId)
         .FirstOrDefaultAsync(p=>p.Id==Id);
    }

    public async Task<List<Product>> GetAllByUserIdAsync(string Id)
    {
        var user= await _context.Set<Product>().Include(p=>p.Category).Where(p=>p.UserId==Id).AsNoTracking().ToListAsync();
        return user;
    }
}
}