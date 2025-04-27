
using AdisyonApp.Entities;

namespace AdisyonApp.Business.Abstract
{
    public interface ITableService
    {
        void CreateTable(Table table);
        void UpdateTable(Table table);
        void DeleteTable(int tableId);
        Table GetTableById(int tableId);
        List<Table> GetAllTables();
        void AddOrderToTable(int tableId, Order order, Menu menu);
        void RemoveOrderFromTable(int tableId, int orderId, Menu menuId);
        void ClearOrderFromTable(int tableId, int orderId);
        double CalculateTableTotalPrice(int tableId);
    }
}