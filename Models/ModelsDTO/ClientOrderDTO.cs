using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO
{
    public class ClientOrderDTO
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        public List<OrderDetailDTO>? orderDetails { get; set; }
    }
}
