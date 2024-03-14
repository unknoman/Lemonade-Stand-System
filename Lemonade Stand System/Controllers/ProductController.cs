using Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ModelsDTO;

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

        public async Task<List<ProductDTO>> getProduct(int producto)
        {

            List<ProductDTO> products = await _productBusiness.getProduct(producto);
            return products;
        }


    }
}