using MicroserviceECommerce.Catalog.Services;
using MicroserviceECommerce.Catalog.Services.CategoryServices;
using MicroserviceECommerce.Catalog.Services.ProductDetailServices;
using MicroserviceECommerce.Catalog.Services.ProductImageServices;
using MicroserviceECommerce.Catalog.Services.ProductService;
using MicroserviceECommerce.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace MicroserviceECommerce.Catalog.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void ConfigureDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
        }


    }
}
