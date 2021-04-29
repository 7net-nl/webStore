using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using electroShop.UI.WebUI.Areas.Cart.Models;
using ElectroShop.Domain.Entities;
using ElectroShop.Service.Application.Customers;
using ElectroShop.Service.Application.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace electroShop.UI.WebUI.Areas.Cart.Controllers
{
    [Authorize(Roles = "User")]
    [Area("Cart")]
    public class CheckOutController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;

        public CheckOutController(ICustomerService customerService,IOrderService orderService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var model = new CheckOutViewModel();

            GetSession(model);

            return View(model);
        }

       

        [HttpPost]
        public IActionResult Index(CheckOutViewModel model)

        {

            GetSession(model);

            if (ModelState.IsValid && model.Terms==true)
            {

                   var NewCustomer = new CustomerDto
                {
                    Address = model.InfoPerson.Address,
                    City = model.InfoPerson.City,
                    Country = model.InfoPerson.Country,
                    Description = model.InfoPerson.Description ?? "",
                    Email = model.InfoPerson.Email,
                    FirstName = model.InfoPerson.FirstName,
                    InfoPay = model.InfoPay,
                    LastName = model.InfoPerson.LastName,
                    PostCode = model.InfoPerson.PostCode,
                    Quntity = model.Quntity,
                    Tel = model.InfoPerson.Tel,
                    TotalPrice = model.TotalPrice
                };

                NewCustomer.Orders = model.Carts.Select(c => new OrderDto
                {
                     Customer_ID=NewCustomer.ID,
                     Product_ID = c.Product.ID,
                     Quntity = c.Quntity

                }).ToList();

               customerService.Add(NewCustomer);
                HttpContext.Session.Remove("Cart");


                return RedirectToAction("Save");
                    
            }

           

            return View("Index", model);
           

           
        }

        public IActionResult Save()
        {
            var customer = customerService.GetAll().LastOrDefault();
            customer.Orders = orderService.GetAll().Where(c=>c.Customer_ID==customer.ID).ToList();

            
            if (customer.InfoPay == EnumInfoPay.Online)
                return RedirectToAction("Pay");

            var model = new CustomerViewModel
            {
                 Customer = customer
            };

            return View(model);
        }

        public IActionResult Pay()
        {
            return View();
        }

        private void GetSession(CheckOutViewModel model)
        {
            if (HttpContext.Session.CheckAvailable("Cart"))
            {
                model.Carts = HttpContext.Session.GetJson<List<CartViewModel>>("Cart");
                model.Carts.ForEach(c => model.Quntity = model.Quntity + c.Quntity);
                model.Carts.ForEach(c => model.TotalPrice = model.TotalPrice + c.TotalPrice);

            }
        }




    }
}
