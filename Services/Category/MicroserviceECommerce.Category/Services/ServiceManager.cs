using MicroserviceECommerce.Catalog.Services.CategoryServices;
using MicroserviceECommerce.Catalog.Services.ProductDetailServices;
using MicroserviceECommerce.Catalog.Services.ProductImageServices;
using MicroserviceECommerce.Catalog.Services.ProductService;
using MicroserviceECommerce.Catalog.Services.LoggerService;

namespace MicroserviceECommerce.Catalog.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        private readonly ILoggerService _loggerService;

        public ServiceManager(ICategoryService categoryService, IProductService productService, IProductDetailService productDetailService, IProductImageService productImageService, ILoggerService loggerService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _loggerService = loggerService;
        }

        public ICategoryService CategoryService => _categoryService;
        public IProductService ProductService => _productService;
        public IProductDetailService ProductDetailService => _productDetailService;
        public IProductImageService ProductImageService => _productImageService;
        public ILoggerService LoggerService => _loggerService;

    }
}
