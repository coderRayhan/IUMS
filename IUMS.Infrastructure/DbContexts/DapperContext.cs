using Dapper;
using IUMS.Application.Interfaces.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.DbContexts
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ApplicationConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<bool> IsExist(
            string tableName, 
            string[] filters, 
            object param = null)
        {
            using var connection = this.CreateConnection();

            StringBuilder sql = new($"SELECT CAST(CASE WHEN EXISTS (SELECT 1 FROM {tableName} WHERE 1 = 1");

            foreach ( var filter in filters )
            {
                sql.Append($" AND {filter} = @{filter}");
            }

            sql.Append(") THEN 1 ELSE 0 END AS BIT )");

            return await connection.ExecuteScalarAsync<bool>(sql.ToString(), param);
        }
    }
}
