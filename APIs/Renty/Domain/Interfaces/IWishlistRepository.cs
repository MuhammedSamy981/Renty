using Renty.Domain.Entities;

namespace Renty.Domain.Interfaces{
public interface IWishlistsRepository
{
      Task<Wishlist?> GetByIdAsync(string? userId);
Task<bool> AddToListAsync(Wishlist listToAdd);
Task<bool> RemoveFromListAsync(Wishlist listToRemove);
      Task<bool> DeleteAsync(string? userId);
}
}