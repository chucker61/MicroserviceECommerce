using MicroserviceECommerce.Cargo.Entities.Dtos.CargoCompanyDtos;
using MicroserviceECommerce.Cargo.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Cargo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _cargoCompanyService.GetAllCargoCompaniesAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCompanyAsync(string id)
        {
            var category = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompanyAsync([FromBody] CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompanyAsync([FromBody] UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return Ok();
        }
        [Authorize("CatalogFullPermission")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCompanyAsync(string id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return Ok();
        }
    }
}
