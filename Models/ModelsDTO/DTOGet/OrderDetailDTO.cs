using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOGet
{
    public class OrderDetailDTO
    {

        public int order { get; set; }
        public int product { get; set; }

        public int supplies { get; set; }
        public float unityPrice { get; set; }
        public float quantity { get; set; }

        public ClientOrderDTO clientOrder { get; set; } = new ClientOrderDTO();

        public ProductDTO oProduct { get; set; } = new ProductDTO();

    }
}
