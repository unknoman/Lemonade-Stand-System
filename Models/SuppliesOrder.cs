
namespace Models
{
    public class SuppliesOrder
    {
        public int id { get; set; }
        public int supplier { get; set; }

        public DateOnly date { get; set; }

        public List<OrderDetail>? oDetail { get; set; }

        public Supplier? oSupplier { get; set; }
    }
}
