using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MicroserviceECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
       {
           new ApiResource("ResourceCatalog"){Scopes={ "CatalogFullPermission", "CatalogReadPermission" } },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
       };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Email()
        };


        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="MicroserviceECommerceVisitorId",
                ClientName="Microservice E-Commerce Visitor",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("MicroserviceECommerceSecret".Sha256())},
                AllowedScopes={"CatalogReadPermission",  IdentityServerConstants.LocalApi.ScopeName },
            },
            //Manager
            new Client
            {
                ClientId="MicroserviceECommerceManagerId",
                ClientName="Microservice E-Commerce Manager",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("MicroserviceECommerceSecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","CatalogReadPermission","DiscountFullPermission", "CargoFullPermission", IdentityServerConstants.LocalApi.ScopeName },
            },
            //Admin
            new Client
            {
                ClientId="MicroserviceECommerceAdminId",
                ClientName="Microservice E-Commerce Admin",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("MicroserviceECommerceSecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","CatalogReadPermission","DiscountFullPermission","OrderFullPermission", "CargoFullPermission", IdentityServerConstants.LocalApi.ScopeName },
            },

        };
    }
}
