using MicroserviceECommerce.Cargo.Entities.Dtos.CargoOperationDtos;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _cargoOperationService.GetAllCargoOperationsAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoOperationAsync(string id)
        {
            var category = await _cargoOperationService.GetByIdCargoOperationAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperationAsync([FromBody] CreateCargoOperationDto createCargoOperationDto)
        {
            await _cargoOperationService.CreateCargoOperationAsync(createCargoOperationDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperationAsync([FromBody] UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _cargoOperationService.UpdateCargoOperationAsync(updateCargoOperationDto);
            return Ok();
        }
        [Authorize("CatalogFullPermission")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOperationAsync(string id)
        {
            await _cargoOperationService.DeleteCargoOperationAsync(id);
            return Ok();
        }
    }
}
