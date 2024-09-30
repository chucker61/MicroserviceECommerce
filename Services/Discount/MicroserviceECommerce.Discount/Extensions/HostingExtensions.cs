using MicroserviceECommerce.Discount.Context;
using MicroserviceECommerce.Discount.Entities.ErrorModel;
using MicroserviceECommerce.Discount.Entities.Exceptions;
using MicroserviceECommerce.Discount.Services.DiscountServices;
using MicroserviceECommerce.Discount.Services.LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using NLog;
using System.Runtime.CompilerServices;

namespace MicroserviceECommerce.Discount.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            LogManager.Setup().LoadConfigurationFromFile("nlog.config");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = "http://localhost:5001";
                options.Audience = "ResourceDiscount";
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<DapperContext>();
            builder.Services.AddTransient<IDiscountService, DiscountService>();
            builder.Services.AddSingleton<ILoggerService, LoggerService>();

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
