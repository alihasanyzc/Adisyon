namespace AdisyonApp.Entities
{
    public class Table
    {
        // Properties
        public int Id { get; set; }
        public string? TableName { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsOccupied { get; set; } = false; // Set true when order is placed

        // Constructor
        public Table(int id, string? tableName)
        {
            Id = id;
            TableName = tableName;
            Orders = new List<Order>(); // Başlangıçta boş bir sipariş listesi
        }
    }
}
