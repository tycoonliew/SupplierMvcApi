using SupplierMvcApi.Models;

namespace SupplierMvcApi.DataServices
{
    public interface IDataService
    {
        string Get(int id);
        string GetAll();

        string AddProduct(ProductModel product);
    }
}