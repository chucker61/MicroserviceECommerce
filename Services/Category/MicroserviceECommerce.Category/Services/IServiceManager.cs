using MicroserviceECommerce.Catalog.Services.CategoryServices;
using MicroserviceECommerce.Catalog.Services.ProductDetailServices;
using MicroserviceECommerce.Catalog.Services.ProductImageServices;
using MicroserviceECommerce.Catalog.Services.ProductService;
using MicroserviceECommerce.Catalog.Services.LoggerService;

namespace MicroserviceECommerce.Catalog.Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IProductDetailService ProductDetailService { get; }
        IProductImageService ProductImageService { get; }
        ILoggerService LoggerService { get; }
    }
}
