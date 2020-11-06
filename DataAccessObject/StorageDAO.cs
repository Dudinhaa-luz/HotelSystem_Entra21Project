using Common;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StorageDAO
    {
        public Response Insert(Storage storage)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO STORAGE (IDPRODUCTS,QUANTIDADE) VALUES (@IDPRODUCTS,@QUANTIDADE)";
            command.Parameters.AddWithValue("@IDPRODUCTS", storage.ProductsID);
            command.Parameters.AddWithValue("@QUANTIDADE", storage.Quantity);

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
        public Response Update(Storage storage)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE STORAGE SET QUANTIDADE = @QUANTIDADE WHERE IDPRODUCTS = @IDPRODUCTS";
            command.Parameters.AddWithValue("@QUANTIDADE", storage.Quantity);
            command.Parameters.AddWithValue("@IDPRODUCTS", storage.ProductsID);

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
        public QueryResponse<Storage> GetAllStorage()
        {
            QueryResponse<Storage> response = new QueryResponse<Storage>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM STORAGE";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Storage> storages = new List<Storage>();

                while (reader.Read())
                {
                    Storage storage = new Storage();
                    storage.ID = (int)reader["ID"];
                    storage.ProductsID = (int)reader["IDPRODUCTS"];
                    storage.Quantity = (double)reader["QUANTIDADE"];
                    storages.Add(storage);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = storages;
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
        public QueryResponse<Storage> GetAllStorageByIDProducts()
        {
            QueryResponse<Storage> response = new QueryResponse<Storage>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM STORAGE WHERE IDPRODUCTS = @IDPRODUCTS";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Storage> storages = new List<Storage>();

                while (reader.Read())
                {
                    Storage storage = new Storage();
                    storage.ID = (int)reader["ID"];
                    storage.ProductsID = (int)reader["IDPRODUCTS"];
                    storage.Quantity = (double)reader["QUANTIDADE"];
                    storages.Add(storage);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
                response.Data = storages;
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
        public SingleResponse<Storage> GetQuantityByIDProducts(ProductIncomeDetail productIncomeDetail)
        {
            SingleResponse<Storage> response = new SingleResponse<Storage>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT QUANTIDADE FROM STORAGE WHERE IDPRODUCTS = @IDPRODUCTS";
            command.Parameters.AddWithValue("@IDPRODUCTS", productIncomeDetail.IDProduct);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Storage storage = new Storage();
                if (!reader.Read())
                {
                    response.Quantity = 0;
                    return response;
                }
                while (reader.Read())
                {
                    response.Quantity = (double)reader["QUANTIDADE"];
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
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
        public SingleResponse<Storage> GetQuantityByIDProductsOutput(ProductOutputDetail productOutputDetail) {
            SingleResponse<Storage> response = new SingleResponse<Storage>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT QUANTIDADE FROM STORAGE WHERE IDPRODUCTS = @IDPRODUCTS";
            command.Parameters.AddWithValue("@IDPRODUCTS", productOutputDetail.IDProduct);

            command.Connection = connection;

            try {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Storage storage = new Storage();
                if (!reader.Read()) {
                    response.Quantity = 0;
                    return response;
                }
                while (reader.Read()) {
                    response.Quantity = (double)reader["QUANTIDADE"];
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso.";
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
        public SingleResponse<Storage> GetById(int id)
        {
            SingleResponse<Storage> response = new SingleResponse<Storage>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM  STORAGE WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Storage storage = new Storage();
                    storage.ID = (int)reader["ID"];
                    storage.ProductsID = (int)reader["IDPRODUCTS"];
                    storage.Quantity = (double)reader["QUANTIDADE"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = storage;
                    return response;
                }
                response.Message = "Estoque não encontrado.";
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
    }
}
