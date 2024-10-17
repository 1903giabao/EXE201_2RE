﻿using EXE201_2RE_API.Response;
using EXE201_2RE_API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;

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
        [HttpGet()]
        public async Task<IActionResult> GetAllCart()
        {
            var result = await _cartService.GetAllCart();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest req)
        {
            var result = await _cartService.Checkout(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetCartsByUserId([FromRoute] Guid id)
        {
            var result = await _cartService.GetCartsByUserId(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }        
        
        [AllowAnonymous]
        [HttpPut("/status/{cartId}")]
        public async Task<IActionResult> ChangeCartStatus([FromRoute] Guid cartId, [FromQuery] string status)
        {
            var result = await _cartService.ChangeCartStatus(cartId, status);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("return-url")]
        public async Task<IActionResult> HandleReturnUrl([FromQuery] string code, [FromQuery]  string id, [FromQuery] string cancel, [FromQuery] string status, [FromQuery] long orderCode)
        {
            var result = await _cartService.UpdateCartStatus(orderCode, status);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        // Endpoint for cancelUrl
        [AllowAnonymous]
        [HttpGet("cancel-url")]
        public async Task<IActionResult> HandleCancelUrl([FromQuery] string code, [FromQuery] string id, [FromQuery] string cancel, [FromQuery] string status, [FromQuery] long orderCode)
        {
            var result = await _cartService.UpdateCartStatus(orderCode, status);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
