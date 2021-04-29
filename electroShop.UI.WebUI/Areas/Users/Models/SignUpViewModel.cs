using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace electroShop.UI.WebUI.Areas.Users.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="{0} الزامی می باشد")]
        [Display(Name ="نام")]
        [MinLength(3,ErrorMessage ="حداقل 3 کارکتر الزامی می باشد")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="{0} الزامی می باشد")]
        [Display(Name ="نام خانوادگی")]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage ="{0} الزامی می باشد")]
        [Display(Name ="ایمیل")]
        [EmailAddress(ErrorMessage ="ایمیل آدرس صحیح نمی باشد")]
        [UIHint("Email")]
        [Remote("CheckEmail","Home","Users",ErrorMessage ="این ایمیل تکراری می باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی می باشد")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل آدرس صحیح نمی باشد")]
        [UIHint("Email")]
        [Compare("Email",ErrorMessage = "ایمیل ها با هم یکسان نمی باشد")]
     
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "پسورد الزامی می باشد")]
        [Display(Name = "پسورد")]
        [UIHint("Password")]
        [MinLength(6,ErrorMessage ="حداقل شش کارکتر لازم است")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "پسورد الزامی می باشد")]
        [Display(Name = "پسورد")]
        [UIHint("Password")]
        [MinLength(6, ErrorMessage = "حداقل شش کارکتر لازم است")]
        [Compare("PassWord", ErrorMessage = "پسورد ها با هم یکسان نمی باشد")]
        public string ConfirmPassWord { get; set; }
        public string SiteKey { get; set; }


    }
}
