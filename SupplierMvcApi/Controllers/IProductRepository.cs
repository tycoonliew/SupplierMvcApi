using SupplierMvcApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierMvcApi.Controllers
{
    public interface IProductRepository : IDisposable
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> GetById(int id);
        Task<ProductModel> GetByName(string name);

        Task Create(ProductModel product);
        Task Update(int id, ProductModel product);
        Task Delete(int id);
    }

    public interface ISupplierRepository : IDisposable
    {
        Task<IEnumerable<SupplierModel>> GetAll();
        Task<SupplierModel> GetById(int id);
        Task<SupplierModel> GetByName(string name);

        Task Create(SupplierModel supplier);
        Task Update(SupplierModel supplier);
        Task Delete(int id);
    }
}