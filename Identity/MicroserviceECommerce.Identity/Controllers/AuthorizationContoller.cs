using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MicroserviceECommerce.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationContoller : ControllerBase
    {
        readonly IOpenIddictApplicationManager _applicationManager;

        public AuthorizationContoller(IOpenIddictApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }

        [HttpPost("~/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest();


            if (request?.IsAuthorizationCodeGrantType() is not null)
            {
                var principal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;



                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            }
            else if (request?.IsClientCredentialsGrantType() is not null)
            {

                var application = await _applicationManager.FindByClientIdAsync(request.ClientId);
                if (application is null)
                    throw new InvalidOperationException("This clientId was not found");

                var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                identity.AddClaim(Claims.Subject, (await _applicationManager.GetClientIdAsync(application) ?? throw new InvalidOperationException()));
                identity.AddClaim(Claims.Name, (await _applicationManager.GetDisplayNameAsync(application) ?? throw new InvalidOperationException()));
                identity.AddClaim("ozel-claim", "ozel-claim-value");

                identity.AddClaim(JwtRegisteredClaimNames.Aud, "Example-OpenIddict");

                var claimsPrincipal = new ClaimsPrincipal(identity);

                foreach (var claim in claimsPrincipal.Claims)
                    claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);
                claimsPrincipal.SetScopes(request.GetScopes());

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            throw new NotImplementedException("The specified grant type is not implemented.");
        }


        [HttpGet("~/connect/authorize"), HttpPost("~/connect/authorize")]
        public async Task<IActionResult> Authorize(string accept, string deny)
        {
            var request = HttpContext.GetOpenIddictServerRequest() ?? throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return Challenge(
                    authenticationSchemes: CookieAuthenticationDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties()
                    {
                        RedirectUri = $"{Request.PathBase}{Request.Path}{(QueryString.Create(Request.HasFormContentType ? Request.Form.ToList() : Request.Query.ToList()))}"
                    });

            var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            identity.AddClaim(OpenIddictConstants.Claims.Subject, result.Principal.Identity.Name, Destinations.AccessToken);
            identity.AddClaim(JwtRegisteredClaimNames.Aud, "Example-OpenIddict");
            identity.AddClaim("ornek-claim", "ornek claim value");
            identity.AddClaim("a", "a value");
            identity.AddClaim("b", "b value");

            var application = await _applicationManager.FindByClientIdAsync(request.ClientId);
            if (HttpContext.Request.Method == "GET")
                return View(new AuthorizeVM
                {
                    ApplicationName = await _applicationManager.GetLocalizedDisplayNameAsync(application),
                    Scopes = request.Scope
                });
            else if (!string.IsNullOrEmpty(accept))
            {
                var claimsPrincipal = new ClaimsPrincipal(identity);
                foreach (var claim in claimsPrincipal.Claims)
                    claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);
                claimsPrincipal.SetScopes(request.GetScopes());

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            return Forbid(authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidScope
                }));
        }

        [HttpPost("~/connect/logout"), ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutPost()
        {
            return SignOut(
                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                properties: new AuthenticationProperties
                {
                    RedirectUri = "/"
                });
        }

        [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet("~/connect/userinfo")]
        public async Task<IActionResult> Userinfo()
        {
            var claimPrincipal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;

            return Ok(new
            {
                Name = claimPrincipal.GetClaim(OpenIddictConstants.Claims.Subject),
                Aud = claimPrincipal.GetClaim(OpenIddictConstants.Claims.Audience),
                A = claimPrincipal.GetClaim("a"),
                B = claimPrincipal.GetClaim("b"),
                OrnekClaim = claimPrincipal.GetClaim("ornek-claim"),
            });
        }
    }
}
