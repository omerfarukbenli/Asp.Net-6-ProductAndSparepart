using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAndSparepart.Business.Abstract;
using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;

namespace ProductAndSparepart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] string searchTerm)
        {
            return Ok(await _productService.GetProducts(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductsId(int id)
        {
            return Ok(await _productService.GetProductsId(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto categoryDto)
        {
            return Ok(await _productService.Post(categoryDto));
        }
        [HttpPut("{id}")]
       public async Task<IActionResult> Update(int id, UpdateProductDto categoryDto)
        {

            await _productService.Update(categoryDto);
            return NoContent();
        }
    


    }  
}
