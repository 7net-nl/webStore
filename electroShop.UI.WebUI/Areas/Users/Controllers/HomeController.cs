using electroShop.UI.WebUI.Areas.Users.Data;
using electroShop.UI.WebUI.Areas.Users.Models;
using electroShop.UI.WebUI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace electroShop.UI.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;
        private readonly IOptions<RecaptchaSettings> options;

        public HomeController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager,IOptions<RecaptchaSettings> options)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.options = options;
        }
        public IActionResult SignUp(string Erorr="")
        {
           
            var model = new SignUpViewModel
            {
                SiteKey = options.Value.SiteKey
            };

            ModelState.AddModelError("", Erorr);
           

           return View(model);
        }

        [HttpPost]
        [RecaptchaGoogle]
        [CheckModelSate]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {

                
                var User = new MyUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var Result = await userManager.CreateAsync(User, model.PassWord);

                if (Result.Succeeded)
                {
                    await userManager.AddToRoleAsync(User, "User");
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }

            
        

            return View(model);
        }

        public async Task<IActionResult> SignIn()
        {
            var Providers = await signInManager.GetExternalAuthenticationSchemesAsync();
            var model = new SignInViewModel
            {
                Providers = Providers.ToList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string ReturnUrl = null)
        {
            
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var Result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (Result.Succeeded)
                    return ReturnUrl == null ? Redirect("/") : Redirect(ReturnUrl);
                else
                {
                    ModelState.AddModelError("Email", "ایمیل در سیستم یافت نشد");
                    ModelState.AddModelError("Password", "پسورد اشتباه است");
                }
            }

            else
            {
                ModelState.AddModelError("Email", "ایمیل در سیستم یافت نشد");
                ModelState.AddModelError("Password", "پسورد اشتباه است");
            }

            var Providers = await signInManager.GetExternalAuthenticationSchemesAsync();
            model.Providers = Providers.ToList();

            return View(model);
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();

            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult CheckEmail(string Email)
        {
            var Find = userManager.Users.Where(c => c.Email == Email);
            var Result = Find.Count() > 0 ? false : true;
            return Json(Result);
        }

    }
      
}
