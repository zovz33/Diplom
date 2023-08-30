using Microsoft.Data.SqlClient;

namespace PrimeTableware.WPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=Производство посуды; Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
