using System.Text.Json;
using Renty.Domain.Entities;
using Renty.Domain.Interfaces;
using StackExchange.Redis;

namespace Renty.Infrastructure.Repositories
{
public class WishlistsRepository : IWishlistsRepository
{
    private readonly IDatabase  _database;

       public WishlistsRepository(IConnectionMultiplexer muxer)
       {
           _database=muxer.GetDatabase();
       }


        public async Task<Wishlist?> GetByIdAsync(string? userId)
        {
           var wishlist= await _database.StringGetAsync(userId);
           return wishlist.IsNull ? null: JsonSerializer.Deserialize<Wishlist?>(wishlist);
        }


        public async Task<bool> AddToListAsync(Wishlist listToAdd)
        {
            var wishlist=await GetByIdAsync( listToAdd.Id);

            if(wishlist==null)
            {
               return await UpdateOrCreateAsync(listToAdd);
            }
            
            foreach (var productId in listToAdd.ProductIds)
            {
              wishlist.ProductIds.Add(productId);
            }
        
            return await UpdateOrCreateAsync(wishlist);
        }

           public async Task<bool> RemoveFromListAsync(Wishlist listToRemove)
        {
            var wishlist=await GetByIdAsync(listToRemove.Id);
            if(wishlist==null)
            {
               return await UpdateOrCreateAsync(listToRemove);
            }
            
            foreach (var productId in listToRemove.ProductIds)
            {
              wishlist.ProductIds.Remove(productId);
            }
        
            return await UpdateOrCreateAsync(wishlist);
        }

        public async Task<bool> DeleteAsync(string? userId)
        {
            return await _database.KeyDeleteAsync(userId);
        }

        private async Task<bool> UpdateOrCreateAsync(Wishlist wishlist)
        {
            var result= await _database.StringSetAsync(wishlist.Id,
            JsonSerializer.Serialize(wishlist),TimeSpan.FromDays(1));
            return result;
            //return !result ? null:await GetByIdAsync(wishlist.Id);
        }
    }
}