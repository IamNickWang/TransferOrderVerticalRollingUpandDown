using WarehouseOrder.Model;

namespace WarehouseOrder.Service
{
    public class TransferOrderService : ITransferOrder
    {
        private readonly DatabaseContext _dbt;
        private readonly IConfiguration _config;


        public TransferOrderService(DatabaseContext ctx, IConfiguration config)
        {
            _dbt = ctx;
            _config = config;
        }
        public async Task<List<erpTransferOrder>> GetTransferOrders()
        {
            string _conn = _config.GetConnectionString("conn");

            string sql = "SELECT * FROM erp.netsuiteTransferOrder";

            return await _dbt.LoadData<erpTransferOrder>(sql, _conn);

        }
    }
}
