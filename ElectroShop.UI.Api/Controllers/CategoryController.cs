using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop.Service.Application.Categorys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectroShop.UI.Api.Controllers
{
    [Route("api/v{version:apiversion}/Category")]
    [ApiVersion("1.0")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var GetAll = categoryService.GetAll();

            return CheckErorr(GetAll);
        }

      
        // GET api/<controller>/5
        [HttpGet("{Id:int}")]
        public IActionResult Get(byte Id)
        {
            var Category = categoryService.Find(Id);

            return CheckErorr(Category);
        }

       
    }
}
