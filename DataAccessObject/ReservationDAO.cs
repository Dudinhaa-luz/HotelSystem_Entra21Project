using Common;
using Common.Infrastructure;
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
            "INSERT INTO RESERVATIONS (DATARESERVA, DATAPREVISAOSAIDA, IDROOMS, IDCLIENTS) VALUES (@DATARESERVA, @DATAPREVISAOSAIDA, @IDROOMS, @IDCLIENTS)";
            command.Parameters.AddWithValue("@DATARESERVA", reservation.ReservationDate);
            command.Parameters.AddWithValue("@DATAPREVISAOSAIDA", reservation.ExitDatePrevision);
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
                "UPDATE RESERVATIONS SET DATARESERVA = @DATARESERVA, DATAPREVISAOSAIDA = @DATAPREVISAOSAIDA, IDROOMS = @IDROOMS, IDCLIENTS = @IDCLIENTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@DATARESERVA", reservation.ReservationDate);
            command.Parameters.AddWithValue("@DATAPREVISAOSAIDA", reservation.ExitDatePrevision);
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

        public QueryResponse<ReservationQueryModel> GetAllReservations()
        {
            QueryResponse<ReservationQueryModel> response = new QueryResponse<ReservationQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT R.ID, R.DATARESERVA, R.DATAPREVISAOSAIDA, RO.NUMEROQUARTO, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                                  "FROM RESERVATIONS R INNER JOIN ROOMS RO ON R.IDROOMS = RO.ID" +
                                  "INNER JOIN CLIENTS C ON R.IDCLIENTS = C.ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<ReservationQueryModel> reservations = new List<ReservationQueryModel>();

                while (reader.Read())
                {
                    ReservationQueryModel reservation = new ReservationQueryModel();
                    reservation.ReservationID = (int)reader["ID"];
                    reservation.ReservationDate = (DateTime)reader["DATARESERVA"];
                    reservation.ReservationExitDatePrevision = (DateTime)reader["DATAPREVISAOSAIDA"];
                    reservation.RoomNumber = (string)reader["NUMEROQUARTO"];
                    reservation.ClientName = (string)reader["NOME"];
                    reservation.ClientCPF = (string)reader["CPF"];
                    reservation.ClientPhoneNumber = (string)reader["TELEFONE"];
                    reservation.ClientEmail = (string)reader["EMAIL"];

                    reservations.Add(reservation);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = reservations;
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

        public QueryResponse<ReservationQueryModel> GetAllReservationsbyReservationDate(SearchObject search)
        {

            QueryResponse<ReservationQueryModel> response = new QueryResponse<ReservationQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.DATARESERVA, R.DATAPREVISAOSAIDA, RO.NUMEROQUARTO, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "FROM RESERVATIONS R INNER JOIN ROOMS RO ON R.IDROOMS = RO.ID" +
                "INNER JOIN CLIENTS C ON R.IDCLIENTS = C.ID";

            command.Parameters.AddWithValue("@DATARESERVA", search.SearchDate);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ReservationQueryModel> reservations = new List<ReservationQueryModel>();

                while (reader.Read())
                {
                    ReservationQueryModel reservation = new ReservationQueryModel();
                    reservation.ReservationID = (int)reader["ID"];
                    reservation.ReservationDate = (DateTime)reader["DATARESERVA"];
                    reservation.ReservationExitDatePrevision = (DateTime)reader["DATAPREVISAOSAIDA"];
                    reservation.RoomNumber = (string)reader["NUMEROQUARTO"];
                    reservation.ClientName = (string)reader["NOME"];
                    reservation.ClientCPF = (string)reader["CPF"];
                    reservation.ClientPhoneNumber = (string)reader["TELEFONE"];
                    reservation.ClientEmail = (string)reader["EMAIL"];

                    reservations.Add(reservation);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = reservations;
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

        public QueryResponse<ReservationQueryModel> GetAllReservationsByRoomsNumber(SearchObject search)
        {

            QueryResponse<ReservationQueryModel> response = new QueryResponse<ReservationQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.DATARESERVA, R.DATAPREVISAOSAIDA, RO.NUMEROQUARTO, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "FROM RESERVATIONS R INNER JOIN ROOMS RO ON R.IDROOMS = RO.ID" +
                "INNER JOIN CLIENTS C ON R.IDCLIENTS = C.ID";

            command.Parameters.AddWithValue("@NUMEROQUARTO", search.SearchNumberRoom);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ReservationQueryModel> reservations = new List<ReservationQueryModel>();

                while (reader.Read())
                {
                    ReservationQueryModel reservation = new ReservationQueryModel();
                    reservation.ReservationID = (int)reader["ID"];
                    reservation.ReservationDate = (DateTime)reader["DATARESERVA"];
                    reservation.ReservationExitDatePrevision = (DateTime)reader["DATAPREVISAOSAIDA"];
                    reservation.RoomNumber = (string)reader["NUMEROQUARTO"];
                    reservation.ClientName = (string)reader["NOME"];
                    reservation.ClientCPF = (string)reader["CPF"];
                    reservation.ClientPhoneNumber = (string)reader["TELEFONE"];
                    reservation.ClientEmail = (string)reader["EMAIL"];

                    reservations.Add(reservation);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = reservations;
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

        public QueryResponse<ReservationQueryModel> GetAllReservationsbyClientCPF(SearchObject search)
        {

            QueryResponse<ReservationQueryModel> response = new QueryResponse<ReservationQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
               "SELECT R.ID, R.DATARESERVA, R.DATAPREVISAOSAIDA, RO.NUMEROQUARTO, C.NOME, C.CPF, C.TELEFONE1, C.EMAIL" +
                "FROM RESERVATIONS R INNER JOIN ROOMS RO ON R.IDROOMS = RO.ID" +
                "INNER JOIN CLIENTS C ON R.IDCLIENTS = C.ID";

            command.Parameters.AddWithValue("@CPF", search.SearchCPF);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ReservationQueryModel> reservations = new List<ReservationQueryModel>();

                while (reader.Read())
                {
                    ReservationQueryModel reservation = new ReservationQueryModel();
                    reservation.ReservationID = (int)reader["ID"];
                    reservation.ReservationDate = (DateTime)reader["DATARESERVA"];
                    reservation.ReservationExitDatePrevision = (DateTime)reader["DATAPREVISAOSAIDA"];
                    reservation.RoomNumber = (string)reader["NUMEROQUARTO"];
                    reservation.ClientName = (string)reader["NOME"];
                    reservation.ClientCPF = (string)reader["CPF"];
                    reservation.ClientPhoneNumber = (string)reader["TELEFONE"];
                    reservation.ClientEmail = (string)reader["EMAIL"];

                    reservations.Add(reservation);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = reservations;
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
