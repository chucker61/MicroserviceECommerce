using MicroserviceECommerce.WebAppMvc.Context;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Client;

namespace MicroserviceECommerce.WebAppMvc.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddOpenIddict();
        }

        public static void ConfigureOpenIdDict(this IServiceCollection services)
        {
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                           .UseDbContext<ApplicationDbContext>();
                })
                .AddClient(options =>
                {
                    options.SetRedirectionEndpointUris("/callback/login/local")
                           .SetPostLogoutRedirectionEndpointUris("/callback/logout/local")

                           .AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate()

                           .AllowAuthorizationCodeFlow()
                           .AllowRefreshTokenFlow()

                           .UseAspNetCore()
                            .EnableStatusCodePagesIntegration()
                            .EnableRedirectionEndpointPassthrough()
                            .EnablePostLogoutRedirectionEndpointPassthrough();

                    options.UseSystemNetHttp();

                    options.AddRegistration(new OpenIddictClientRegistration
                    {
                        Issuer = new Uri("https://localhost:7144", UriKind.Absolute),

                        ClientId = "mvc-client",
                        ClientSecret = "mvc-client-secret",
                        Scopes = { "read", "write", "offline_access" },

                        RedirectUri = new Uri("https://localhost:7252/callback/login/local", UriKind.Absolute),
                        PostLogoutRedirectUri = new Uri("https://localhost:7252/callback/logout/local", UriKind.Absolute)
                    }); ;
                })
                .AddValidation(options =>
                {
                    options.UseLocalServer();
                    options.UseAspNetCore();
                });
        }
    }
}
