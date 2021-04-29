using ElectroShop.Service.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShop.UI.Api.Controllers
{
    [Route("api/v{version:apiversion}/Product")]
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var GetAll = productService.GetAll();

            return CheckErorr(GetAll);
        }

        [HttpGet("{Id:int}")]
        public IActionResult Get(int Id=0)
        {
            var Product = productService.Find(Id);

           return CheckErorr(Product);
        }


       
    }
}
