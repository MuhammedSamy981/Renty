using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class CountriesController : ODataController
    {
const string pattern="odata/Countries";
    private readonly ICountriesService _countrieservice;


        public CountriesController(ICountriesService countrieservice)
        {
            _countrieservice = countrieservice;
        }

[HttpGet(pattern)]  
        public async Task<List<CountryDto>> GetAll()
        {
            var countries = await _countrieservice.GetAllAsync();
            return countries;
        }

[HttpGet(pattern+"/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var country = await _countrieservice.GetByIdAsync(id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }


[Authorize(Policy = "ManagerPolicy")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryAddDto country)
        {
            await _countrieservice.AddAsync(country);
              return CreatedAtAction("GetById", new { id = country.Id }, country);
        }

[Authorize(Policy = "ManagerPolicy")]
[HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] CountryUpdateDto country)
        {
            var result = await _countrieservice.UpdateAsync(country);
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
            var country = await _countrieservice.GetByIdAsync(id);
            if (country == null)
                return NotFound();

            await _countrieservice.DeleteAsync(id);
            return NoContent();
        }
    }
}


/*

Get two Countries after skip the first two Countries {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
