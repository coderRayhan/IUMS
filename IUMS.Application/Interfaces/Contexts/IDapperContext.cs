using System.Data;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Contexts
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
        Task<bool> IsExist(string tableName, string[] filters, object? param = null);
    }
}
