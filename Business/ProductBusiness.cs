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

        public async Task<List<ProductDTO>> getProduct(int producto)
        {

            List<Product> products = await _productData.getProduct();
            if(producto != 0)
            {
                products.Where(p => p.id == producto);
            }
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }



    }
}