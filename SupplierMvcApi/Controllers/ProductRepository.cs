using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Collections.Generic;

namespace SupplierMvcApi.Controllers
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
            string query = @"SELECT Id, Name, SKU, Availability, Supplier
                            FROM products 
                            WHERE *";
            return await _dataService.GetData<ProductModel, dynamic>(query, new { });
        }

        public async Task<ProductModel> GetById(int id)
        {
            string query = $@"SELECT Id, Name, SKU, Availability, Supplier
                            FROM products 
                            WHERE Id=@Id";
            var results = await _dataService.GetData<ProductModel, dynamic>(query, new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<ProductModel> GetByName(string name)
        {
            string query = $@"SELECT Id, Name, SKU, Availability, Supplier
                            FROM products 
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
            string query = $@"INSERT INTO Product 
                            VALUES @Product";

            await _dataService.UpdateData(query, product);
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }



        public void Dispose()
        {
            // TODO: Implement dispose
        }

    }
}