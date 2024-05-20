using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;

namespace Lemonade_Stand_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientBusiness _clientBusiness;
        public ClientController(ClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;   
        }

        [HttpPost("ClientGet", Name = "clientGet")]
        public async Task<List<ClientOrderGetDTO>> GetClientOrder()
        {
            return await _clientBusiness.getClientOrder();
        }

        [HttpPost("ClientGetID", Name = "clientGetID")]
        public async Task<ClientOrderGetDTO> GetClientOrder(int id)
        {
            return await _clientBusiness.getClientOrder(id);
        }

    }
}
