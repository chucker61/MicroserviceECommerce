using MicroserviceECommerce.Cargo.Entities.Dtos.CargoDetailDtos;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _cargoDetailService.GetAllCargoDetailsAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoDetailAsync(string id)
        {
            var category = await _cargoDetailService.GetByIdCargoDetailAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetailAsync([FromBody] CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailService.CreateCargoDetailAsync(createCargoDetailDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetailAsync([FromBody] UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailService.UpdateCargoDetailAsync(updateCargoDetailDto);
            return Ok();
        }
        [Authorize("CatalogFullPermission")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoDetailAsync(string id)
        {
            await _cargoDetailService.DeleteCargoDetailAsync(id);
            return Ok();
        }
    }
}
