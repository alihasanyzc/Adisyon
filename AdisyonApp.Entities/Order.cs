namespace AdisyonApp.Entities
{
    public class Order
    {
        // Properties
        public int OrderId { get; set; }

        public double OrderTotalPrice { get; set; }
        
        public List<Product> Products { get; set; }



    
    }
}
