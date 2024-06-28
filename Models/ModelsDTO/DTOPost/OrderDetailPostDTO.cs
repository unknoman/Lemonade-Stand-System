using Models.ModelsDTO.DTOGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOPost
{
    public class OrderDetailPostDTO
    {
        public int product { get; set; }
        public float unityPrice { get; set; }
        public float quantity { get; set; }

    }
}
