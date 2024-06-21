using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data
{
    public class ClientData : IData<ClientOrder>
    {
        private readonly LemonadeDbContext _dbContext;
        public ClientData(LemonadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<List<ClientOrder>> getList()
        {
           return await _dbContext.ClientOrders.ToListAsync();
        }

        public async Task<ClientOrder?> getObjectType(int oType)
        {
            return await _dbContext.ClientOrders.FindAsync(oType);
        }

        public async Task<int?> postObject(ClientOrder oObject)
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
