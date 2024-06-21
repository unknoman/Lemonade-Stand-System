using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SuppliesData
    {

        private readonly LemonadeDbContext _dbContext;
        public SuppliesData(LemonadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }




    }
}
