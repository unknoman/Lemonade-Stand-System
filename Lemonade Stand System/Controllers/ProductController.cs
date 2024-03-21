using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Models;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;

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

        public async Task<ActionResult<List<ProductGetDTO>>> getProduct(int product)
        {

            List<ProductGetDTO> products = await _productBusiness.getProduct(product);
            return products != null && products.Any() ? Ok(products) : NotFound();
        }


        [HttpPost ("productType", Name = "productType")]
        public async Task<ActionResult<ProductTypePostDTO>> postPrudctType(ProductTypePostDTO productType)
        {

            var productTypeRes = await _productBusiness.postPrudctType(productType);
            return productTypeRes == null ? BadRequest() : StatusCode(201, productTypeRes);
        }


    }
}