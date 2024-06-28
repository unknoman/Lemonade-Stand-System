using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SupplierBusiness
    {

        private readonly SupplierData _supplierData;

        public SupplierBusiness(SupplierData supplierData)
        {
            _supplierData = supplierData;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
           Supplier? supplier = await _supplierData.getSupplier(id);
            if (supplier != null)
                return supplier;
            throw new KeyNotFoundException("Supplier not found");
        }

    }
}
