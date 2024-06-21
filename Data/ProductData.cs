
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
namespace Data
{
    public class ProductData
    {
        private readonly LemonadeDbContext _lemonadeDbContext;
        private readonly ILogger<ProductData> _logger;

        public ProductData(LemonadeDbContext lemononadeDbContext, ILogger<ProductData> logger)
        {
            _lemonadeDbContext = lemononadeDbContext;
            _logger = logger;
        }


        public async Task<List<Product>> getProduct()
        {

            List<Product> products = await _lemonadeDbContext.Products.Include(p => p.productType).ToListAsync();
            return products;

        }

        public async void updateProduct(Product product)
        {
             _lemonadeDbContext.Products.Update(product);
            await _lemonadeDbContext.SaveChangesAsync();
        }

        public async Task<Product?> getProductId(int id)
        {
            return await _lemonadeDbContext.Products.FindAsync(id);
        }


        public async Task<Product?> postProduct(Product product)
        
        {
             _lemonadeDbContext.Products.Add(product);
           int changes =  await _lemonadeDbContext.SaveChangesAsync();
            return changes > 0 ? product : null;
        }


        public async Task<ProductType?> postProductType(ProductType productType)
        {
            _lemonadeDbContext.ProductTypes.Add(productType);
            int countProductType = await _lemonadeDbContext.SaveChangesAsync();
            return countProductType > 0 ? productType :  null;
        }

        public async Task<ProductType?> getProductType(int idProductType)
        {
            ProductType? productType = await _lemonadeDbContext.ProductTypes.FindAsync(idProductType);
            return productType;
        }




    }
}
