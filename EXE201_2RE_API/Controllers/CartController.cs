using EXE201_2RE_API.Response;
using EXE201_2RE_API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_2RE_API.Controllers
{
    [ApiController]
    [Route("/cart")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [AllowAnonymous]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest req)
        {
            var result = await _cartService.Checkout(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("/user/{id}")]
        public async Task<IActionResult> GetCartsByUserId([FromRoute] Guid id)
        {
            var result = await _cartService.GetCartsByUserId(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
