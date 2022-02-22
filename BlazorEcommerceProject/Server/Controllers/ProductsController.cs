using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerceProject.Server.Controllers
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
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var products = await _productService.GetProducts();

            return Ok(products);
        }

        [HttpGet, Route("{Id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int Id)
        {
            var product = await _productService.GetProduct(Id);

            return Ok(product);
        }
    }
}
