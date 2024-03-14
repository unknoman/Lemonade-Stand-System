using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Lemonade_Stand_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ProductBusiness _productBusiness;

        public ProductController(ProductBusiness productBusiness)
        {
           _productBusiness = productBusiness;
        }

        [HttpGet(Name = "GetProduct")]

        public async Task<List<Product>> getProduct(int producto)
        {

            List<Product> products = await _productBusiness.getProduct(producto);
            return products;
        }


    }
}