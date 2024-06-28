
namespace Models
{
    public class SuppliesOrder
    {
        public int id { get; set; }
        public int supplier { get; set; }

        public DateTime date { get; set; }

        public List<OrderDetail>? oDetail { get; set; }

        public Supplier? oSupplier { get; set; }
    }
}
