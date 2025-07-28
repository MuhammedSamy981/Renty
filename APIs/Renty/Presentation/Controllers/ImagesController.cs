using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class ImagesController : ODataController
    {
const string pattern="odata/Images";
    private readonly IImagesService _Imageservice;


        public ImagesController(IImagesService Imageservice)
        {
            _Imageservice = Imageservice;
        }

[HttpGet(pattern+"/Product/{id}")]
        public async Task<List<ImageDto>> GetAllByProductId([FromRoute] int id)
        {
            var Images = await _Imageservice.GetAllByProductIdAsync(id);
            return Images;
        }

[HttpGet(pattern+"/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Image = await _Imageservice.GetByIdAsync(id);
            if (Image == null)
                return NotFound();
            return Ok(Image);
        }

[Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ImageAddDto imageAddDto)
        {
            await _Imageservice.AddAsync(imageAddDto);
            return Ok();
        }

[Authorize(Policy = "UserPolicy")]
        [HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] ImageUpdateDto imageUpdateDto)
        {
             await _Imageservice.UpdateAsync(imageUpdateDto);

            return Ok();
        }

/*[HttpPost(pattern+"/Add")]
        public async Task<IActionResult> Post([FromBody] ImageAddDto Image)
        {
            await _Imageservice.AddAsync(Image);
              return CreatedAtAction("Get", new { id = Image.ID }, Image);
        }

[HttpPut(pattern+"/Update")]
        public async Task<IActionResult> Put([FromBody] ImageUpdateDto Image)
        {
            var result = await _Imageservice.UpdateAsync(Image);
            if(!result)
        {
            return NotFound();
        }

            return Updated(result);
        }*/


/*        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Image = await _Imageservice.GetByIdAsync(id);
            if (Image == null)
                return NotFound();

            await _Imageservice.DeleteAsync(id);
            return NoContent();
        }*/
    }
}

