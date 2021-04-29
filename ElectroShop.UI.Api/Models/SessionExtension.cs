using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Api.Models
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session,string Key,object Value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(Value));
        }

        public static TEntity GetObject<TEntity>(this ISession session,string Key)
        {
            var Value = session.GetString(Key);
            return Value == null ? default(TEntity) : JsonConvert.DeserializeObject<TEntity>(Value);

        }
    }
}
