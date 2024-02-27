using System.Data;

namespace IUMS.Application.Interfaces.Contexts
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
