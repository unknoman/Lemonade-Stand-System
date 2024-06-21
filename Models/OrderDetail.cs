
namespace Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int? order { get; set; }
        public int product { get; set; }

        public int? supplies { get; set; }
        public float unityPrice { get; set; }
        public float quantity { get; set; }

        public SuppliesOrder? suppliesOrder { get; set; }
        public ClientOrder? clientOrder { get; set; } 

        public Product oProduct { get; set; } = new Product();

    }
}
