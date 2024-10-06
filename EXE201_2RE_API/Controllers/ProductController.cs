using EXE201_2RE_API.DTOs;
using EXE201_2RE_API.Repository;
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
        
        [AllowAnonymous]
        [HttpGet("newest")]
        public async Task<IActionResult> GetNewestProducts()
        {
            var result = await _productService.GetNewestProducts();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> GetListProductByListId([FromQuery] List<Guid> listId)
        {
            if (listId == null || listId.Count == 0)
            {
                return BadRequest("No IDs provided.");
            }

            var result = await _productService.GetListProductByListId(listId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("related/{id}")]
        public async Task<IActionResult> GetRelatedProducts([FromRoute] Guid id)
        {
            var result = await _productService.GetRelatedProducts(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductModel createProductModel)
        {
            var result = await _productService.CreateProduct(createProductModel);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("order-from-shop/{shopId}")]
        public async Task<IActionResult> GetProductByShopOwner([FromRoute] Guid shopId)
        {
            var result = await _productService.GetProductByShopOwner(shopId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("product-from-shop/{shopId}")]
        public async Task<IActionResult> GetAllProductFromShop([FromRoute] Guid shopId)
        {
            var result = await _productService.GetAllProductFromShop(shopId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
