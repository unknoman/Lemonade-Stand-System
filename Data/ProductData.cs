
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


        public async Task<bool> postPrudct(Product product)
        {

            try
            {
                _lemonadeDbContext.Products.Add(product);
                await _lemonadeDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ", ex);
                return false;
            }

        }


        public async Task<ProductType?> postPrudctType(ProductType productType)
        {
            _lemonadeDbContext.ProductTypes.Add(productType);
            int countProductType = await _lemonadeDbContext.SaveChangesAsync();
            return countProductType > 0 ? productType :  null;
        }





    }
}
