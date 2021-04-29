using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Cart.Models
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static TEntity GetJson<TEntity>(this ISession session, string key)
        {
            var Check = session.GetString(key);

            return Check == null ? default(TEntity) : JsonConvert.DeserializeObject<TEntity>(Check);
        }

        public static bool CheckAvailable(this ISession session, string key)
        {
            var Check = session.GetString(key);

            return Check == null ? false : true;
        }
    }
}
