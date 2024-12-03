using MicroserviceECommerce.Basket.Entities.Dtos.BasketDtos;
using MicroserviceECommerce.Basket.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketAsync()
        {
            var basket = await _basketService.GetBasketAsync();
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasketAsync(SaveBasketDto saveBasketDto)
        {
            await _basketService.SaveBasketAsync(saveBasketDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasketAsync()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok();
        }
    }
}
