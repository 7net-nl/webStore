using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.OAuth.Infrasctures
{
    public class Users : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if(context.UserName=="Hamed" && context.Password=="Hamed147")
            {
                context.Result = new GrantValidationResult("1", authenticationMethod: "Custom");
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest);
            }
        }
    }
}
