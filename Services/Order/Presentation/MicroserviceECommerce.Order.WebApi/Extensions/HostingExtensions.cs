using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Application.Extensions;
using MicroserviceECommerce.Persistance.Repositories;
using MicroserviceECommerce.WebApi.Extensions;

namespace MicroserviceECommerce.Order.WebApi.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureSqlConnection(builder.Configuration);
            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddApplicationServices();
            builder.Services.RegisterHandlers();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
