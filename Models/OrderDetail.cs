
namespace Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int order { get; set; }
        public int product { get; set; }

        public int supplier { get; set; }
        public float unityPrice { get; set; }
        public float quantity { get; set; }

        public SupplierOrder supplierOrder { get; set; } = new SupplierOrder();
        public ClientOrder clientOrder { get; set; } = new ClientOrder();

    }
}
