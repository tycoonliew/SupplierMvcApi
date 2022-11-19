using SupplierMvcApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierMvcApi.DataServices
{
    public interface IDataService
    {
        // Generic function for dapper queries
        Task<IEnumerable<T>> GetData<T, U>(string query, U parameters);
        Task UpdateData<TDataType>(string query, TDataType parameter);
    }
}