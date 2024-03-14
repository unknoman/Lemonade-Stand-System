
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ProductData
    {
        private readonly LemonadeDbContext _lemonadeDbContext;

        public ProductData(LemonadeDbContext lemononadeDbContext)
        {
            _lemonadeDbContext = lemononadeDbContext;
        }


       public async Task<List<Product>> getProduct()
        {

            List<Product> products = await _lemonadeDbContext.Products.Include(p => p.productType).ToListAsync();
            return products;

        }




    }
}
