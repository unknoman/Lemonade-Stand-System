

namespace Models
{
    public class Product
    {
        public int id { get; set; }

        public float unityPrice { get; set; }

        public string? name { get; set; }

        public float stock { get; set; }

        public string? unitMeasure { get; set; }

        public int type { get; set; }
        public ProductType productType { get; set; } = new ProductType();

        public List<OrderDetail>? orderDetails { get; set; }


    }
}
