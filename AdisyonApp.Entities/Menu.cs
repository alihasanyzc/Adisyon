namespace AdisyonApp.Entities
{
    public class Menu
    {
        // Properties
        public List<Product> Products { get; set; }

        // Constructor
        public Menu(List<Product>? products = null)
        {
            // Eğer products parametresi null ise, yeni bir liste başlat
            Products = products ?? new List<Product>(); 
        }
    }
}