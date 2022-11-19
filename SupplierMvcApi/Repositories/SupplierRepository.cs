using Microsoft.AspNetCore.Authentication;
using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using SupplierMvcApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierMvcApi.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDataService _dataService;
        public SupplierRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<SupplierModel>> GetAll()
        {
            string query = @"SELECT *
                            FROM Supplier
                            ";
            return await _dataService.GetData<SupplierModel, dynamic>(query, new { });
        }

        public Task<SupplierModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }


        public async Task Create(SupplierModel supplier)
        {
            string query = $@"INSERT
                            INTO Supplier (SupplierName)
                            VALUES (@SupplierName)";

            await _dataService.UpdateData(query,
                new { supplier.SupplierName });
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SupplierModel supplier)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}