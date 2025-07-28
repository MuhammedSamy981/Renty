using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Renty.Application.DTOs;
using Renty.Application.Interfaces;
using Renty.Domain.Models;

namespace Renty.Presentation.WebApi.Controllers
{
    public class ProductsController : ODataController
    {
        const string pattern="odata/Products";
         private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService,ILogger<ProductsController> logger)
        {
            _productService = productService;
           _logger = logger;
        }
        
        #region Query Options

        //Get all products names (GET):
        //GET http://localhost:5003/odata/Products?$select=Name

        //Get all products with their related orders (GET):
        //GET http://localhost:5214/odata/Products?$expand=Images&$expand=Ratings

        //Order the Products by Name in ascending order
        //http://localhost:5003/odata/Products?$orderby=Name 

        //Order the Products by Name in descending order
        //http://localhost:5003/odata/Products?$orderby=Name%20desc

        //Get product with ID = 1 :
        //GET http://localhost:5003/odata/Products?$filter=CategoryId%20eq%201

        //Get product with max price :
        //GET http://localhost:5003/odata/Products?$apply=aggregate(Price%20with%20max%20as%20MaxPrice)

        //Get two products after skip the first two products :
        //GET http://localhost:5000/Products?$top=2&$skip=2

        //Select only the Name property from Products entity.
        //Filter the Orders and return only the ones whose Id is greater than 1.
        //Order the Products by Name in descending order
        //http://localhost:5003/odata/Products?$select=Name&$filter=Id%20gt%201&$orderby=Name%20desc

        #endregion

        /*        [EnableQuery]   
                [HttpGet(pattern)]
                public async Task<IQueryable<Product>> GetAll()
                {
                    var products = await _productService.GetAllAsync();
                    return _mapper.Map<List<Product>>(products).AsQueryable();
                }*/


        [HttpGet(pattern)]
      public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return products;
        }

/*        [EnableQuery(PageSize = 2)]
        [HttpGet(pattern+"WithPaging")]
        public async Task<List<ProductDto>> GetAllWithPaging()
        {
            var products = await _productService.GetAllAsync();
            return products;
        }*/


        [HttpGet(pattern+"/filters")]
      public async Task<List<ProductDto>> GetAllFiltered([FromQuery]Filters filters)
      {
            var products = await _productService.GetAllFilteredsAsync(filters);
            return products;
        }


        [HttpGet(pattern+"/User/{id}")]
      public async Task<List<ProductDto>> GetAllByUserId(string id)
        {
            var products = await _productService.GetAllByUserIdAsync(id);
            return products;
        }

[HttpGet(pattern+"{name}")]        
    public async Task<List<ProductDto>> GetAllByNameAsync(string name)
    {
        var products=await _productService.GetAllByNameAsync(name);
        return products;
    }
        [HttpGet(pattern+"/{id},{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int id, string userId)
        {
            var product = await _productService.GetAllDetailsByIdAsync(id,userId);
            if (product == null)
                return NotFound();
            return Ok(product);
        }



  [Authorize(Policy = "UserPolicy")]
[HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductAddDto product)
        {
            
        var userId = User?.Identity?.Name ?? "Anonymous";
        
        try
        {
            await _productService.AddAsync(product);

           /* UserActionLogger.LogAction(
                userId: userId,
                action: "CreateProduct",
                details: $"Created product {product.Name}",
                context: HttpContext);*/
            
            return Ok(product);
        }
        catch (Exception ex)
        {
            /*UserActionLogger.LogAction(
                userId: userId,
                action: "CreateProductFailed",
                details: $"Failed to create product {product.Name}. Error: {ex.Message}",
                context: HttpContext);*/
                
            return BadRequest(ex.Message);
        }

        }

  [Authorize(Policy = "UserPolicy")] 
[HttpPut(pattern)]
        public async Task<IActionResult> Put([FromBody] ProductUpdateDto product)
        {
            var result = await _productService.UpdateAsync(product);
            if(!result)
        {
            return NotFound();
        }

            return Updated(result);
        }

  [Authorize(Policy = "UserPolicy")] 
  [HttpDelete(pattern+"/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
          var result = await _productService.DeleteAsync(id);
            if(!result)
                return NotFound();
            return NoContent();
        }

[Authorize(Policy = "AdminPolicy")]
    [HttpPut(pattern + "/{id},{status}")]
        public async Task<IActionResult> Approve([FromRoute] int id,string status)
        {
            await _productService.EditStatusAsync(id,status);
              return NoContent();
        }

    }
}


/*

Get two products after skip the first two products {server side}:
first: [EnableQuery(PageSize = 2)]
second: services.AddControllers().AddOData(options =>
    options.SetMaxTop(null).SkipToken());

*/
