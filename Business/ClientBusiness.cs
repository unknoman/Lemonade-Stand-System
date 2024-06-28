using AutoMapper;
using Data;
using Data.Interfaces;
using Models;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClientBusiness
    {

        private readonly IData<ClientOrder> _dbClient;
        private readonly IMapper _mapper;
        private readonly ProductBusiness _productBusiness;
        private readonly ProductData _dbProduct;

        public ClientBusiness(ProductData dbProduct, IData<ClientOrder> dbClient, IMapper mapper, ProductBusiness productBusiness) {
        _dbClient = dbClient;
        _mapper = mapper;
        _productBusiness = productBusiness;
         _dbProduct = dbProduct;
        }

        public async Task<List<ClientOrderGetDTO>> getClientOrder()
        {
            List<ClientOrder> clientList = await _dbClient.getList();
           List<ClientOrderGetDTO> clientOrderList = _mapper.Map<List<ClientOrderGetDTO>>(clientList);
           return clientOrderList;
        }

        public async Task<ClientOrderGetDTO> getClientOrder(int id)
        {
        ClientOrderGetDTO client =  _mapper.Map<ClientOrderGetDTO>(await _dbClient.getObjectType(id));
        if(client != null) { return client; }
         throw new KeyNotFoundException("Client Order Not Found");
        }


        public async Task<int?> postClientOrder(ClientOrderPostDTO clientOrderDTO)
        {
            if(clientOrderDTO.orderDetails == null)
            throw new KeyNotFoundException("OrderDetail Is Null");
            foreach (var order in clientOrderDTO.orderDetails)
            {
                    await _productBusiness.getProduct(order.product);
                Product? product = await _dbProduct.getProductId(order.product);
                if(product != null)
                product.stock = product.stock - order.quantity;
            }

          ClientOrder? client = _mapper.Map<ClientOrder>(clientOrderDTO);
          return await _dbClient.postObject(client);
        }



    }
}
