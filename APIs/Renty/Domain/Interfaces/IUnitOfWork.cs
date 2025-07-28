namespace Renty.Domain.Interfaces{
public interface IUnitOfWork
{


    public ICountriesRepository CountriesRepository { get; }

    public ICitiesRepository CitiesRepository { get; }

    public IAreasRepository AreasRepository { get; }

    public IRatingsRepository RatingsRepository { get; }

    public IProductsRepository ProductsRepository { get; }

    public ICategoriesRepository CategoriesRepository { get; }

    public IImagesRepository ImagesRepository { get; }
    public IWishlistsRepository WishlistsRepository { get; }

   // public IMailService MailService { get; }
    Task<int> SaveChangesAsync();

}
}