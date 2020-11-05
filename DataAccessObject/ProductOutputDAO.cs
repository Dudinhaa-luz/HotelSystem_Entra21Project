using Common;
using DataAccessObject.Infrastructure;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductOutputDAO
    {
        public SingleResponse<int> Insert(ProductOutput productOutput)
        {
            SingleResponse<int> response = new SingleResponse<int>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO PRODUCTS_OUTPUT (DATASAIDA, IDFUNCIONARIO, VALORTOTAL, IDCLIENTE) VALUES (@DATASAIDA, @IDFUNCIONARIO, @VALORTOTAL, @IDCLIENTE) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@DATASAIDA", productOutput.ExitDate);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", productOutput.EmployeeID);
            command.Parameters.AddWithValue("@VALORTOTAL", productOutput.TotalValue);
            command.Parameters.AddWithValue("@IDCLIENTE", productOutput.ClientID);

            command.Connection = connection;

            try
            {
                connection.Open();
                int idGerado = Convert.ToInt32(command.ExecuteScalar());
                response.Success = true;
                response.Message = "Cadastrado com sucesso.";
                response.Data = idGerado;

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

        public SingleResponse<int> InsertProductOutputDetail(ProductOutputDetail productOutputDetail) {
            SingleResponse<int> response = new SingleResponse<int>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO PRODUCTS_OUTPUT_DETAILS (IDPRODUCTS_OUTPUT, IDPRODUCTS, PRECO, QUANTIDADE) VALUES (@IDPRODUCTS_OUTPUT, @IDPRODUCTS, @PRECO, @QUANTIDADE) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@IDPRODUCTS_OUTPUT", productOutputDetail.IDProductOutput);
            command.Parameters.AddWithValue("@IDPRODUCTS", productOutputDetail.IDProduct);
            command.Parameters.AddWithValue("@PRECO", productOutputDetail.Price);
            command.Parameters.AddWithValue("@QUANTIDADE", productOutputDetail.Quantity);

            command.Connection = connection;

            try {
                connection.Open();
                int idGerado = Convert.ToInt32(command.ExecuteScalar());
                response.Success = true;
                response.Message = "Cadastrado com sucesso.";
                response.Data = idGerado;
            } catch (Exception ex) {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o administrador.";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            } finally {
                connection.Close();
            }
            return response;
        }

        public Response Update(ProductOutput productOutput)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE PRODUCT_OUTPUT SET DATASAIDA = @DATASAIDA, IDFUNCIONARIO = @IDFUNCIONARIO, VALORTOTAL = @VALORTOTAL, IDFORNECEDORES = @IDCLIENTE WHERE ID = @ID";
            command.Parameters.AddWithValue("@DATASAIDA", productOutput.ExitDate);
            command.Parameters.AddWithValue("@IDFUNCIONARIO", productOutput.EmployeeID);
            command.Parameters.AddWithValue("@VALORTOTAL", productOutput.TotalValue);
            command.Parameters.AddWithValue("@IDCLIENTE", productOutput.ClientID);
            command.Parameters.AddWithValue("@ID", productOutput.ID);

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

        public QueryResponse<ProductOutputQueryModel> GetAllProductOutput()
        {
            QueryResponse<ProductOutputQueryModel> response = new QueryResponse<ProductOutputQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PO.ID, PO.DATASAIDA, PO.VALORTOTAL, E.ID, E.NOME, E.CPF, C.NOME" +
                                  "C.CPF FROM PRODUCTS_OUTPUT PO INNER JOIN EMPLOYEES E ON PO.IDFUNCIONARIO = E.ID" +
                                  "INNER JOIN CLIENTS C ON PO.IDCLIENTE = C.ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<ProductOutputQueryModel> products = new List<ProductOutputQueryModel>();

                while (reader.Read())
                {
                    ProductOutputQueryModel productOutput = new ProductOutputQueryModel();
                    productOutput.ProductOutputID = (int)reader["ID"];
                    productOutput.ProductOutputExitDate = (DateTime)reader["DATASAIDA"];
                    productOutput.ProductOutputTotalValue = (double)reader["VALORTOTAL"];
                    productOutput.EmployeeID = (int)reader["ID"];
                    productOutput.EmployeeName = (string)reader["NOME"];
                    productOutput.EmployeeCPF = (string)reader["CPF"];
                    productOutput.ClientName = (string)reader["RAZAOSOCIAL"];
                    productOutput.ClientCPF = (string)reader["CNPJ"];

                    products.Add(productOutput);
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

        public QueryResponse<ProductOutputQueryModel> GetAllProductOutputbyExityDate(SearchObject search)
        {

            QueryResponse<ProductOutputQueryModel> response = new QueryResponse<ProductOutputQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PO.ID, PO.DATASAIDA, PO.VALORTOTAL, E.ID, E.NOME, E.CPF, C.NOME" +
                "C.CPF FROM PRODUCTS_OUTPUT PO INNER JOIN EMPLOYEES E ON PO.IDFUNCIONARIO = E.ID" +
                "INNER JOIN CLIENTS C ON PO.IDCLIENTE = C.ID WHERE PO.DATASAIDA = @DATASAIDA";

            command.Parameters.AddWithValue("@DATASAIDA", search.SearchDate);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductOutputQueryModel> products = new List<ProductOutputQueryModel>();

                while (reader.Read())
                {
                    ProductOutputQueryModel productOutput = new ProductOutputQueryModel();
                    productOutput.ProductOutputID = (int)reader["ID"];
                    productOutput.ProductOutputExitDate = (DateTime)reader["DATASAIDA"];
                    productOutput.ProductOutputTotalValue = (double)reader["VALORTOTAL"];
                    productOutput.EmployeeID = (int)reader["ID"];
                    productOutput.EmployeeName = (string)reader["NOME"];
                    productOutput.EmployeeCPF = (string)reader["CPF"];
                    productOutput.ClientName = (string)reader["RAZAOSOCIAL"];
                    productOutput.ClientCPF = (string)reader["CNPJ"];

                    products.Add(productOutput);
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

        public QueryResponse<ProductOutputQueryModel> GetAllProductOutputbyEmployeeID(SearchObject search)
        {

            QueryResponse<ProductOutputQueryModel> response = new QueryResponse<ProductOutputQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PO.ID, PO.DATASAIDA, PO.VALORTOTAL, E.ID, E.NOME, E.CPF, C.NOME" +
                "C.CPF FROM PRODUCTS_OUTPUT PO INNER JOIN EMPLOYEES E ON PO.IDFUNCIONARIO = E.ID" +
                "INNER JOIN CLIENTS C ON PO.IDCLIENTE = C.ID WHERE E.ID = @ID";

            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductOutputQueryModel> products = new List<ProductOutputQueryModel>();

                while (reader.Read())
                {
                    ProductOutputQueryModel productOutput = new ProductOutputQueryModel();
                    productOutput.ProductOutputID = (int)reader["ID"];
                    productOutput.ProductOutputExitDate = (DateTime)reader["DATASAIDA"];
                    productOutput.ProductOutputTotalValue = (double)reader["VALORTOTAL"];
                    productOutput.EmployeeID = (int)reader["ID"];
                    productOutput.EmployeeName = (string)reader["NOME"];
                    productOutput.EmployeeCPF = (string)reader["CPF"];
                    productOutput.ClientName = (string)reader["RAZAOSOCIAL"];
                    productOutput.ClientCPF = (string)reader["CNPJ"];

                    products.Add(productOutput);
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

        public QueryResponse<ProductOutputQueryModel> GetAllProductOutputbyClientID(SearchObject search)
        {

            QueryResponse<ProductOutputQueryModel> response = new QueryResponse<ProductOutputQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT PO.ID, PO.DATASAIDA, PO.VALORTOTAL, E.ID, E.NOME, E.CPF, C.NOME" +
                "C.CPF FROM PRODUCTS_OUTPUT PO INNER JOIN EMPLOYEES E ON PO.IDFUNCIONARIO = E.ID" +
                "INNER JOIN CLIENTS C ON PO.IDCLIENTE = C.ID  WHERE C.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

                List<ProductOutputQueryModel> products = new List<ProductOutputQueryModel>();

                while (reader.Read())
                {
                    ProductOutputQueryModel productOutput = new ProductOutputQueryModel();
                    productOutput.ProductOutputID = (int)reader["ID"];
                    productOutput.ProductOutputExitDate = (DateTime)reader["DATASAIDA"];
                    productOutput.ProductOutputTotalValue = (double)reader["VALORTOTAL"];
                    productOutput.EmployeeID = (int)reader["ID"];
                    productOutput.EmployeeName = (string)reader["NOME"];
                    productOutput.EmployeeCPF = (string)reader["CPF"];
                    productOutput.ClientName = (string)reader["RAZAOSOCIAL"];
                    productOutput.ClientCPF = (string)reader["CNPJ"];

                    products.Add(productOutput);
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
