using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Users.Models
{
    public class SignInViewModel
    {
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="ایمیل الزامی می باشد")]
        public string Email { get; set; }

        [Display(Name ="پسورد")]
        [Required(ErrorMessage ="پسوزد الزامی می باشد")]
        [DataType(DataType.Password)]
        [UIHint("Password")]
        public string Password { get; set; }

        public List<AuthenticationScheme> Providers { get; set; }
    }
}
