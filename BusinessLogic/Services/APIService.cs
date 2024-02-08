using BusinessLogic.Services.IServices;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.RepositoryData.IRepository;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace BusinessLogic.Services
{
    public class APIService : IApiService

    {

        private readonly IApiRepository _repository;
        private readonly IConfiguration _configuration;

        public APIService(IApiRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }


        public async Task<ServiceResponse> GetAlProducts()
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.GetAllProducts(conString);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> GetProductById(int Id)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.GetId(conString, Id);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }

                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> CreateProduct(Products products)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.CreateProducts(conString,products);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> UpdateProduct(Products prods)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.UpdateProducts(conString, prods);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> DeleteProduct(int Id)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.DeleteProducts(conString, Id);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> GetTransaction()
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.GetAllTransactions(conString);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }
        
        public async Task<ServiceResponse> GetTransById(string Id)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");
                var result = await _repository.GetTransId(conString, Id);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }

                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

        public async Task<ServiceResponse> AddTransaction(Transaction transaction)
        {
            try
            {
                var conString = _configuration.GetConnectionString("DefaultConnection");

                var result = await _repository.AddTransations(conString, transaction);
                if (result == null)
                {
                    return new ServiceResponse { success = true, message = "no data", data = new object() };
                }
                return new ServiceResponse { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    success = false,
                    message = ex.Message,
                };

            }
        }

      
    }
}