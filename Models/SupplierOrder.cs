
namespace Models
{
    public class SupplierOrder
    {
        public int id { get; set; }
        public int suplier { get; set; }

        public DateOnly  date { get; set; }

        public List<OrderDetail>? oDetail { get; set; }
    }
}
