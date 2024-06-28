using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsDTO.DTOPost;

namespace Lemonade_Stand_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly SuppliesBusiness _suppliesBusiness;
        public SuppliesController(SuppliesBusiness suppliesBusiness)
        {
            _suppliesBusiness = suppliesBusiness;
        }

        [HttpPost("Supplies", Name = "SuppliesOrder")]
        public async Task<int?> postSuppliesOrder(SuppliesOrderPostDTO suppliesOrder)
        {
            return await _suppliesBusiness.postSuppliesOrder(suppliesOrder);
        }

    }
}
