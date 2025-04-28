namespace AdisyonApp.Entities
{
    public class Table
    {
        // Properties
        public int Id { get; set; }
        public string? TableName { get; set; }
        public List<Order>? Orders { get; set; }
        public bool IsOccupied { get; set; } = false; // Set true when order is plac
        public Menu? Menu { get; set; }

        public double TableTotalPrice { get; set; }
        
    }
}
