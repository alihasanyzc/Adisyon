namespace AdisyonApp.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
        public DateTime? OccupiedTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
} 