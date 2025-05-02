using AdisyonApp.Entities;
using System.Linq;

namespace AdisyonApp.Business
{
    public class OrderManager : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderManager()
        {
            _orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            _orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _orders.Find(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Product = order.Product;
                existingOrder.Quantity = order.Quantity;
            }
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.Find(o => o.Id == orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public List<Order> GetOrdersByTable(int tableId)
        {
            return _orders;  // Basit implementasyon, gerçek uygulamada masa ID'ye göre filtreleme yapılmalı
        }

        public decimal CalculateTotalAmount(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == null) return 0;
            return order.Product.Price * order.Quantity;
        }

        public decimal CalculateTableTotal(int tableId)
        {
            return _orders.Sum(o => o.Product.Price * o.Quantity);  // Basit implementasyon
        }
    }
}