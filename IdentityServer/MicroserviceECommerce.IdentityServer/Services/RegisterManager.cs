using System;
using MicroserviceECommerce.IdentityServer.Dtos;
using MicroserviceECommerce.IdentityServer.Models;
using MicroserviceECommerce.IdentityServer.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace MicroserviceECommerce.IdentityServer.Services;

public class RegisterManager  : IRegisterService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterManager(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> RegisterAsync(UserRegisterDto userRegisterDto)
    {
        var user = new ApplicationUser
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            return user;

    }
}
