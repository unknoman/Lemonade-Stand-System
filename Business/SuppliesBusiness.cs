using Data;
using Models.ModelsDTO.DTOPost;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Interfaces;

namespace Business
{
    public class SuppliesBusiness
    {
        private readonly ProductBusiness _productBusiness;
        private readonly ProductData _dbProduct;
        private readonly IMapper _mapper;
        private readonly IData<SuppliesOrder> _dbClient;
        private readonly SupplierBusiness _supplierBusiness;

        public SuppliesBusiness(SupplierBusiness supplierBusiness, IData<SuppliesOrder> dbClient, ProductBusiness productBusiness, ProductData dbProduct, IMapper mapper)
        {
            _supplierBusiness = supplierBusiness;
            _productBusiness = productBusiness;
            _dbProduct = dbProduct;
            _mapper = mapper;
            _dbClient = dbClient;
        }


        public async Task<int?> postSuppliesOrder(SuppliesOrderPostDTO suppliesOrderDTO)
        {
            await _supplierBusiness.GetSupplier(suppliesOrderDTO.supplier);
            if (suppliesOrderDTO.oDetail == null)
                throw new KeyNotFoundException("OrderDetail Is Null");
            foreach (var order in suppliesOrderDTO.oDetail)
            {
                await _productBusiness.getProduct(order.product);
                Product? product = await _dbProduct.getProductId(order.product);
                if (product != null)
                    product.stock = product.stock + order.quantity;
            }
            SuppliesOrder? Order1 = _mapper.Map<SuppliesOrder>(suppliesOrderDTO);
            return await _dbClient.postObject(Order1);
        }

    }
}
