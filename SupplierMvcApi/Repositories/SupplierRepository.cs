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

        public Task<IEnumerable<SupplierModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SupplierModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }


        public Task Create(SupplierModel supplier)
        {
            throw new NotImplementedException();
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