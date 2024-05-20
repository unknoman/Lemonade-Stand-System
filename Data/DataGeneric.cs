using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data
{
    public class DataGeneric<T> : IDataGeneric<T> where T : class
    {
        private readonly LemonadeDbContext _dbContext;
        public DataGeneric(LemonadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> getList()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> getObjectType(int oType)
        {
            return await _dbContext.Set<T>().FindAsync(oType);
        }

        public async Task<T?> postObject(T oObject)
        {
            _dbContext.Set<T>().Add(oObject);
            int value = await _dbContext.SaveChangesAsync();
            return value > 0 ? oObject : null;
        }

    }
}
