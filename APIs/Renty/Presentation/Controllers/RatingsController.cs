using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class RatingsController : ODataController
    {
        const string pattern="odata/Ratings";
        private readonly IRatingsService _Ratingservice;


        public RatingsController(IRatingsService Ratingservice)
        {
            _Ratingservice = Ratingservice;
        }


        [HttpGet]
        public async Task<List<RatingDto>> GetAll()
        {
            var Ratings = await _Ratingservice.GetAllAsync();
            return Ratings;
        }

        [HttpGet(pattern+"/Comments")]
        public async Task<List<RatingDto>> GetAllReportedCommentsAsync()
        {
            var ratings = await _Ratingservice.GetAllReportedCommentsAsync();

            return ratings;
        }

        [HttpGet(pattern+"/{userId},{productId}")]
        public async Task<IActionResult> GetSpecificAsync([FromRoute] string userId, [FromRoute] int productId)
        {
            var Rating = await _Ratingservice.GetSpecificAsync(userId, productId);
            if (Rating == null)
                return NotFound();
            return Ok(Rating);
        }


[Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RatingAddDto Rating)
        {
            await _Ratingservice.AddAsync(Rating);
            return Ok(Rating);
        }

[Authorize(Policy = "UserPolicy")]
        [HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] RatingUpdateDto Rating)
        {
            var result = await _Ratingservice.UpdateAsync(Rating);
            if (!result)
            {
                return NotFound();
            }

            return Updated(result);
        }
        
[Authorize(Policy = "UserPolicy")]
    [HttpPut(pattern + "/Report/{ratingId},{status}")]
    public async Task<IActionResult> ReportCommentAsync(int ratingId,bool status)
    {
            var result = await _Ratingservice.ReportCommentAsync(ratingId,status);
            if(!result)
        {
            return NotFound();
        }

            return Ok(result);
    }

        [Authorize(Policy = "AdminPolicy")]
         [HttpPut(pattern+"/CommentRemove/{ratingId}")]
    public async Task<IActionResult> RemoveCommentAsync(int ratingId)
    {
        var result = await _Ratingservice.RemoveCommentAsync(ratingId);
             if(!result)
        {
            return NotFound();
        }

            return Ok(result);
    }

[Authorize(Policy = "UserPolicy")]
        [HttpDelete(pattern + "/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Rating = await _Ratingservice.GetByIdAsync(id);
            if (Rating == null)
                return NotFound();

            await _Ratingservice.DeleteAsync(id);
            return NoContent();
        }
    }
}




/*

Get two Ratings after skip the first two Ratings {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
