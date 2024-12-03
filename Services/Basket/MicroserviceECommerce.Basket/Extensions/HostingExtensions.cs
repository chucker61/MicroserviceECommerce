using System;
using System.IdentityModel.Tokens.Jwt;
using MicroserviceECommerce.Basket.Services;
using MicroserviceECommerce.Basket.Services.Contracts;
using MicroserviceECommerce.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

namespace MicroserviceECommerce.Basket.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["IdentityServerUrl"];
                    options.Audience = "ResourceBasket";
                    options.RequireHttpsMetadata = false;
                });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ILoginService, LoginManager>();
        builder.Services.AddScoped<IBasketService, BasketManager>();
        builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
        builder.Services.AddSingleton<RedisService>(sp => {
            var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            var redis = new RedisService(redisSettings.Host, redisSettings.Port);
            redis.Connect();
            return redis;
        });

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add(new AuthorizeFilter());
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
