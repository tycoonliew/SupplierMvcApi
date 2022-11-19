using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SupplierMvcApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierMvcApi.DataServices
{
    public class SqliteDataService : IDataService
    {
        private readonly IConfiguration _configuration;
        public SqliteDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            SeedDatabase(); // Seed DB at startup
        }

        public async Task<IEnumerable<TDataType>> GetData<TDataType, TParam>(string query, TParam parameters)
        {
            var path = _configuration.GetConnectionString("DefaultConnection");
            using (var dbConnection = new SqliteConnection($"Data Source={path}"))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<TDataType>(query);
                return result;
            }
        }

        public async Task UpdateData<TDataType>(string query, TDataType parameter)
        {
            var path = _configuration.GetConnectionString("DefaultConnection");
            using (var dbConnection = new SqliteConnection($"Data Source={path}"))
            {
                dbConnection.Open();
                int rowsAffected = await dbConnection.ExecuteAsync(query, parameter);
                if (rowsAffected <= 0)
                {
                    Console.WriteLine("No rows affected");
                }
            }
        }

        private void SeedDatabase()
        {
            var path = _configuration.GetConnectionString("DefaultConnection");
            using (var dbConnection = new SqliteConnection($"Data Source={path}"))
            {
                dbConnection.Open();
                string createProductQuery =
                @"
                CREATE TABLE IF NOT EXISTS [Product] 
                (
                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    [Name] NVARCHAR(256) NOT NULL,
                    [SKU] NVARCHAR(64) NOT NULL,
                    [Availability] BOOL NOT NULL,
                    [Supplier] NVARCHAR(256)
                )";

                var productRowsAffected = dbConnection.Execute(createProductQuery);

                string createSupplierQuery =
                @"
                CREATE TABLE IF NOT EXISTS [Supplier] 
                (
                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    [Name] NVARCHAR(256) NOT NULL
                )";

                var supplierResult = dbConnection.Execute(createSupplierQuery);

                Console.WriteLine("Database Seeded");
            }
        }
    }
}