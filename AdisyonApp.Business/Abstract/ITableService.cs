
using AdisyonApp.Entities;

namespace AdisyonApp.Business.Abstract
{
    public interface ITableService
    {
        void AddOrder(int tableId, Order order);
        void RemoveOrder(int tableId, int orderIndex);
        void UpdateOrder(int tableId, int orderIndex, int newQuantity);
        List<Order> GetOrders(int tableId);
        decimal GetTableTotal(int tableId);
        Dictionary<int, decimal> GetEndOfDayReport();
    }
}