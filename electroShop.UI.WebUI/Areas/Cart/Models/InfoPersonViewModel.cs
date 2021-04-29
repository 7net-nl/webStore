using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Cart.Models
{
    public class InfoPersonViewModel
    {
        [Required(ErrorMessage ="نام الزامی می باشد")]
        [MinLength(3,ErrorMessage ="حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کارکتر  ")]
        [Display(Name ="نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی الزامی می باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کارکتر  ")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی می باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر  ")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage ="آدرس ایمیل صحیح وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "آدرس الزامی می باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر  ")]
        [Display(Name = "آدرس")]
     
        public string Address { get; set; }

        [Required(ErrorMessage = "شهر الزامی می باشد")]
        [MinLength(2, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر  ")]
        [Display(Name = "شهر")]
       
        public string City { get; set; }

        [Required(ErrorMessage = "استان الزامی می باشد")]
        [MinLength(2, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر")]
        [Display(Name = "استان")]
        public string Country { get; set; }

        [Required(ErrorMessage = "کد پستی الزامی می باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(13, ErrorMessage = "حداکثر 13 کارکتر")]
        [Display(Name = "کد پستی")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "تلفن الزامی می باشد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کارکتر الزامی میباشد")]
        [MaxLength(13, ErrorMessage = "حداکثر 13 کارکتر  ")]
        [Display(Name = "تلفن")]
        [Phone(ErrorMessage ="فقط شماره تلفن")]
        public string Tel { get; set; }

        
        
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر  ")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
