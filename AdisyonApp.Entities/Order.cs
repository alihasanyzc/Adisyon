namespace AdisyonApp.Entities
{
    public class Order
    {
        public int Id {get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
