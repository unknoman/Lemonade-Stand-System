using AutoMapper;
using Data.Interfaces;
using Models;
using Models.ModelsDTO.DTOGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClientBusiness
    {

        private readonly IDataGeneric<ClientOrder> _dbGeneric;
        private readonly IMapper _mapper;

        public ClientBusiness(IDataGeneric<ClientOrder> dataGeneric, IMapper mapper) {
        _dbGeneric = dataGeneric;
         _mapper = mapper;
        }

        public async Task<List<ClientOrderGetDTO>> getClientOrder()
        {
           List<ClientOrder> clientList = await _dbGeneric.getList();
           List<ClientOrderGetDTO> clientOrderList = _mapper.Map<List<ClientOrderGetDTO>>(clientList);
           return clientOrderList;
        }

        public async Task<ClientOrderGetDTO> getClientOrder(int id)
        {
        ClientOrderGetDTO client =  _mapper.Map<ClientOrderGetDTO>(await _dbGeneric.getObjectType(id));
        if(client != null) { return client; }
         throw new KeyNotFoundException("Client Order Not Found");
        }




    }
}
