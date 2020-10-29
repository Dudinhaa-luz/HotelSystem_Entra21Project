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
using Entities;


namespace DataAccessObject {
    class CheckoutClientDAO {
        public SingleResponse<int> Insert(CheckoutClient checkoutClient) {
            SingleResponse<int> response = new SingleResponse<int>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO CHECKOUT_CLIENTS (SAIDANOPRAZO, MULTA, IDCHECKIN, IDEMPLOYEES) VALUES (@SAIDANOPRAZO, @MULTA, @IDCHECKIN, @IDEMPLOYEES) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@SAIDANOPRAZO", checkoutClient.ExitOnTime);
            command.Parameters.AddWithValue("@MULTA", checkoutClient.Penalty);
            command.Parameters.AddWithValue("@IDCHECKIN", checkoutClient.IDCheckin);
            command.Parameters.AddWithValue("@IDEMPLOYEES", checkoutClient.IDEmployee);

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

        public QueryResponse<CheckoutQueryModel> GetAllCheckouts() {
            QueryResponse<CheckoutQueryModel> response = new QueryResponse<CheckoutQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT CH.ID, CH.DATASAIDA, CH.SAIDANOPRAZO, CH.MULTA, CKIN.DATAENTRADA C.ID, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                                  "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKOUT_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                                  "INNER JOIN ROOMS R ON CHIN.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID";

            command.Connection = connection;

            try {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<CheckoutQueryModel> checkouts = new List<CheckoutQueryModel>();

                while (reader.Read()) {
                    CheckoutQueryModel checkout = new CheckoutQueryModel();
                    checkout.CheckoutID = (int)reader["ID"];
                    checkout.CheckoutExitDate = (DateTime)reader["DATASAIDA"];
                    checkout.CheckoutExitOnTime = (bool)reader["SAIDANOPRAZO"];
                    checkout.CheckoutPenalty = (double)reader["MULTA"];
                    checkout.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkout.ClientID = (int)reader["IDCLIENTS"];
                    checkout.ClientName = (string)reader["NOME"];
                    checkout.ClientCPF = (string)reader["CPF"];
                    checkout.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkout.ClientEmail = (string)reader["EMAIL"];
                    checkout.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkout.EmployeeID = (int)reader["ID"];
                    checkout.EmployeeName = (string)reader["NOME"];

                    checkouts.Add(checkout);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = checkouts;
                return response;
            } catch (Exception ex) {
                response.Success = false;
                response.Message = "Erro no banco de dados contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            } finally {
                connection.Close();
            }

        }

        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByExitDate(SearchObject search) {

            QueryResponse<CheckoutQueryModel> response = new QueryResponse<CheckoutQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATASAIDA, CH.SAIDANOPRAZO, CH.MULTA, CKIN.DATAENTRADA C.ID, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKOUT_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CHIN.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE CH.DATASAIDA = @DATASAIDA";
            command.Parameters.AddWithValue("@DATASAIDA", search.SearchDate);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckoutQueryModel> checkouts = new List<CheckoutQueryModel>();

                while (reader.Read()) {
                    CheckoutQueryModel checkout = new CheckoutQueryModel();
                    checkout.CheckoutID = (int)reader["ID"];
                    checkout.CheckoutExitDate = (DateTime)reader["DATASAIDA"];
                    checkout.CheckoutExitOnTime = (bool)reader["SAIDANOPRAZO"];
                    checkout.CheckoutPenalty = (double)reader["MULTA"];
                    checkout.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkout.ClientID = (int)reader["IDCLIENTS"];
                    checkout.ClientName = (string)reader["NOME"];
                    checkout.ClientCPF = (string)reader["CPF"];
                    checkout.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkout.ClientEmail = (string)reader["EMAIL"];
                    checkout.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkout.EmployeeID = (int)reader["ID"];
                    checkout.EmployeeName = (string)reader["NOME"];

                    checkouts.Add(checkout);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkouts;
                return response;
            } catch (Exception ex) {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            } finally {
                connection.Close();
            }

        }

        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByClientID(SearchObject search) {

            QueryResponse<CheckoutQueryModel> response = new QueryResponse<CheckoutQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATASAIDA, CH.SAIDANOPRAZO, CH.MULTA, CKIN.DATAENTRADA C.ID, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKOUT_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CHIN.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE C.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckoutQueryModel> checkouts = new List<CheckoutQueryModel>();

                while (reader.Read()) {
                    CheckoutQueryModel checkout = new CheckoutQueryModel();
                    checkout.CheckoutID = (int)reader["ID"];
                    checkout.CheckoutExitDate = (DateTime)reader["DATASAIDA"];
                    checkout.CheckoutExitOnTime = (bool)reader["SAIDANOPRAZO"];
                    checkout.CheckoutPenalty = (double)reader["MULTA"];
                    checkout.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkout.ClientID = (int)reader["IDCLIENTS"];
                    checkout.ClientName = (string)reader["NOME"];
                    checkout.ClientCPF = (string)reader["CPF"];
                    checkout.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkout.ClientEmail = (string)reader["EMAIL"];
                    checkout.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkout.EmployeeID = (int)reader["ID"];
                    checkout.EmployeeName = (string)reader["NOME"];

                    checkouts.Add(checkout);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkouts;
                return response;
            } catch (Exception ex) {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            } finally {
                connection.Close();
            }

        }

        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByEmployeeID(SearchObject search) {

            QueryResponse<CheckoutQueryModel> response = new QueryResponse<CheckoutQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT CH.ID, CH.DATASAIDA, CH.SAIDANOPRAZO, CH.MULTA, CKIN.DATAENTRADA C.ID, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "R.NUMEROQUARTO, E.ID, E.NOME FROM CHECKOUT_CLIENTS CH INNER JOIN CLIENTS C ON CH.IDCLIENTS = C.ID" +
                "INNER JOIN ROOMS R ON CHIN.IDROOMS = R.ID INNER JOIN EMPLOYEES E ON CH.IDEMPLOYEES = E.ID WHERE E.ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<CheckoutQueryModel> checkouts = new List<CheckoutQueryModel>();

                while (reader.Read()) {
                    CheckoutQueryModel checkout = new CheckoutQueryModel();
                    checkout.CheckoutID = (int)reader["ID"];
                    checkout.CheckoutExitDate = (DateTime)reader["DATASAIDA"];
                    checkout.CheckoutExitOnTime = (bool)reader["SAIDANOPRAZO"];
                    checkout.CheckoutPenalty = (double)reader["MULTA"];
                    checkout.CheckinEntryDate = (DateTime)reader["DATAENTRADA"];
                    checkout.ClientID = (int)reader["IDCLIENTS"];
                    checkout.ClientName = (string)reader["NOME"];
                    checkout.ClientCPF = (string)reader["CPF"];
                    checkout.ClientPhoneNumber = (string)reader["TELEFONE1"];
                    checkout.ClientEmail = (string)reader["EMAIL"];
                    checkout.RoomNumber = (string)reader["NUMEROQUARTO"];
                    checkout.EmployeeID = (int)reader["ID"];
                    checkout.EmployeeName = (string)reader["NOME"];

                    checkouts.Add(checkout);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = checkouts;
                return response;
            } catch (Exception ex) {
                response.Success = false;
                response.Message = "Erro no banco de dados, contate o adm.";
                response.ExceptionError = ex.Message;
                response.StackTrace = ex.StackTrace;
                return response;
            } finally {
                connection.Close();
            }

        }

    }
}
