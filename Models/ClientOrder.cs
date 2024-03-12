namespace Models
{
    public class ClientOrder
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }
    }
}