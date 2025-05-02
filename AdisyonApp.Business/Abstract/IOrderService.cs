using AdisyonApp.Entities;

namespace AdisyonApp.Business
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        Order GetOrderById(int orderId);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByTable(int tableId);
        decimal CalculateTotalAmount(int orderId);
        decimal CalculateTableTotal(int tableId);
    }
} 