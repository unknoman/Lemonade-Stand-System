using Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ModelsDTO.DTOGet;

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

        public async Task<ActionResult<List<ProductDTO>>> getProduct(int product)
        {

            List<ProductDTO> products = await _productBusiness.getProduct(product);
            return products != null && products.Any() ? Ok(products) : NotFound();
        }


    }
}