using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    [Authorize(Policy = "UserPolicy")]
    public class WishlistsController : ODataController
    {
        const string pattern = "odata/Wishlists";
        private readonly IWishlistsService _WishlistService;

        public WishlistsController(IWishlistsService WishlistService)
        {
            _WishlistService = WishlistService;
        }


        [HttpGet(pattern + "/{userId}")]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            var Wishlist = await _WishlistService.GetByIdAsync(userId);
            return Ok(Wishlist);
        }

        [HttpPost(pattern)]
        public async Task<IActionResult> AddToList([FromBody] WishlistUpdateOrCreateDto wishlist)
        {
            var result = await _WishlistService.AddToListAsync(wishlist);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut(pattern)]
        public async Task<IActionResult> RemoveFromList([FromBody] WishlistUpdateOrCreateDto wishlist)
        {
            var result = await _WishlistService.RemoveFromListAsync(wishlist);
            if (!result)
            {
                return BadRequest();
            }
            return Updated(result);
        }

        [HttpDelete(pattern + "/{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            var Wishlist = await _WishlistService.GetByIdAsync(userId);
            if (Wishlist == null)
                return NotFound();

            await _WishlistService.DeleteAsync(userId);
            return NoContent();
        }
    }
}


/*

Get two Wishlists after skip the first two Wishlists {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
