using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.RepositoryData.IRepository;
using Dapper;
using Microsoft.Data.SqlClient;



namespace Infrastructure.RepositoryData
{
    public class APIRepository : IApiRepository
    {

             //Product Controller //

        public async Task<ServiceResponse> GetAllProducts(string conString)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"Select * from products";
                var response = await connection.QueryAsync(query);
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };

             
            }


        }

        public async Task<ServiceResponse> GetId(string conString, int Id)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"SELECT * FROM PRODUCTS WHERE id = @id";
                var response = await connection.QueryFirstAsync(query,new { Id = Id });
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };

            }
        }

        public async Task<ServiceResponse> CreateProducts(string conString, Products products)
        {          
                if (string.IsNullOrEmpty(conString))
                {
                    return new ServiceResponse { success = false, message = "Connection String is null" };
                }

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string query = @"INSERT INTO PRODUCTS (Name,Description,Unit,Price)VALUES (@Name,@Description,@Unit,@Price)";
                    var response = await connection.ExecuteAsync(query,products);
                    return new ServiceResponse
                    {
                        success = true,
                        data = response
                    };


                }

        }

        public async Task<ServiceResponse> UpdateProducts(string conString, Products prods)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"UPDATE PRODUCTS SET Name = @Name, Description = @Description, unit = @unit, price = @price  where id = @id ";
                var response = await connection.ExecuteAsync(query, prods);
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };


            }
        }

        public async Task<ServiceResponse> DeleteProducts(string conString, int Id)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"Delete from products where id = @id ";
                var response = await connection.ExecuteAsync(query, new { Id = Id });
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };

            }
        }


               //Transaction Controller//

        public async Task<ServiceResponse> GetAllTransactions(string conString)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"Select * from TRANMAIN";
                var response = await connection.QueryAsync(query);
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };


            }


        }

        public async Task<ServiceResponse> GetTransId(string conString, string Id)
        {
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = @"SELECT * FROM TRANMAIN WHERE id = @id";
                var response = await connection.QueryFirstAsync(query, new { Id = Id });
                return new ServiceResponse
                {
                    success = true,
                    data = response
                };

            }
        }

        public async Task<ServiceResponse> AddTransations (string conString, Transaction transaction)
        {
          
            if (string.IsNullOrEmpty(conString))
            {
                return new ServiceResponse { success = false, message = "Connection String is null" };
            }

            var res = validate(conString, transaction);
          
            if(res.success)
            {

                transaction.Id = getMaxVchrno(conString,transaction.prefix);
                string query = @"insert into Tranmain (Id,transaction_date,PRODUCTCODE,QTY_IN,QTY_OUT,amount,Remarks,prefix) values (@Id,@transaction_date,@PRODUCTCODE,@QTY_IN,@QTY_OUT,@amount,@Remarks,@prefix)";

                using (SqlConnection connection = new SqlConnection(conString))
                {

                    try
                    {
                        var response = await connection.ExecuteAsync(query, transaction);
                        return new ServiceResponse
                        {
                            success = true,
                            data = response
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                    }
            else
            {
                return new ServiceResponse { success = false, message = res.message };
            }
                }


        private  string getMaxVchrno(string constr, string prefix)
        {
            string maxId = string.Empty;
            string VCHRNO = null;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                 maxId =  connection.ExecuteScalar<string>("Select top 1 id from Tranmain where prefix = @prefix order by transaction_date desc ", new {prefix = prefix});
                if (string.IsNullOrEmpty(maxId))
                {
                    maxId = $"{getVoucherType(prefix)}00001";
                    VCHRNO = maxId;
                }
                else
                {
                    
                    int vcrno = Convert.ToInt32(maxId.Split("-")[1]);
                    vcrno++;
                    VCHRNO = VCHRNO = String.Format($"{getVoucherType(prefix)}"+"{0:D5}", vcrno);
                }
                return VCHRNO;
            }
        }

        public ServiceResponse validate(string conString,Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string stock  = @"SELECT SUM(QTY_IN-QTY_OUT) FROM TRANMAIN WHERE PRODUCTCODE=@productcode";
                var currenhtStock = connection.ExecuteScalar<int>(stock, new { productcode = transaction.PRODUCTCODE });

                if (transaction.QTY_OUT > currenhtStock)
                {
                    return new ServiceResponse { success = false, message = "Out Of Stock" };

                }

                else
                {
                    return new ServiceResponse { success = true };
                }
            }
                

        }


        private  string getVoucherType(string prefix) 
        { 
            string vchrtype = string.Empty;
           switch(prefix)
            {
                case "PI":
                    vchrtype = "PI-";
                    break;
                case "TI":
                    vchrtype = "INV-";
                    break;

                default:
                    vchrtype = "Don't Exist";
                    break;
            }
            return vchrtype;
        }

    }
}

