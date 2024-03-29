using AutoMapper;
using Data;
using Models;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;
using System.ComponentModel.DataAnnotations;

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
            if(productDTOs.Count == 0 && productId != 0)
                throw new KeyNotFoundException("Product not found with the specified ID.");
            return productDTOs;
        }


        public async Task<ProductTypeGetDTO?> postProductType(ProductTypePostDTO productType)
        {
           ProductType product = _mapper.Map<ProductType>(productType);
           var responseProduct = await _productData.postProductType(product);
           ProductTypeGetDTO productTypePostDTO = _mapper.Map<ProductTypeGetDTO>(responseProduct);
           return productTypePostDTO;
        }

        public async Task<ProductPostDTO?> postProduct(ProductPostDTO oProduct)
        {
            ProductType? productType = await _productData.getProductType(oProduct.type);
            if (productType == null) throw new ValidationException("You must enter a valid product type.");
            Product product = _mapper.Map<Product>(oProduct);
            product.productType = productType;
            var responseProduct = await _productData.postProduct(product);
            ProductPostDTO productPostDTO = _mapper.Map<ProductPostDTO>(responseProduct);
            return productPostDTO;
        }


    }
}