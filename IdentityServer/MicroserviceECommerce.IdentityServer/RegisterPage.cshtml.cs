using MicroserviceECommerce.IdentityServer.Dtos;
using MicroserviceECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace MicroserviceECommerce.IdentityServer
{
    public class RegisterPageModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterPageModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync(UserRegisterDto userRegisterDto)
        {
            var user = new ApplicationUser
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return new JsonResult(user.UserName) { StatusCode = StatusCodes.Status201Created };
            }
            else
            {
                return new JsonResult("Bir sorun oluştu") { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
        
    }
}
