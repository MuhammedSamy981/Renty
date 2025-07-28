using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class CitiesController : ODataController
    {
        const string pattern="odata/Cities";

    private readonly ICitiesService _Citieservice;



        public CitiesController(ICitiesService Citieservice)
        {
            _Citieservice = Citieservice;
        }


[HttpGet(pattern)]
        public async Task<List<CityDto>> GetAll()
        {
            var cities = await _Citieservice.GetAllAsync();
            return cities;
        }

[HttpGet(pattern+"/Country/{id}")]
        public async Task<List<CityDto>> GetAllByCountryId([FromRoute] int id)
        {
            var cities = await _Citieservice.GetAllByCountryIdAsync(id);
            return cities;
        }

[HttpGet(pattern+"/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var City = await _Citieservice.GetByIdAsync(id);
            if (City == null)
                return NotFound();
            return Ok(City);
        }

[Authorize(Policy = "ManagerPolicy")]
[HttpPost]
        public async Task<IActionResult> Post([FromBody] CityAddDto City)
        {
            await _Citieservice.AddAsync(City);
              return CreatedAtAction("GetById", new { id = City.Id }, City);
        }

[Authorize(Policy = "ManagerPolicy")]
[HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] CityUpdateDto City)
        {
            var result = await _Citieservice.UpdateAsync(City);
            if(!result)
        {
            return NotFound();
        }

            return Updated(result);
        }

[Authorize(Policy = "ManagerPolicy")]
        [HttpDelete(pattern + "/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var City = await _Citieservice.GetByIdAsync(id);
            if (City == null)
                return NotFound();

            await _Citieservice.DeleteAsync(id);
            return NoContent();
        }
    }
}


/*

Get two Cities after skip the first two Cities {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
