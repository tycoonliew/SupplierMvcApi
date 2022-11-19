using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SupplierMvcApi.Models;
using System.IO;
using System.Threading.Tasks;

namespace SupplierMvcApi.DataServices
{
    public class SQLLiteDataService : IDataService
    {
        private readonly SqliteConnection _dbConnection;
        private readonly ConnectionString _connectionString;
        public SQLLiteDataService(ConnectionString connectionString)
        {
            _connectionString = connectionString;

            _dbConnection = new SqliteConnection($"Data Source={connectionString.Value}");
            _dbConnection.Open();
        }

        public string AddProduct(ProductModel product)
        {
            throw new System.NotImplementedException();
        }

        public string Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetAll()
        {
            throw new System.NotImplementedException();
        }

        private async Task SeedDatabase()
        {
            _dbConnection.ExecuteAsync(@"
                CREATE TABLE IF NOT EXISTS [Suppliers] (
                [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                [Name] NVARCHAR(256) NOT NULL,
                [SKU] NVARCHAR(64) NOT NULL,
                [Availability] BOOL NOT NULL,
                [Supplier] 
)
");
        }
    }
}