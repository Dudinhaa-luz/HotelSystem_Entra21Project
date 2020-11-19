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

namespace DataAccessObject {
    public class RoomDAO {

        public SingleResponse<int> Insert(Room room) {
            SingleResponse<int> response = new SingleResponse<int>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO ROOMS (ISOCUPADO, NUMEROQUARTO, IDROOMS_TYPE) VALUES(@ISOCUPADO, @NUMEROQUARTO, @IDROOMS_TYPE) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@ISOCUPADO", false);
            command.Parameters.AddWithValue("@NUMEROQUARTO", room.NumberRoom);
            command.Parameters.AddWithValue("@IDROOMS_TYPE", room.IDRoomType);

            command.Connection = connection;

            try {
                connection.Open();
                int idGerado = Convert.ToInt32(command.ExecuteScalar());
                response.Success = true;
                response.Message = "Adicionado com sucesso.";
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

        public Response UpdateOcuppyRoom(Room room) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE ROOMS SET ISOCUPADO = @ISOCUPADO  WHERE ID = @ID";
            command.Parameters.AddWithValue("@ISOCUPADO", true);
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

        public QueryResponse<RoomQueryModel> GetAllRoomsAvailable() {
            QueryResponse<RoomQueryModel> response = new QueryResponse<RoomQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.NUMEROQUARTO, RT.DESCRICAO, RT.VALORDIARIA, " +
                "RT.QTDHOSPEDES FROM ROOMS R INNER JOIN ROOMS_TYPE RT ON " +
                "R.IDROOM_TYPE = RT.ID WHERE R.ISOCUPADO = 1";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<RoomQueryModel> rooms = new List<RoomQueryModel>();

                while (reader.Read()) {
                    RoomQueryModel room = new RoomQueryModel();
                    room.RoomID = (int)reader["ID"];
                    room.RoomNumber = (string)reader["NUMEROQUARTO"];
                    room.TypeRoomDescription = (string)reader["DESCRICAO"];
                    room.TypeRoomDailyValue = (double)reader["VALORDIARIA"];
                    room.TypeRoomGuestNumber = (int)reader["QTDHOSPEDES"];


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

        public QueryResponse<RoomQueryModel> GetAllRoomsOccupy() {
            QueryResponse<RoomQueryModel> response = new QueryResponse<RoomQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.NUMEROQUARTO, RT.DESCRICAO, RT.VALORDIARIA, " +
                "RT.QTDHOSPEDES FROM ROOMS R INNER JOIN ROOMS_TYPE RT ON " +
                "R.IDROOM_TYPE = RT.ID WHERE R.ISOCUPADO = 0";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<RoomQueryModel> rooms = new List<RoomQueryModel>();

                while (reader.Read()) {
                    RoomQueryModel room = new RoomQueryModel();
                    room.RoomID = (int)reader["ID"];
                    room.RoomNumber = (string)reader["NUMEROQUARTO"];
                    room.TypeRoomDescription = (string)reader["DESCRICAO"];
                    room.TypeRoomDailyValue = (double)reader["VALORDIARIA"];
                    room.TypeRoomGuestNumber = (int)reader["QTDHOSPEDES"];

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

        public QueryResponse<RoomQueryModel> GetAllRoomsByNumberRoom(SearchObject search) {
            QueryResponse<RoomQueryModel> response = new QueryResponse<RoomQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.NUMEROQUARTO, R.ISOCUPADO, RT.DESCRICAO, RT.VALORDIARIA, " +
                "RT.QTDHOSPEDES FROM ROOMS R INNER JOIN ROOMS_TYPE RT ON " +
                "R.IDROOM_TYPE = RT.ID WHERE R.NUMEROQUARTO LIKE %NUMEROQUARTO% = @NUMEROQUARTO";

            command.Parameters.AddWithValue("@NUMEROQUARTO", search.SearchNumberRoom);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<RoomQueryModel> rooms = new List<RoomQueryModel>();

                while (reader.Read()) {
                    RoomQueryModel room = new RoomQueryModel();
                    room.RoomID = (int)reader["ID"];
                    room.RoomNumber = (string)reader["NUMEROQUARTO"];
                    room.RoomIsOcuppy = (bool)reader["ISOCUPADO"];
                    room.TypeRoomDescription = (string)reader["DESCRICAO"];
                    room.TypeRoomDailyValue = (double)reader["VALORDIARIA"];
                    room.TypeRoomGuestNumber = (int)reader["QTDHOSPEDES"];

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

        public QueryResponse<RoomQueryModel> GetAllOccuppyRoomsByNumberRoom(SearchObject search) {
            QueryResponse<RoomQueryModel> response = new QueryResponse<RoomQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.NUMEROQUARTO, R.ISOCUPADO, RT.DESCRICAO, RT.VALORDIARIA, " +
                "RT.QTDHOSPEDES FROM ROOMS R INNER JOIN ROOMS_TYPE RT ON " +
                "R.IDROOM_TYPE = RT.ID WHERE R.NUMEROQUARTO LIKE NUMEROQUARTO = @NUMEROQUARTO AND R.ISOCUPADO = 1";

            command.Parameters.AddWithValue("@NUMEROQUARTO", "%" + search.SearchNumberRoom + "%");
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<RoomQueryModel> rooms = new List<RoomQueryModel>();

                while (reader.Read()) {
                    RoomQueryModel room = new RoomQueryModel();
                    room.RoomID = (int)reader["ID"];
                    room.RoomNumber = (string)reader["NUMEROQUARTO"];
                    room.RoomIsOcuppy = (bool)reader["ISOCUPADO"];
                    room.TypeRoomDescription = (string)reader["DESCRICAO"];
                    room.TypeRoomDailyValue = (double)reader["VALORDIARIA"];
                    room.TypeRoomGuestNumber = (int)reader["QTDHOSPEDES"];

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


        public SingleResponse<RoomQueryModel> GetById(int id) {
            SingleResponse<RoomQueryModel> response = new SingleResponse<RoomQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT R.ID, R.NUMEROQUARTO, R.ISOCUPADO, RT.DESCRICAO, RT.VALORDIARIA, " +
                "RT.QTDHOSPEDES FROM ROOMS R INNER JOIN ROOMS_TYPE RT ON " +
                "R.IDROOM_TYPE = RT.ID WHERE R.ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    RoomQueryModel room = new RoomQueryModel();

                    room.RoomID = (int)reader["ID"];
                    room.RoomNumber = (string)reader["NUMEROQUARTO"];
                    room.RoomIsOcuppy = (bool)reader["ISOCUPADO"];
                    room.TypeRoomDescription = (string)reader["DESCRICAO"];
                    room.TypeRoomDailyValue = (double)reader["VALORDIARIA"];
                    room.TypeRoomGuestNumber = (int)reader["QTDHOSPEDES"];

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

        public SingleResponse<Room> GetRoomTypeIDByRoomID(int id)
        {
            SingleResponse<Room> response = new SingleResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT IDROOMS_TYPE WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Room room = new Room();

                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];
                    
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = room;
                    return response;
                }
                response.Message = "Quarto não encontrado.";
                response.Success = false;
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

        public SingleResponse<Room> GetRoomTypeIDByDescription(string description)
        {
            SingleResponse<Room> response = new SingleResponse<Room>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT IDROOMS_TYPE WHERE DESCRICAO = @DESCRICAO";
            command.Parameters.AddWithValue("@DESCRICAO", description);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Room room = new Room();

                    room.IDRoomType = (int)reader["IDROOMS_TYPE"];

                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = room;
                    return response;
                }
                response.Message = "Quarto não encontrado.";
                response.Success = false;
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
        public QueryResponse<RoomType> GetRoomTypeDescription()
        {
            QueryResponse<RoomType> response = new QueryResponse<RoomType>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT ID, DESCRICAO FROM ROOMS_TYPE";
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<RoomType> rooms = new List<RoomType>();

                while (reader.Read())
                {
                    RoomType room = new RoomType();
                    room.Description = (string)reader["DESCRICAO"];
                    room.ID = (int)reader["ID"];
                    rooms.Add(room);
                }
                response.Data = rooms;
                
                response.Success = true;
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
