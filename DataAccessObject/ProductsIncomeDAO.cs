using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using DataAccessObject.Infrastructure;
using Entities.QueryModel;

namespace DataAccessObject
{
    public class ProductsIncomeDAO
    {
        public Response Insert(ProductIncome productIncome)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO PRODUCTS_INCOME (DATAENTRADA, IDFUNCIONARIO, VALORTOTAL, IDFORNECEDOR) VALUES (@DATAENTRADA, @IDFUNCIONARIO, @VALORTOTAL, @IDFORNECEDOR)";
            command.Parameters.AddWithValue("@DATAENTRADA", productIncome.EntryDate);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", productIncome.EmployeesID);
            command.Parameters.AddWithValue("@VALORTOTAL", productIncome.TotalValue);
            command.Parameters.AddWithValue("@IDFORNECEDOR", productIncome.SuppliersID);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o administrador.";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        public Response Update(ProductIncome productIncome)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE CHECKIN_CLIENTS SET DATAENTRADA = @DATAENTRADA, IDFUNCIONARIO = @IDFUNCIONARIO, VALORTOTAL = @VALORTOTAL, IDFORNECEDOR = @IDFORNECEDOR WHERE ID = @ID";
            command.Parameters.AddWithValue("@DATAENTRADA", productIncome.EntryDate);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", productIncome.EmployeesID);
            command.Parameters.AddWithValue("@VALORTOTAL", productIncome.TotalValue);
            command.Parameters.AddWithValue("@IDFORNECEDOR", productIncome.SuppliersID);
            command.Parameters.AddWithValue("@ID", productIncome.ID);

            command.Connection = connection;

            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }

                response.Success = true;
                response.Message = "Atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o administrador.";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncome()
        {
            QueryResponse<ProductIncomeQueryModel> response = new QueryResponse<ProductIncomeQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PI.ID, PI.DATAENTRADA, PI.VALORTOTAL, E.ID, E.NOME, E.CPF, S.RAZAOSOCIAL" +
                                  "S.CNPJ FROM PRODUCTS_INCOME PI INNER JOIN EMPLOYEES E ON PI.IDFUNCIONARIO = E.ID" +
                                  "INNER JOIN SUPPLIERS S ON PI.IDFORNECEDOR = S.ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeQueryModel> products = new List<ProductIncomeQueryModel>();

                while (reader.Read())
                {
                    ProductIncomeQueryModel productIncome = new ProductIncomeQueryModel();
                    productIncome.ProductIncomeID = (int)reader["ID"];
                    productIncome.ProductIncomeEntryDate = (DateTime)reader["DATAENTRADA"];
                    productIncome.ProductIncomeTotalValue = (double)reader["VALORTOTAL"];
                    productIncome.EmployeeID = (int)reader["ID"];
                    productIncome.EmployeeName = (string)reader["NOME"];
                    productIncome.EmployeeCPF = (string)reader["CPF"];
                    productIncome.SupplierCompanyName = (string)reader["RAZAOSOCIAL"];
                    productIncome.SupplierCNPJ = (string)reader["CNPJ"];

                    products.Add(productIncome);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = products;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }

        }

        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebyEntryDate(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> response = new QueryResponse<ProductIncomeQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PI.ID, PI.DATAENTRADA, PI.VALORTOTAL, E.ID, E.NOME, E.CPF, S.RAZAOSOCIAL" +
                                  "S.CNPJ FROM PRODUCTS_INCOME PI INNER JOIN EMPLOYEES E ON PI.IDFUNCIONARIO = E.ID" +
                                  "INNER JOIN SUPPLIERS S ON PI.IDFORNECEDOR = S.ID WHERE PI.DATAENTRADA = @DATAENTRADA";
            command.Parameters.AddWithValue("@DATAENTRADA", search.SearchDate);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeQueryModel> products = new List<ProductIncomeQueryModel>();

                while (reader.Read())
                {
                    ProductIncomeQueryModel productIncome = new ProductIncomeQueryModel();
                    productIncome.ProductIncomeID = (int)reader["ID"];
                    productIncome.ProductIncomeEntryDate = (DateTime)reader["DATAENTRADA"];
                    productIncome.ProductIncomeTotalValue = (double)reader["VALORTOTAL"];
                    productIncome.EmployeeID = (int)reader["ID"];
                    productIncome.EmployeeName = (string)reader["NOME"];
                    productIncome.EmployeeCPF = (string)reader["CPF"];
                    productIncome.SupplierCompanyName = (string)reader["RAZAOSOCIAL"];
                    productIncome.SupplierCNPJ = (string)reader["CNPJ"];

                    products.Add(productIncome);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = products;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }

        }

        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebyEmployeeID(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> response = new QueryResponse<ProductIncomeQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PI.ID, PI.DATAENTRADA, PI.VALORTOTAL, E.ID, E.NOME, E.CPF, S.RAZAOSOCIAL" +
                                  "S.CNPJ FROM PRODUCTS_INCOME PI INNER JOIN EMPLOYEES E ON PI.IDFUNCIONARIO = E.ID" +
                                  "INNER JOIN SUPPLIERS S ON PI.IDFORNECEDOR = S.ID WHERE E.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeQueryModel> products = new List<ProductIncomeQueryModel>();

                while (reader.Read())
                {
                    ProductIncomeQueryModel productIncome = new ProductIncomeQueryModel();
                    productIncome.ProductIncomeID = (int)reader["ID"];
                    productIncome.ProductIncomeEntryDate = (DateTime)reader["DATAENTRADA"];
                    productIncome.ProductIncomeTotalValue = (double)reader["VALORTOTAL"];
                    productIncome.EmployeeID = (int)reader["ID"];
                    productIncome.EmployeeName = (string)reader["NOME"];
                    productIncome.EmployeeCPF = (string)reader["CPF"];
                    productIncome.SupplierCompanyName = (string)reader["RAZAOSOCIAL"];
                    productIncome.SupplierCNPJ = (string)reader["CNPJ"];

                    products.Add(productIncome);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = products;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }

        }

        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebySupplierID(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> response = new QueryResponse<ProductIncomeQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PI.ID, PI.DATAENTRADA, PI.VALORTOTAL, E.ID, E.NOME, E.CPF, S.RAZAOSOCIAL" +
                                  "S.CNPJ FROM PRODUCTS_INCOME PI INNER JOIN EMPLOYEES E ON PI.IDFUNCIONARIO = E.ID" +
                                  "INNER JOIN SUPPLIERS S ON PI.IDFORNECEDOR = S.ID WHERE S.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeQueryModel> products = new List<ProductIncomeQueryModel>();

                while (reader.Read())
                {
                    ProductIncomeQueryModel productIncome = new ProductIncomeQueryModel();
                    productIncome.ProductIncomeID = (int)reader["ID"];
                    productIncome.ProductIncomeEntryDate = (DateTime)reader["DATAENTRADA"];
                    productIncome.ProductIncomeTotalValue = (double)reader["VALORTOTAL"];
                    productIncome.EmployeeID = (int)reader["ID"];
                    productIncome.EmployeeName = (string)reader["NOME"];
                    productIncome.EmployeeCPF = (string)reader["CPF"];
                    productIncome.SupplierCompanyName = (string)reader["RAZAOSOCIAL"];
                    productIncome.SupplierCNPJ = (string)reader["CNPJ"];

                    products.Add(productIncome);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = products;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
