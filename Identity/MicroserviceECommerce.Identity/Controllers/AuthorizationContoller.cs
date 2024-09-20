using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MicroserviceECommerce.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationContoller : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _applicationManager;

        public AuthorizationContoller(IOpenIddictApplicationManager openIddictApplicationManager)
        {
            _applicationManager = openIddictApplicationManager;
        }

        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest();
            if (request?.IsClientCredentialsGrantType() is not null)
            {
                //Client credentials OpenIddict tarafından otomatik olarak doğrulanır.
                //Eğer ki gelen request'in body'sindeki client_id veya client_secret bilgileri geçersizse, burası tetiklenmeyecektir.

                var application = await _applicationManager.FindByClientIdAsync(request.ClientId);
                if (application is null)
                    throw new InvalidOperationException("This clientId was not found");

                var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                //Token'a claim'leri ekleyelim. Subject'in eklenmesi zorunludur.
                //Destination'lar ile claim'lerin hangi token'a ekleneceğini belirtiyoruz. AccessToken mı? Identity Token mı? Yoksa her ikisi de mi?

                identity.AddClaim(Claims.Subject, (await _applicationManager.GetClientIdAsync(application) ?? throw new InvalidOperationException()));
                identity.AddClaim(Claims.Name, (await _applicationManager.GetDisplayNameAsync(application) ?? throw new InvalidOperationException()));
                identity.AddClaim("ozel-claim", "ozel-claim-value");

                identity.AddClaim(JwtRegisteredClaimNames.Aud, "Example-OpenIddict");

                var claimsPrincipal = new ClaimsPrincipal(identity);

                foreach (var claim in claimsPrincipal.Claims)
                    claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);

                claimsPrincipal.SetScopes(request.GetScopes());

                //SignIn return etmek, biryandan OpenIddict'ten uygun access/identity token talebinde bulunmaktır.
                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            throw new NotImplementedException("The specified grant type is not implemented.");
        }
    }
}
