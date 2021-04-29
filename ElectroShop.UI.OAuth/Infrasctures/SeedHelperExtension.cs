using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace ElectroShop.UI.OAuth.Infrasctures
{
    public static class SeedHelperExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<ApiResource>().HasData(
                new ApiResource
                {
                     Id= 1,
                      Name = "MyApi",
                       DisplayName="My Api Display",
                        Enabled=true,
                }
                );

            modelBuilder.Entity<ApiScope>().HasData(new ApiScope
            {
                 Id=1 ,
                  ApiResourceId = 1,
                   Name="MyApi",
                    DisplayName="My Api Display",
                     Emphasize=false,
                      ShowInDiscoveryDocument=true
            });

            modelBuilder.Entity<ClientSecret>().HasData(new ClientSecret
            {
                  Id=1,
                  ClientId= 1,
                  Value="secret".ToSha256(),
                
                  
            });

            modelBuilder.Entity<ClientGrantType>().HasData(
                new ClientGrantType
            {
                   Id=1,
                   ClientId=1,
                   GrantType = GrantTypes.ClientCredentials

            },
                
                new ClientGrantType
                {
                    Id = 2,
                    ClientId = 1,
                    GrantType = GrantTypes.Password

                },
                new ClientGrantType
                {
                    Id = 3,
                    ClientId = 2,
                    GrantType = GrantTypes.Implicit

                }


            );

            modelBuilder.Entity<ClientRedirectUri>().HasData(
                new ClientRedirectUri
                {
                     Id=1,
                      ClientId=2,
                       RedirectUri= "https://localhost:44325/signin-oidc"
                },
                  new ClientRedirectUri
                  {
                      Id = 2,
                      ClientId = 2,
                      RedirectUri = "https://localhost:44395/signin-oidc"
                  }
            );

            modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasData(

                new ClientPostLogoutRedirectUri
                {
                     Id=1,
                     ClientId=2,
                    PostLogoutRedirectUri= "https://localhost:44325/signout-callback-oidc"
                },
                new ClientPostLogoutRedirectUri
                {
                    Id = 2,
                    ClientId = 2,
                    PostLogoutRedirectUri = "https://localhost:44395/signout-callback-oidc"
                }



            );

            modelBuilder.Entity<ClientScope>().HasData(
                new ClientScope
                {
                    Id = 1,
                    ClientId = 1,
                    Scope = StandardScopes.OpenId,

                },
            new ClientScope
            {
                 Id=2,
                  ClientId=2,
                  Scope=StandardScopes.OpenId
            },
            new ClientScope
            {
                 Id=3,
                 ClientId=2,
                  Scope=StandardScopes.Profile
            }
            );

            modelBuilder.Entity<Client>().HasData(
           
                new Client{ Id=1,ClientId="PostManClient"},
                new Client{ Id=2,ClientId="mvc",ClientName="Mvc Client"}

            );

            modelBuilder.Entity<IdentityResource>().HasData(

                new IdentityResource {  Id=1 ,  Name = StandardScopes.OpenId},
                new IdentityResource { Id=2 , Name = StandardScopes.Profile}

                );

            




         
        }
    }
}
