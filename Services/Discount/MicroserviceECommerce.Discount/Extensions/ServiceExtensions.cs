using MicroserviceECommerce.Discount.Context;
using MicroserviceECommerce.Discount.Services.DiscountServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MicroserviceECommerce.Discount.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<DapperContext>();
            services.AddTransient<IDiscountService, DiscountService>();
        }
    }
}
