using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.RepositoryData.IRepository
{
    public  interface IApiRepository
    {

        Task<ServiceResponse> GetAllProducts(string conString);

        Task<ServiceResponse> GetId(string conString, int Id);

        Task<ServiceResponse> CreateProducts(string conString, Products products);

        Task<ServiceResponse> UpdateProducts(string conString, Products prods);

        Task<ServiceResponse> DeleteProducts(string conString, int Id);

        
        
        
        Task<ServiceResponse> GetAllTransactions(string conString);

        Task<ServiceResponse> GetTransId(string conString, string Id);

        Task<ServiceResponse> AddTransations(string conString, Transaction transaction);

    }
}
