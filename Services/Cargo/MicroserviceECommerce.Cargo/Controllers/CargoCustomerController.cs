using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCustomerDtos;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _cargoCustomerService.GetAllCargoCustomersAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCustomerAsync(string id)
        {
            var category = await _cargoCustomerService.GetByIdCargoCustomerAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomerAsync([FromBody] CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _cargoCustomerService.CreateCargoCustomerAsync(createCargoCustomerDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomerAsync([FromBody] UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _cargoCustomerService.UpdateCargoCustomerAsync(updateCargoCustomerDto);
            return Ok();
        }
        [Authorize("CatalogFullPermission")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomerAsync(string id)
        {
            await _cargoCustomerService.DeleteCargoCustomerAsync(id);
            return Ok();
        }
    }
}
