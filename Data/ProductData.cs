
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ProductData
    {
        private readonly LemonadeDbContext _lemonadeDbContext;

        ProductData(LemonadeDbContext lemononadeDbContext)
        {
            _lemonadeDbContext = lemononadeDbContext;
        }


       public async Task<List<Product>> getProduct()
        {

            List<Product> products = await _lemonadeDbContext.Products.ToListAsync();
            return products;

        }




    }
}
