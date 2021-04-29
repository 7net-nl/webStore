using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using electroShop.UI.WebUI.Areas.Cart.Models;
using ElectroShop.Service.Application.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace electroShop.UI.WebUI.Areas.Cart.Controllers
{
    [Area("Cart")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        

        public IActionResult Index()
        {
            var model = new CartLineViewModel();
            if (HttpContext.Session.CheckAvailable("Cart"))
            {
               
                model.Cart = HttpContext.Session.GetJson<List<CartViewModel>>("Cart");
                model.Cart.ForEach(c => model.TotalPrice = model.TotalPrice + c.TotalPrice);
                
            }
            else
                model.Cart = new List<CartViewModel>();

         return View(model);

        }



        public IActionResult AddTo(int Id = -1, byte Count = 1, bool Inc = false)
        {
            var Product = productService.Find(Id);


            var ListProduct = new List<CartViewModel>();

            if (HttpContext.Session.CheckAvailable("Cart"))
                ListProduct = AddAvailable(Count, Inc, Product, ListProduct);
            else
                AddNotAvailable(Product, ListProduct, Count);

            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult Remove(int Id,bool Remove)
        { 
            if(Remove==true)
            {
                if (HttpContext.Session.CheckAvailable("Cart"))
                {
                     var ListProduct = HttpContext.Session.GetJson<List<CartViewModel>>("Cart");
                    ListProduct.Remove(ListProduct.Where(c => c.Product.ID == Id).LastOrDefault());
                    HttpContext.Session.SetJson("Cart", ListProduct);

                }
            }

            return RedirectToAction("Index");
        }

        private void AddNotAvailable(ProductDto Product, List<CartViewModel> ListProduct,byte Count)
        {
            
                ListProduct.Add(new CartViewModel { Product = Product, Quntity =  Count});
                HttpContext.Session.SetJson("Cart", ListProduct);
      
        }

        private List<CartViewModel> AddAvailable(byte Count,bool Inc, ProductDto Product, List<CartViewModel> ListProduct)
        {
            

            ListProduct = HttpContext.Session.GetJson<List<CartViewModel>>("Cart");

            var GetProductSession = ProductInSession(Product, ListProduct);

            if (GetProductSession != null && Count >= 1 && Inc == false)
                ProductInSession(Product, ListProduct).Quntity = Count;
            else if (GetProductSession != null && Inc == true)
                ProductInSession(Product, ListProduct).Quntity++;
                else
                    ListProduct.Add(new CartViewModel { Product = Product, Quntity = Count });

                HttpContext.Session.SetJson("Cart", ListProduct);

            

            return ListProduct;
        }

        private static CartViewModel ProductInSession(ProductDto Product, List<CartViewModel> ListProduct)
        {
            return ListProduct.Where(c => c.Product.ID == Product.ID).LastOrDefault();
        }
    }
}
