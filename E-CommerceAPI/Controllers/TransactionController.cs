using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using BusinessLogic.Services.IServices;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IApiService _apiService;

        public TransactionController(IApiService apiservice)
        {
            _apiService = apiservice;
        }

        [HttpGet]

        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            try
            {
                var result = await _apiService.GetTransaction();
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

        public async Task<ActionResult<Transaction>> GetById(string Id)
        {
            try
            {
                var result = await _apiService.GetTransById(Id);
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

        public async Task<IActionResult> AddTransactions(Transaction transaction)
        {
            try
            {
                var result = await _apiService.AddTransaction(transaction);
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











