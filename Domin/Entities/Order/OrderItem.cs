namespace Domin.Entities.Order
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quntity { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}