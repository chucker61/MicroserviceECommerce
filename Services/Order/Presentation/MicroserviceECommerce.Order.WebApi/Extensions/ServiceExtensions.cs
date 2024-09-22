using MicroserviceECommerce.Application.Features.Mediator.Handlers.AddressHandlers;
using MicroserviceECommerce.Application.Features.Mediator.Handlers.OrderDetailHandlers;
using MicroserviceECommerce.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") , x=> x.MigrationsAssembly("MicroserviceECommerce.Order.Persistance")));
        }

        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAddressQueryHandler>();
        }
    }
}
