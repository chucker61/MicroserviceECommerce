using MicroserviceECommerce.Identity.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Identity.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseOpenIddict();
            });
        }
        public static void ConfigureOpenIddict(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                });
        }


    }
}
