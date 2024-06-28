using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOPost
{
     public class SuppliesOrderPostDTO
    {
        public int supplier { get; set; }

        public DateTime date { get; set; }

        public List<OrderDetailPostDTO>? oDetail { get; set; }



    }
}
