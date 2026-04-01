namespace AcademicManager.Infrastructure.Data 
{
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System.Data;

    public class DbContextSql
    {
        private readonly string _connectionString;

        public DbContextSql(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Falta DefaultConnection en appsettings.json");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}