using IdentityModel;
using MicroserviceECommerce.IdentityServer.Data;
using MicroserviceECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace MicroserviceECommerce.IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var user = userMgr.FindByNameAsync("meliksahmc").Result;
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = "meliksahmc",
                        Email = "meliksahmertcakir@hotmail.com",
                        EmailConfirmed = true,
                        Name = "Melikşah Mert",
                        SurName = "Çakır"
                    };
                    var result = userMgr.CreateAsync(user, "123456aA*").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(user, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Melikşah Mert Çakır"),
                                new Claim(JwtClaimTypes.GivenName, "Melikşah Mert"),
                                new Claim(JwtClaimTypes.FamilyName, "Çakır"),
                                new Claim(JwtClaimTypes.WebSite, "http://meliksahmertcakir.com"),
                            }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("admin created");
                }
                else
                {
                    Log.Debug("admin already exists");
                }

                var bob = userMgr.FindByNameAsync("bob").Result;
                if (bob == null)
                {
                    bob = new ApplicationUser
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true
                    };
                    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Bob Smith"),
                                new Claim(JwtClaimTypes.GivenName, "Bob"),
                                new Claim(JwtClaimTypes.FamilyName, "Smith"),
                                new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                                new Claim("location", "somewhere")
                            }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("bob created");
                }
                else
                {
                    Log.Debug("bob already exists");
                }
            }
        }
    }
}
