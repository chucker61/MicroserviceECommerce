using MicroserviceECommerce.Identity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;

namespace MicroserviceECommerce.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _openIddictApplicationManager;

        public ClientController(IOpenIddictApplicationManager openIddictApplicationManager)
        {
            _openIddictApplicationManager = openIddictApplicationManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientCreateDto dto)
        {
            var client = await _openIddictApplicationManager.FindByClientIdAsync(dto.ClientId);
            if (client is null)
            {
                await _openIddictApplicationManager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = dto.ClientId,
                    ClientSecret = dto.ClientSecret,
                    DisplayName = dto.DisplayName,
                    Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                    OpenIddictConstants.Permissions.Prefixes.Scope + "read",
                    OpenIddictConstants.Permissions.Prefixes.Scope + "write"
                }
                });
                return Ok("Client başarılı bir şekilde oluşturuldu.");
            }
            return Ok("Client zaten mevcut.");
        }
    }
}
