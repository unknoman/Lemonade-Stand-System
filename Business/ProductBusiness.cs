using AutoMapper;
using Data;
using Models;
using Models.ModelsDTO.DTOGet;

namespace Business
{
    public class ProductBusiness
    {
        private readonly ProductData _productData;
        private readonly IMapper _mapper;
        public ProductBusiness(ProductData productData, IMapper mapper) {
        
            _productData = productData;
            _mapper = mapper;

        }

        public async Task<List<ProductDTO>> getProduct(int productId)
        {

            List<Product> products = await _productData.getProduct();
            if(productId != 0)
            {
               products = products.Where(p => p.id == productId).ToList();
            }
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }



    }
}