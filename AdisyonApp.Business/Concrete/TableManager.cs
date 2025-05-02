using AdisyonApp.Entities;
using AdisyonApp.Business.Abstract;
using System.Linq;

namespace AdisyonApp.Business
{
    public class TableManager : ITableService
    {
        private readonly List<Table> _tables;

        public TableManager()
        {
            // Statik verilerle başlangıç masaları tanımlanıyor
            _tables = new List<Table>()
            {
                new Table { Id = 1, Orders = new List<Order>() },
                new Table { Id = 2, Orders = new List<Order>() },
                new Table { Id = 3, Orders = new List<Order>() }
            };
        }

        // Metotları tek tek ekleyeceğiz...
        public void AddOrder(int tableId, Order order)
        {
            var table = _tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                table.Orders.Add(order);
            }
            else
            {
                Console.WriteLine($"Masa {tableId} bulunamadı.");
            }
        }

        public void RemoveOrder(int tableId, int orderId)
        {
            var table = _tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                var orderToRemove = table.Orders.Find(o => o.Id == orderId);
                if (orderToRemove != null)
                {
                    table.Orders.Remove(orderToRemove);
                }
                else
                {
                    Console.WriteLine($"Sipariş ID {orderId} bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine($"Masa {tableId} bulunamadı..");
            }
        }

        public void UpdateOrder(int tableId, int orderId, int newQuantity)
        {
            var table = _tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                var order = table.Orders.Find(o => o.Id == orderId);
                if (order != null)
                {
                    order.Quantity = newQuantity;
                }
                else
                {
                    Console.WriteLine($"Sipariş ID {orderId} bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine($"Masa {tableId} bulunamadı.");
            }
        }

        public List<Order> GetOrders(int tableId)
        {
            var table = _tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                return table.Orders;
            }
            else
            {
                Console.WriteLine($"Masa {tableId} bulunamadı.");
                return new List<Order>();
            }
        }

        public decimal GetTableTotal(int tableId)
        {
            var table = _tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                return table.Orders.Sum(order => order.Product.Price * order.Quantity);
            }
            else
            {
                Console.WriteLine($"Masa {tableId} bulunamadı.");
                return 0;
            }
        }

        public Dictionary<int, decimal> GetEndOfDayReport()
        {
            var report = new Dictionary<int, decimal>();

            foreach (var table in _tables)
            {
                decimal total = table.Orders.Sum(order => order.Product.Price * order.Quantity);
                report[table.Id] = total;
            }

            // Toplam günlük ciroyu hesapla
            decimal toplamCiro = report.Values.Sum();

            // Konsola yaz
            Console.WriteLine("\n--- Gün Sonu Raporu ---");
            foreach (var entry in report)
            {
                Console.WriteLine($"Masa {entry.Key}: {entry.Value} TL");
            }
            Console.WriteLine($"Toplam Günlük Ciro: {toplamCiro} TL");

            return report;
        }
    }
}