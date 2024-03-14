using Data;
using Models;

namespace Business
{
    public class ProductBusiness
    {
        private readonly ProductData _productData;
        public ProductBusiness(ProductData productData) {
        
            _productData = productData;
        
        }

        public async Task<List<Product>> getProduct(int producto)
        {

            List<Product> products = await _productData.getProduct();
            if(producto != 0)
            {
                products.Where(p => p.id == producto);
            }
            return products;
        }



    }
}