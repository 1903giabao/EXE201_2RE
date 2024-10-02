using EXE201_2RE_API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_2RE_API.Controllers
{
    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProducts();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var result = await _productService.GetProductById(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
