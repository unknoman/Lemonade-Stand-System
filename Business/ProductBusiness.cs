using AutoMapper;
using Data;
using Models;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;

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

        public async Task<List<ProductGetDTO>> getProduct(int productId)
        {

            List<Product> products = await _productData.getProduct();
            if(productId != 0)
            {
               products = products.Where(p => p.id == productId).ToList();
            }
            List<ProductGetDTO> productDTOs = _mapper.Map<List<ProductGetDTO>>(products);
            return productDTOs;
        }


        public async Task<ProductTypeGetDTO?> postPrudctType(ProductTypePostDTO productType)
        {
           ProductType product = _mapper.Map<ProductType>(productType);
           var responseProduct = await _productData.postPrudctType(product);
           ProductTypeGetDTO productTypePostDTO = _mapper.Map<ProductTypeGetDTO>(responseProduct);
           return productTypePostDTO;
        }

    }
}