namespace AdisyonApp.Entities
{
    public class Order
    {
        // Properties
        public int OrderId { get; set; }
        public string? OrderName { get; set; }
        public int TotalPrice { get; set; }
        public List<Product> Products { get; set; }

        // Constructor
        public Order(int orderId, string? orderName, int totalPrice, List<Product> products)
        {
            OrderId = orderId;
            OrderName = orderName;
            TotalPrice = totalPrice;
            Products = products ?? new List<Product>(); // Eğer null ise yeni bir liste başlat
        }
    }
}
