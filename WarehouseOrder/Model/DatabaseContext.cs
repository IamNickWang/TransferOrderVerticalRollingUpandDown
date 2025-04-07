using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;


namespace WarehouseOrder.Model
{
    public class DatabaseContext : DbContext
    {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<erpTransferOrder> erpTransferOrder { get; set; }
        public async Task<List<erpTransferOrder>> LoadData<erptransferOrder>(string sql, string conn)
        {

            using (IDbConnection connection = new SqlConnection(conn))
            {
                var data = await connection.QueryAsync<erpTransferOrder>(sql);

                return data.ToList();
            }

        }

    }
}
