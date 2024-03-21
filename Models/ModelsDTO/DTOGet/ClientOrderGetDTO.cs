using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOGet
{
    public class ClientOrderGetDTO
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        public List<OrderDetailGetDTO>? orderDetails { get; set; }
    }
}
