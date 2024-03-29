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
            return Ok(await _productBusiness.getProduct(product));
        }


        [HttpPost ("productType", Name = "productType")]
        public async Task<ActionResult<ProductTypePostDTO>> postProductType(ProductTypePostDTO productType)
        {
            var productTypeRes = await _productBusiness.postProductType(productType);
            return productTypeRes == null ? BadRequest() : StatusCode(201, productTypeRes);
        }



        [HttpPost("productPost", Name = "productPost")]
        public async Task<ActionResult<ProductPostDTO>> postProduct(ProductPostDTO product)
        {
         return StatusCode(201, await _productBusiness.postProduct(product));
        }

    }
}