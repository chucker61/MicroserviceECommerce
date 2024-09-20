using MicroserviceECommerce.Catalog.Dtos.ProductDetailDtos;
using MicroserviceECommerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetailAsync([FromBody] CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailAsync([FromBody] UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetailAsync(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok();
        }
    }
}
