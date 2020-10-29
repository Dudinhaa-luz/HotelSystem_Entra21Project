using Common;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
    public class RoomDAO {

        public Response Insert(Room room) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO ROOMS (ISOCUPADO, NUMEROQUARTO, IDROOMS_TYPE) VALUES(@ISOCUPADO, @NUMEROQUARTO, @IDROOMS_TYPE)";
            command.Parameters.AddWithValue("@ISOCUPADO", room.IsAvailable);
            command.Parameters.AddWithValue("@NUMEROQUARTO", room.NumberRoom);
            command.Parameters.AddWithValue("@IDROOMS_TYPE", room.IDRoomType);

            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Adicionado com sucesso.";
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

        public Response UpdateOcuppyRoom(Room room) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE ROOMS SET ISOCUPADO = @ISOCUPADO  WHERE ID = @ID";
            command.Parameters.AddWithValue("@ISOCUPADO", room.IsAvailable);
            command.Parameters.AddWithValue("@ID", room.ID);

            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Atualizado com sucesso.";
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

        public QueryResponse<Room> GetAllRoomsAvailable() {
            QueryResponse<Room> response = new QueryResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM ROOMS WHERE ISOCUPADO = 1";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Room> rooms = new List<Room>();

                while (reader.Read()) {
                    Room room = new Room();
                    room.ID = (int)reader["ID"];
                    room.NumberRoom = (string)reader["NUMEROQUARTO"];
                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];
                    room.IsAvailable = (bool)reader["ISOCUPADO"];

                    rooms.Add(room);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = rooms;
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

        public QueryResponse<Room> GetAllRoomsOccupy() {
            QueryResponse<Room> response = new QueryResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM ROOMS WHERE ISOCUPADO = 0";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Room> rooms = new List<Room>();

                while (reader.Read()) {
                    Room room = new Room();
                    room.ID = (int)reader["ID"];
                    room.NumberRoom = (string)reader["NUMEROQUARTO"];
                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];
                    room.IsAvailable = (bool)reader["ISOCUPADO"];

                    rooms.Add(room);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = rooms;
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

        public QueryResponse<Room> GetAllRoomsByNumberRoom(SearchObject search) {
            QueryResponse<Room> response = new QueryResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM ROOMS WHERE NUMEROQUARTO = @NUMEROQUARTO";
            command.Parameters.AddWithValue("@NUMEROQUARTO", search.SearchNumberRoom);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Room> rooms = new List<Room>();

                while (reader.Read()) {
                    Room room = new Room();
                    room.ID = (int)reader["ID"];
                    room.NumberRoom = (string)reader["NUMEROQUARTO"];
                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];
                    room.IsAvailable = (bool)reader["ISOCUPADO"];

                    rooms.Add(room);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = rooms;
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

        public SingleResponse<Room> GetById(int id) {
            SingleResponse<Room> response = new SingleResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM  ROOMS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    Room room = new Room();
                    room.ID = (int)reader["ID"];
                    room.NumberRoom = (string)reader["NUMEROQUARTO"];
                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];
                    room.IsAvailable = (bool)reader["ISOCUPADO"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = room;
                    return response;
                }
                response.Message = "Quarto não encontrado.";
                response.Success = false;
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
