using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDataGeneric<T> where T  : class
    {
        Task<List<T>> getList();

        Task<T?> postObject(T oObject);

        Task<T?> getObjectType(int oType);

    }
}
