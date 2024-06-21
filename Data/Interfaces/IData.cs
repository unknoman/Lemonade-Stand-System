using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IData<T> 
    {
       public Task<List<T>> getList();

        public Task<int?> postObject(T oObject);

        public Task<T?> getObjectType(int oType);

    }
}
