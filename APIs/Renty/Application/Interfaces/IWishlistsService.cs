using Renty.Application.DTOs;

namespace Renty.Application.Interfaces
{
public interface IWishlistsService
{
Task<WishlistDto?> GetByIdAsync(string? userId);
Task<bool> AddToListAsync(WishlistUpdateOrCreateDto listToAdd);
Task<bool> RemoveFromListAsync(WishlistUpdateOrCreateDto listToRemove);
Task<bool> DeleteAsync(string? userId);
}
}