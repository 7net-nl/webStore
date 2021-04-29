using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ElectroShop.UI.OAuth.Infrasctures
{
    public class IdentityServerData
    {
       

        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                      ClientId="PostManClient",
                      ClientSecrets = new []{new Secret("secret".Sha256()) },
                      AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                      AllowedScopes=new [] { "MyApi2" }
                },
                 new Client
                {
                      ClientId="mvc",
                      ClientName="Mvc Client",
                     
                      AllowedGrantTypes=GrantTypes.Implicit,
                      RedirectUris={"https://localhost:44325/signin-oidc" },
                      PostLogoutRedirectUris={ "https://localhost:44325/signout-callback-oidc" },
                      AllowedScopes=new List<string>
                      {
                           StandardScopes.OpenId,
                           StandardScopes.Profile
                      }
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                       Password="Test123",
                        Username="Test",
                         SubjectId="1"
                }
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<ApiResource> GetApiResources()
        {

            return new List<ApiResource>
            {
                 new ApiResource("MyApi","My Api Display"),
                 new ApiResource("MyApi2","My Api Display")
            };

        }

        public static List<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope("MyApi2","My Api Display")
            };
        }
    }
}
