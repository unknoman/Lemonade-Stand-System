using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO
{
    public class ProductDTO
    {
        public string? name { get; set; }
        public float unityPrice { get; set; }

        public float stock { get; set; }

        public string? unitMeasure { get; set; }

        public int type { get; set; }
        public ProductTypeDTO productType { get; set; } = new ProductTypeDTO();
    }
}
