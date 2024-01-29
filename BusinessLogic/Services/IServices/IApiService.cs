using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BusinessLogic.Services.IServices
{
    public interface  IApiService
    {
        Task<ServiceResponse> GetAlProducts();

        Task<ServiceResponse> GetProductById(int id);

        Task<ServiceResponse> CreateProduct(Products products);

        Task<ServiceResponse> UpdateProduct(Products prods);

        Task<ServiceResponse> DeleteProduct(int id);



        Task<ServiceResponse> GetTransaction();

        Task<ServiceResponse> GetTransById(string id);

        Task<ServiceResponse> AddTransaction(Transaction transaction);


    }
}
