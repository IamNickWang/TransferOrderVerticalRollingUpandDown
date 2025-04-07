using WarehouseOrder.Model;

namespace WarehouseOrder.Service
{
    public interface ITransferOrder
    {
        Task<List<erpTransferOrder>> GetTransferOrders();
    }
}
