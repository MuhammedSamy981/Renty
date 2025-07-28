using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;

namespace Renty.Presentation.WebApi.Controllers
{
    public class CategoriesController : ODataController
    {
const string pattern="odata/Categories";
        private readonly ICategoriesService _Categorieservice;



        public CategoriesController(ICategoriesService Categorieservice)
        {
            _Categorieservice = Categorieservice;
        }

        #region Query Options

        //Get all Categories names (GET):
        //GET http://localhost:5003/odata/Categories?$select=Name

        //Get all Categories with their related orders (GET):
        //GET http://localhost:5003/odata/Categories?$expand=Orders

        //Order the Categories by Name in ascending order
        //http://localhost:5003/odata/Categories?$orderby=Name 

        //Order the Categories by Name in descending order
        //http://localhost:5003/odata/Categories?$orderby=Name%20desc

        //Get Category with ID = 1 :
        //GET http://localhost:5003/odata/Customers?$filter=Id%20eq%201

        //Get Category with max price :
        //GET http://localhost:5003/odata/Customers?$apply=aggregate(Price%20with%20max%20as%20MaxPrice)

        //Get two Categories after skip the first two Categories :
        //GET http://localhost:5000/Categories?$top=2&$skip=2

        /*Select only the Name property from Categories entity.
        Filter the Orders and return only the ones whose Id is greater than 1.
        Order the Categories by Name in descending order*/
        //http://localhost:5003/odata/Categories?$select=Name&$filter=Id%20gt%201&$orderby=Name%20desc

        #endregion

 [HttpGet(pattern)]  
        public async Task<List<CategoryDto>> GetAll()
        {
            var Categories = await _Categorieservice.GetAllAsync();
            return Categories;
        }

[HttpGet(pattern+"/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Category = await _Categorieservice.GetByIdAsync(id);
            if (Category == null)
                return NotFound();
            return Ok(Category);
        }

[Authorize(Policy = "ManagerPolicy")]
[HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryAddDto Category)
        {
            await _Categorieservice.AddAsync(Category);
              return CreatedAtAction("GetById", new { id = Category.Id }, Category);
        }
[Authorize(Policy = "ManagerPolicy")]
[HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] CategoryUpdateDto Category)
        {
            var result = await _Categorieservice.UpdateAsync(Category);
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
            var Category = await _Categorieservice.GetByIdAsync(id);
            if (Category == null)
                return NotFound();

            await _Categorieservice.DeleteAsync(id);
            return NoContent();
        }
    }
}


/*

Get two Categories after skip the first two Categories {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
