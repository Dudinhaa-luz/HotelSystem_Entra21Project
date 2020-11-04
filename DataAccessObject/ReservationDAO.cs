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
    public class ReservationDAO
    {
        public Response Insert(Reservation reservation)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO RESERVATIONS (DATARESERVA, IDROOMS, IDCLIENTS) VALUES (@DATARESERVA, @IDROOMS, @IDCLIENTS)";
            command.Parameters.AddWithValue("@DATARESERVA", reservation.ReservationDate);
            command.Parameters.AddWithValue("@IDROOMS", reservation.RoomID);
            command.Parameters.AddWithValue("@IDCLIENTS", reservation.ClientID);

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

        public Response Update(Reservation reservation)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE RESERVATION SET DATARESERVA = @DATARESERVA, IDROOMS = @IDROOMS, IDCLIENTS = @IDCLIENTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@DATARESERVA", reservation.ReservationDate);
            command.Parameters.AddWithValue("@IDROOMS", reservation.RoomID);
            command.Parameters.AddWithValue("@IDCLIENTS", reservation.ClientID);
            command.Parameters.AddWithValue("@ID", reservation.ID);

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

        public Response Delete(Reservation reservation)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM RESERVATIONS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", reservation.ID);

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
                response.Message = "Excluído com sucesso.";
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

        public QueryResponse<ProductOutputQueryModel> GetAllReservations()
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

        public QueryResponse<ProductOutputQueryModel> GetAllReservationsbyReservationDate(SearchObject search)
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
