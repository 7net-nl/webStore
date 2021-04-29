using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroShop.UI.Api.Controllers
{
    [ApiController]
    [EnableCors("HealthPolicy")]
    public abstract class BaseController:Controller
    {
        protected IActionResult CheckErorr<TEntity>(TEntity entity) where TEntity : class
        {

            if (entity == null) return BadRequest();

            return Ok(entity);
        }
    }
}
