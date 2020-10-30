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
    public class ProductDAO
    {
        public Response Insert(Product product)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO PRODUCTS (NOME,DESCRICAO,ESTOQUE,MARGEMLUCRO,PRECO,VALIDADE,ISATIVO) VALUES (@NOME,@DESCRICAO,@ESTOQUE,@MARGEMLUCRO,@PRECO,@VALIDADE,@ISATIVO); SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@NOME", product.Name);
            command.Parameters.AddWithValue("@DESCRICAO", product.Description);
            command.Parameters.AddWithValue("@ESTOQUE", product.Storage);
            command.Parameters.AddWithValue("@MARGEMLUCRO", product.ProfitMargin);
            command.Parameters.AddWithValue("@PRECO", product.Price);
            command.Parameters.AddWithValue("@VALIDADE", product.Validity);
            command.Parameters.AddWithValue("@ISATIVO", true);

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

        public Response Update(Product product)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE PRODUCTS SET NOME = @NOME, DESCRICAO = @DESCRICAO, MARGEMLUCRO = @MARGEMLUCRO, PRECO = @PRECO WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", product.Name);
            command.Parameters.AddWithValue("@DESCRICAO", product.Description);
            command.Parameters.AddWithValue("@MARGEMLUCRO", product.ProfitMargin);
            command.Parameters.AddWithValue("@PRECO", product.Price);
            command.Parameters.AddWithValue("@ID", product.ID);

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

        public Response UpdateActiveProduct(Product product)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE PRODUCTS SET ISATIVO = @ISATIVO WHERE ID = @ID";
            command.Parameters.AddWithValue("@ISATIVO", product.IsActive);
            command.Parameters.AddWithValue("@ID", product.ID);

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

        public Response Delete(Product product)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM PRODUCTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", product.ID);

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

        public QueryResponse<Product> GetAllProductsByActive()
        {
            QueryResponse<Product> response = new QueryResponse<Product>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUCTS WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["NOME"];
                    product.Description = (string)reader["DESCRICAO"];
                    product.Storage = (double)reader["ESTOQUE"];
                    product.ProfitMargin = (double)reader["MARGEMLUCRO"];
                    product.Price = (double)reader["PRECO"];
                    product.Validity = (DateTime)reader["VALIDADE"];
                    product.IsActive = (bool)reader["ISATIVO"];
                    products.Add(product);
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

        public QueryResponse<Product> GetAllProductsByInactive()
        {
            QueryResponse<Product> response = new QueryResponse<Product>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUCTS WHERE ATIVO = 0";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["NOME"];
                    product.Description = (string)reader["DESCRICAO"];
                    product.Storage = (double)reader["ESTOQUE"];
                    product.ProfitMargin = (double)reader["MARGEMLUCRO"];
                    product.Price = (double)reader["PRECO"];
                    product.Validity = (DateTime)reader["VALIDADE"];
                    product.IsActive = (bool)reader["ISATIVO"];
                    products.Add(product);
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

        public QueryResponse<Product> GetAllProductsByName(SearchObject search)
        {

            QueryResponse<Product> response = new QueryResponse<Product>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM PRODUCTS WHERE NOME LIKE %NOME% = @NOME";
            command.Parameters.AddWithValue("@NOME", search.SearchName);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["NOME"];
                    product.Description = (string)reader["DESCRICAO"];
                    product.Storage = (double)reader["ESTOQUE"];
                    product.ProfitMargin = (double)reader["MARGEMLUCRO"];
                    product.Price = (double)reader["PRECO"];
                    product.Validity = (DateTime)reader["VALIDADE"];
                    product.IsActive = (bool)reader["ISATIVO"];
                    products.Add(product);

                    products.Add(product);
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

        public SingleResponse<Product> GetById(int id)
        {
            SingleResponse<Product> response = new SingleResponse<Product>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM  PRODUCTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["NOME"];
                    product.Description = (string)reader["DESCRICAO"];
                    product.Storage = (double)reader["ESTOQUE"];
                    product.ProfitMargin = (double)reader["MARGEMLUCRO"];
                    product.Price = (double)reader["PRECO"];
                    product.Validity = (DateTime)reader["VALIDADE"];
                    product.IsActive = (bool)reader["ISATIVO"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = product;
                    return response;
                }
                response.Message = "Funcionário não encontrado.";
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
