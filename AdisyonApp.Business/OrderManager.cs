using AdisyonApp.Entities;

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
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            order.Id = _orders.Count + 1;
            order.OrderDate = DateTime.Now;
            _orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder == null)
                throw new ArgumentException("Order not found");

            existingOrder.Products = order.Products;
            existingOrder.TableId = order.TableId;
            existingOrder.Status = order.Status;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
                throw new ArgumentException("Order not found");

            _orders.Remove(order);
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId) 
                ?? throw new ArgumentException("Order not found");
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public List<Order> GetOrdersByTable(int tableId)
        {
            return _orders.Where(o => o.TableId == tableId).ToList();
        }

        public decimal CalculateTotalAmount(int orderId)
        {
            var order = GetOrderById(orderId);
            return order.Products.Sum(p => p.Price);
        }
    }
} 