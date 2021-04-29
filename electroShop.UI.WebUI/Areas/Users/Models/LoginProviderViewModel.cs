using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Users.Models
{
    public class LoginProviderViewModel
    {
        public List<AuthenticationScheme> Providers { get; set; }
    }
}
