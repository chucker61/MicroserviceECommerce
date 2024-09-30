using MicroserviceECommerce.Catalog.Dtos.CategoryDtos;
using MicroserviceECommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategoryAsync(string id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok();
        }
        [Authorize("CatalogFullPermission")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
