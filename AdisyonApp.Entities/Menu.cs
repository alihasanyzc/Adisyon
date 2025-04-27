namespace AdisyonApp.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string MenuName { get; set; }
        // Properties
        public List<Product> Products { get; set; }

        public double MenuPrice { get; set; }
    }
}

