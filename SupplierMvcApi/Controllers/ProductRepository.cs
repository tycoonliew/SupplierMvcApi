using SupplierMvcApi.Models;
using System.Threading.Tasks;

namespace SupplierMvcApi.Controllers
{
    public class ProductRepository : IProductRepository
    {
        public Task Create(ProductModel product)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductModel[]> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductModel> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ProductModel product)
        {
            throw new System.NotImplementedException();
        }
    }
}