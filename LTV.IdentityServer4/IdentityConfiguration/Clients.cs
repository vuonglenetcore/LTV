using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTV.IdentityServer4.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",
                    ClientName = "Asp.net core client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret ("ltv.secrets".Sha256()) },
                    AllowedScopes = new List<string> { "ltv.read" },
                },
                new Client
                {
                    ClientId = "oidcClient",
                    ClientName = "Sample Asp.net core web app",
                    ClientSecrets = new List<Secret> {new Secret ("ltv.secrets".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{"https://localhost:44317/signin-oidc"},
                    AllowedScopes = new List<string> {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "ltv.read"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
