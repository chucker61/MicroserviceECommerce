using System;
using MicroserviceECommerce.IdentityServer.Dtos;
using MicroserviceECommerce.IdentityServer.Models;

namespace MicroserviceECommerce.IdentityServer.Services.Contracts;

public interface IRegisterService
{
    public Task<ApplicationUser> RegisterAsync(UserRegisterDto userRegisterDto);
}
