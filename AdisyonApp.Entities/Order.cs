namespace AdisyonApp.Entities
{
    public class Order
    {
        // Properties
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotalPrice { get; set; }
        public int TableId { get; set; }
        public string Status { get; set; }
        public List<Product> Products { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
