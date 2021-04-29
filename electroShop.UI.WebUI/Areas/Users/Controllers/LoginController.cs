using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using electroShop.UI.WebUI.Areas.Users.Data;
using electroShop.UI.WebUI.Areas.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace electroShop.UI.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class LoginController : Controller
    {
        private readonly SignInManager<MyUser> signInManager;
        private readonly UserManager<MyUser> userManager;

        public LoginController(SignInManager<MyUser> signInManager,UserManager<MyUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
       
        [HttpPost]
        public IActionResult Index(string Provider="")
        {
            var Properties = signInManager.ConfigureExternalAuthenticationProperties(Provider, "");

            return Challenge(Properties,Provider);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           

            var Info = await signInManager.GetExternalLoginInfoAsync();
            if (Info == null) return RedirectToAction("SignIn","Home");

            var Result = await signInManager.ExternalLoginSignInAsync(Info.LoginProvider, Info.ProviderKey, false,false);
            if (Result.Succeeded)
                return Redirect("/");
            else
            {
                var Email = Info.Principal.FindFirst(ClaimTypes.Email);
                var Users = new MyUser
                {
                     Email = Email.Value.ToString(),
                     UserName = Email.Value.ToString(),
                };

               var ResultCreate1 = await userManager.CreateAsync(Users);
                var ResultCreate2 = await userManager.AddLoginAsync(Users,Info);
                await userManager.AddToRoleAsync(Users, "User");

                await signInManager.SignInAsync(Users,false);

                if (ResultCreate2.Succeeded)
                    return Redirect("/");

            }
            
            return RedirectToAction("SignIn","Home");
        }
      
    }
}
