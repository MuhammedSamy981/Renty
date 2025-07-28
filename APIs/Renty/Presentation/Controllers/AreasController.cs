using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class AreasController : ODataController
    {
const string pattern="odata/Areas";
    private readonly IAreasService _Areaservice;


        public AreasController(IAreasService Areaservice)
        {
            _Areaservice = Areaservice;
        }

        [HttpGet(pattern)]
        public async Task<List<AreaDto>> GetAll()
        {
            var Areas = await _Areaservice.GetAllAsync();
            return Areas;
        }

        [HttpGet(pattern+"/City/{id}")]
        public async Task<List<AreaDto>> GetAllByCityId([FromRoute] int id)
        {
            var Areas = await _Areaservice.GetAllByCityIdAsync(id);
            return Areas;
        }

        [HttpGet(pattern+"/City{name}")]
        public async Task<List<AreaDto>> GetAllByCityName([FromRoute] string name)
        {
            var Areas = await _Areaservice.GetAllByCityNameAsync(name);
            return Areas;
        }

[HttpGet(pattern+"/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Area = await _Areaservice.GetByIdAsync(id);
            if (Area == null)
                return NotFound();
            return Ok(Area);
        }
        

[Authorize(Policy = "ManagerPolicy")]
[HttpPost]
        public async Task<IActionResult> Post([FromBody] AreaAddDto Area)
        {
            await _Areaservice.AddAsync(Area);
              return CreatedAtAction("GetById", new { id = Area.Id }, Area);
        }

[Authorize(Policy = "ManagerPolicy")]
        [HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] AreaUpdateDto Area)
        {
            var result = await _Areaservice.UpdateAsync(Area);
            if(!result)
        {
            return NotFound();
        }

            return Updated(result);
        }

[Authorize(Policy = "ManagerPolicy")]
[HttpDelete(pattern+"/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Area = await _Areaservice.GetByIdAsync(id);
            if (Area == null)
                return NotFound();

            await _Areaservice.DeleteAsync(id);
            return NoContent();
        }
    }
}


/*

Get two Areas after skip the first two Areas {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
