using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;

namespace Renty.Infrastructure.UnitOfWork{
public class UnitOfWork : IUnitOfWork
{
    public IProductsRepository ProductsRepository {get;}

    public ICategoriesRepository CategoriesRepository {get;}

    public IImagesRepository ImagesRepository {get;}

    public ICountriesRepository CountriesRepository {get;}

    public ICitiesRepository CitiesRepository {get;}

    public IAreasRepository AreasRepository {get;}

    public IRatingsRepository RatingsRepository {get;}
    public IWishlistsRepository WishlistsRepository {get;}

        private readonly ApplicationDbContext _context;
    public UnitOfWork
    (
     ApplicationDbContext context,
     IProductsRepository productsRepository,
     ICategoriesRepository categoriesRepository,
     IImagesRepository imagesRepository,
     ICountriesRepository countriesRepository,
     ICitiesRepository citiesRepository,
     IAreasRepository areasRepository,
     IRatingsRepository ratingsRepository,
     IWishlistsRepository wishlistsRepository)
    {
      _context = context;
      CountriesRepository = countriesRepository;
      CitiesRepository = citiesRepository;
      AreasRepository = areasRepository;
      RatingsRepository = ratingsRepository;
      ProductsRepository = productsRepository;
      CategoriesRepository = categoriesRepository;
      ImagesRepository = imagesRepository;
      WishlistsRepository = wishlistsRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
       return await _context.SaveChangesAsync();
    }
 
}
}