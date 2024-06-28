using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SuppliesData : IData<SuppliesOrder>
    {

        private readonly LemonadeDbContext _dbContext;
        public SuppliesData(LemonadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<SuppliesOrder>> getList()
        {
            return await _dbContext.SuppliesOrders.ToListAsync();
        }

        public async Task<SuppliesOrder?> getObjectType(int oType)
        {
            return await _dbContext.SuppliesOrders.FindAsync(oType);
        }

        public async Task<int?> postObject(SuppliesOrder oObject)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.AddAsync(oObject);
                    await _dbContext.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                    return oObject.id;

                }
                catch (Exception)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw;
                }
            }
        }


    }
}
