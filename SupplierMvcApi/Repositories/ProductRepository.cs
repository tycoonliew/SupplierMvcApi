using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Collections.Generic;
using SupplierMvcApi.Repositories;
using System;

namespace SupplierMvcApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataService _dataService;
        public ProductRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            string query = @"SELECT * FROM Product";
            return await _dataService.GetData<ProductModel, dynamic>(query, new { });
        }

        public async Task<ProductModel> GetById(int id)
        {
            string query = $@"SELECT *
                            FROM Product 
                            WHERE Id=@Id";
            var results = await _dataService.GetData<ProductModel, dynamic>(query, new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<ProductModel> GetByName(string name)
        {
            string query = $@"SELECT *
                            FROM Product 
                            WHERE Name=@Name";
            var results = await _dataService.GetData<ProductModel, dynamic>(query, new { Name = name });
            return results.FirstOrDefault();
        }

        public async Task Update(int id, ProductModel product)
        {
            string query = $@"UPDATE Product 
                            SET @Product
                            WHERE Id = @Id";

            await _dataService.UpdateData(query, new { Id = id, Product = product });
        }

        public async Task Create(ProductModel product)
        {
            string query = $@"INSERT INTO Product (Name, SKU, Availability, Supplier)
                            VALUES (@Name, @SKU, @Availability,@Supplier)";

            await _dataService.UpdateData(query,
                new { product.Name, product.Availability, product.SKU, product.Supplier });
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }



        public void Dispose()
        {

        }

    }
}