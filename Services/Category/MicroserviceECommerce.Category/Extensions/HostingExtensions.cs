using MicroserviceECommerce.Catalog.Entities.ErrorModel;
using MicroserviceECommerce.Catalog.Entities.Exceptions;
using MicroserviceECommerce.Catalog.Services;
using MicroserviceECommerce.Catalog.Services.CategoryServices;
using MicroserviceECommerce.Catalog.Services.LoggerService;
using MicroserviceECommerce.Catalog.Services.ProductDetailServices;
using MicroserviceECommerce.Catalog.Services.ProductImageServices;
using MicroserviceECommerce.Catalog.Services.ProductService;
using MicroserviceECommerce.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NLog;
using System.Reflection;

namespace MicroserviceECommerce.Catalog.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            LogManager.Setup().LoadConfigurationFromFile("nlog.config");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = builder.Configuration["IdentityServerUrl"];
                options.Audience = "ResourceCatalog";
            });
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<ILoggerService, LoggerService>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            var logger = app.Services.GetRequiredService<ILoggerService>();
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
