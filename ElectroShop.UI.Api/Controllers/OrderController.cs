using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop.Service.Application.Orders;
using ElectroShop.Service.Application.Products;
using ElectroShop.UI.Api.Filters;
using ElectroShop.UI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectroShop.UI.Api.Controllers
{
    [Route("api/v{version:ApiVersion}/Order")]
    [ApiVersion("1.0")]
    public class OrderController : BaseController
    {
        private readonly IProductService productService;

        public OrderController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var GetAll = HttpContext.Session.Get("Order");
            var Orders = HttpContext.Session?.GetObject<List<OrderDto>>("Order");
            if (Orders == null) return Ok(new List<OrderDto>());
            return Ok(Orders);
        }

        [HttpPost]
        [CheckException]
        public IActionResult Post(int Id,byte Quntity=1)
        {

                var Product = productService.Find(Id);
                
                if(Product == null)
                {
                return BadRequest("محصول مورد نظر یافت نشد");
                }
                var Orders = HttpContext.Session?.GetObject<List<OrderDto>>("Order");
                if (Orders == null)
                {
                Orders = new List<OrderDto>
                    {
                        new OrderDto
                        {
                             Product=Product,
                              Product_ID = Product.ID,
                              Quntity=1
                        }
                    };
                }

                if(Orders.Where(c=>c.Product_ID==Id).Count() > 0)
            {
                Orders.Where(c => c.Product_ID == Id).LastOrDefault().Quntity = Quntity;
            }
                
                HttpContext.Session.SetObject("Order", Orders);


           return Ok("Add TO Order");
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
