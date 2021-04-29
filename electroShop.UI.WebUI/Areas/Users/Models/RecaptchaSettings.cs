using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Users.Models
{
    public class RecaptchaSettings
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
        public string Version { get; set; }
    }
}
