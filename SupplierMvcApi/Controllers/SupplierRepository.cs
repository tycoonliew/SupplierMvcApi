using Microsoft.AspNetCore.Authentication;
using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using System;
using System.Threading.Tasks;

namespace SupplierMvcApi.Controllers
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDataService _dataService;
        public SupplierRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public Task<SupplierModel[]> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<SupplierModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<SupplierModel> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }


        public Task Create(SupplierModel supplier)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(SupplierModel supplier)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}