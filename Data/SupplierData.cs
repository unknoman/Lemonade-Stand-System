using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SupplierData
    {
        private readonly LemonadeDbContext _dbContext;
        public SupplierData(LemonadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier?> getSupplier(int id)
        {
            return await _dbContext.Suppliers.FindAsync(id);
        }
    }
}
