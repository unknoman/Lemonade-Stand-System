using Models.ModelsDTO.DTOGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOPost
{
    public class ClientOrderPostDTO
    {
        public DateTime date { get; set; } = System.DateTime.Now;

        public List<OrderDetailPostDTO>? orderDetails { get; set; }
    }
}
