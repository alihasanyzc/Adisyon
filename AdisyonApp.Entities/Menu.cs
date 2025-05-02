namespace AdisyonApp.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Price { get; set; }
    }
}

