using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using BusinessLogic.Services.IServices;

namespace Domain.Controllers
{
    [Route("api/getallproducts")]

    public class ProductController : ControllerBase
    {
        private readonly IApiService _apiService;

        public ProductController(IApiService apiservice)
        {
            _apiService = apiservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            try
            {
                var result = await _apiService.GetAlProducts();
                if (result.success == true)
                {
                    if (result.data == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return new OkObjectResult(result.data);

                    }
                }
                else
                {
                    return new BadRequestObjectResult(result.data);

                }
            }
            catch (Exception ex)

            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpGet("{Id}")]

         
        public async Task<ActionResult<Products>> GetId(int Id)
        {
            try
            {
                var result = await _apiService.GetProductById(Id);
                if (result.success == true)
                {
                    if (result.data == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return new OkObjectResult(result.data);

                    }
                }
                else
                {
                    return new BadRequestObjectResult(result.data);

                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpPost]

        public async Task<ActionResult<Products>> CreateProducts(Products products)
        {
            try
            {
                var result = await _apiService.CreateProduct(products);
                if (result.success == true)
                {
                    if (result.data == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return new OkObjectResult(result.data);

                    }
                }
                else
                {
                    return new BadRequestObjectResult(result.data);

                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpPut]

        public async Task<ActionResult<Products>> UpdateProducts(Products prods)
        {
            try
            {
                var result = await _apiService.UpdateProduct(prods);
                if (result.success == true)
                {
                    if (result.data == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return new OkObjectResult(result.data);

                    }
                }
                else
                {
                    return new BadRequestObjectResult(result.data);

                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<Products>> DeleteProducts(int Id)
        {
            try
            {
                var result = await _apiService.DeleteProduct(Id);
                if (result.success == true)
                {
                    if (result.data == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        return new OkObjectResult(result.data);

                    }
                }
                else
                {
                    return new BadRequestObjectResult(result.data);

                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}











