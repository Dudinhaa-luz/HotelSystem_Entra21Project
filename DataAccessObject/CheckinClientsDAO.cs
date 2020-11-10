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
    public class CheckinClientsDAO
    {
        public Response Insert(CheckinClient checkinClient)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO CHECKIN_CLIENTS (PREVISAOSAIDA, IDCLIENTS, IDROOMS, IDEMPLOYEES) VALUES (@PREVISAOSAIDA, @IDCLIENTS, @IDROOMS, @IDEMPLOYEES)";
            command.Parameters.AddWithValue("@PREVISAOSAIDA", checkinClient.ExitDate);
            command.Parameters.AddWithValue("@IDCLIENTS", checkinClient.ClientID);
            command.Parameters.AddWithValue("@IDROOMS", checkinClient.RoomID);
            command.Parameters.AddWithValue("@IDEMPLOYEES", checkinClient.EmployeesID);
            command.Parameters.AddWithValue("@ATIVO", true);

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

        public Response Update(CheckinClient checkinClient)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE CHECKIN_CLIENTS SET IDCLIENTS = @IDCLIENTS, IDROOMS = @IDROOMS, IDEMPLOYEES = @IDEMPLOYEES WHERE ID = @ID";
            command.Parameters.AddWithValue("@IDCLIENTS", checkinClient.ClientID);
            command.Parameters.AddWithValue("@IDROOMS", checkinClient.RoomID);
            command.Parameters.AddWithValue("@IDEMPLOYEES", checkinClient.EmployeesID);
            command.Parameters.AddWithValue("@ID", checkinClient.ID);

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

        public QueryResponse<CheckinQueryModel> GetAllCheckins()
        {
            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                                  "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                                  "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = checkins;
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

        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyEntryDate(SearchObject search)
        {

            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE CH.DATAENTRADA = @DATAENTRADA";
                command.Parameters.AddWithValue("@DATAENTRADA", search.SearchDate);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkins;
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

        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyExitDate(SearchObject search)
        {

            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE CH.DATASAIDA = @DATASAIDA";
            command.Parameters.AddWithValue("@DATASAIDA", search.SearchDate);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkins;
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

        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyClientID(SearchObject search)
        {

            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE C.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkins;
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

        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyRoomID(SearchObject search)
        {

            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE R.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkins;
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

        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyEmployeeID(SearchObject search)
        {

            QueryResponse<CheckinQueryModel> response = new QueryResponse<CheckinQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATAENTRADA, CH.PREVISAOSAIDA, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKIN_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CH.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE E.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckinQueryModel> checkins = new List<CheckinQueryModel>();

                while (reader.Read())
                {
                    CheckinQueryModel checkin = new CheckinQueryModel();
                    checkin.CheckinID = (int)reader["ID"];
                    checkin.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkin.CheckinExitDate = (DateTime)reader["PREVISAOSAIDA"];
                    checkin.ClientName = (string)reader["NOME"];
                    checkin.ClientCPF = (string)reader["CPF"];
                    checkin.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkin.ClientEmail = (string)reader["EMAIL"];
                    checkin.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkin.EmployeeID = (int)reader["ID"];
                    checkin.EmployeeName = (string)reader["NOME"];

                    checkins.Add(checkin);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkins;
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
