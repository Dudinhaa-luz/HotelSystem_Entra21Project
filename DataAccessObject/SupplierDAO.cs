using Common;
using Common.Infrastructure;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
    public class SupplierDAO {
        public SingleResponse<int> Insert(Supplier supplier) {
            SingleResponse<int> response = new SingleResponse<int>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO SUPPLIERS (RAZAOSOCIAL, CNPJ, NOMECONTATO, TELEFONE, EMAIL, ISATIVO) VALUES(@RAZAOSOCIAL, @CNPJ, @NOMECONTATO, @TELEFONE, @EMAIL, @ISATIVO) SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@RAZAOSOCIAL", supplier.CompanyName);
            command.Parameters.AddWithValue("@CNPJ", supplier.CNPJ);
            command.Parameters.AddWithValue("@NOMECONTATO", supplier.ContactName);
            command.Parameters.AddWithValue("@TELEFONE", supplier.PhoneNumber);
            command.Parameters.AddWithValue("@EMAIL", supplier.Email);
            command.Parameters.AddWithValue("@ISATIVO", supplier.IsActive);

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

        public Response InsertProducts(int idProducts, int idSuppliers) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
            "INSERT INTO PRODUCTS_SUPPLIERS (IDPRODUCTS, IDSUPPLIERS) VALUES (@PRODUCTS,@SUPPLIERS); SELECT SCOPE_IDENTITY()";
            command.Parameters.AddWithValue("@PRODUCTS", idProducts);
            command.Parameters.AddWithValue("@SUPPLIERS", idSuppliers);
            command.Connection = connection;

            try {
                connection.Open();
                int idGerado = Convert.ToInt32(command.ExecuteScalar());
                response.Success = true;
                response.Message = "Cadastrado com sucesso.";
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

        public Response Update(Supplier supplier) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE SUPPLIERS SET RAZAOSOCIAL = @RAZAOSOCIAL, NOMECONTATO = @NOMECONTATO, TELEFONE = @TELEFONE, EMAIL = @EMAIL WHERE ID = @ID";
            command.Parameters.AddWithValue("@RAZAOSOCIAL", supplier.CompanyName);
            command.Parameters.AddWithValue("@NOMECONTATO", supplier.ContactName);
            command.Parameters.AddWithValue("@TELEFONE", supplier.PhoneNumber);
            command.Parameters.AddWithValue("@EMAIL", supplier.Email);
            command.Parameters.AddWithValue("@ID", supplier.ID);

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

        public Response Delete(Supplier supplier) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "DELETE FROM SUPPLIERS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", supplier.ID);

            command.Connection = connection;

            try {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1) {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Excluído com sucesso.";
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

        public Response UpdateActiveSupplier(Supplier supplier) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();

            command.CommandText =
                "UPDATE SUPPLIERS SET ISATIVO = @ISATIVO WHERE ID = @ID";

            command.Parameters.AddWithValue("@ISATIVO", supplier.IsActive);
            command.Parameters.AddWithValue("@ID", supplier.ID);

            command.Connection = connection;

            try {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1) {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
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

        public QueryResponse<Supplier> GetAllSuppliersByActive() {
            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM SUPPLIERS WHERE ISATIVO = 1";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();

                while (reader.Read()) {
                    Supplier supplier = new Supplier();
                    supplier.ID = (int)reader["ID"];
                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    supplier.CNPJ = (string)reader["CNPJ"];
                    supplier.ContactName = (string)reader["NOMECONTATO"];
                    supplier.PhoneNumber = (string)reader["TELEFONE"];
                    supplier.Email = (string)reader["EMAIL"];
                    supplier.IsActive = (bool)reader["ISATIVO"];

                    suppliers.Add(supplier);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = suppliers;
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

        public QueryResponse<Supplier> GetAllSuppliersByInactive() {
            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM SUPPLIERS WHERE ISATIVO = 0";
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();

                while (reader.Read()) {
                    Supplier supplier = new Supplier();
                    supplier.ID = (int)reader["ID"];
                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    supplier.CNPJ = (string)reader["CNPJ"];
                    supplier.ContactName = (string)reader["NOMECONTATO"];
                    supplier.PhoneNumber = (string)reader["TELEFONE"];
                    supplier.Email = (string)reader["EMAIL"];
                    supplier.IsActive = (bool)reader["ISATIVO"];

                    suppliers.Add(supplier);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = suppliers;
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

        public QueryResponse<Supplier> GetAllSuppliersByCompanyName(SearchObject search) {

            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM SUPPLIERS WHERE RAZAOSOCIAL LIKE @RAZAOSOCIAL";
            command.Parameters.AddWithValue("@RAZAOSOCIAL","%" + search.SearchCompanyName + "%");
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();

                while (reader.Read()) {
                    Supplier supplier = new Supplier();
                    supplier.ID = (int)reader["ID"];
                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    supplier.CNPJ = (string)reader["CNPJ"];
                    supplier.ContactName = (string)reader["NOMECONTATO"];
                    supplier.PhoneNumber = (string)reader["TELEFONE"];
                    supplier.Email = (string)reader["EMAIL"];
                    supplier.IsActive = (bool)reader["ISATIVO"];

                    suppliers.Add(supplier);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = suppliers;
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

        public QueryResponse<Supplier> GetAllSuppliersByCNPJ(SearchObject search) {

            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM SUPPLIERS WHERE CNPJ = @CNPJ";
            command.Parameters.AddWithValue("@CNPJ", search.SearchCNPJ);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();

                while (reader.Read()) {
                    Supplier supplier = new Supplier();
                    supplier.ID = (int)reader["ID"];
                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    supplier.CNPJ = (string)reader["CNPJ"];
                    supplier.ContactName = (string)reader["NOMECONTATO"];
                    supplier.PhoneNumber = (string)reader["TELEFONE"];
                    supplier.Email = (string)reader["EMAIL"];
                    supplier.IsActive = (bool)reader["ISATIVO"];

                    suppliers.Add(supplier);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = suppliers;
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

        public QueryResponse<Supplier> GetById(int id) {
            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM  SUPPLIERS WHERE ID LIKE @ID";
            command.Parameters.AddWithValue("@ID","%" + id + "%");
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Supplier> suppliers = new List<Supplier>();

                while (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.ID = (int)reader["ID"];
                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    supplier.CNPJ = (string)reader["CNPJ"];
                    supplier.ContactName = (string)reader["NOMECONTATO"];
                    supplier.PhoneNumber = (string)reader["TELEFONE"];
                    supplier.Email = (string)reader["EMAIL"];
                    supplier.IsActive = (bool)reader["ISATIVO"];

                    suppliers.Add(supplier);

                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = suppliers;
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
        public SingleResponse<Supplier> GetIDSuppliersByCompanyName(SearchObject search)
        {

            SingleResponse<Supplier> response = new SingleResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT * FROM SUPPLIERS WHERE RAZAOSOCIAL = @RAZAOSOCIAL";
            command.Parameters.AddWithValue("@RAZAOSOCIAL",search.SearchCompanyName);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Supplier supplier = new Supplier();

                    supplier.ID = (int)reader["ID"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = supplier;
                    return response;
                }
                response.Success = false;
                response.Message = "Fornecedor não encontrado";
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
        public SingleResponse<Supplier> GetCompanyNameSupplierByID(SearchObject search)
        {

            SingleResponse<Supplier> response = new SingleResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT RAZAOSOCIAL FROM SUPPLIERS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", search.SearchID);
            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Supplier supplier = new Supplier();

                    supplier.CompanyName = (string)reader["RAZAOSOCIAL"];
                    response.Message = "Dados selecionados com sucesso.";
                    response.Success = true;
                    response.Data = supplier;
                    return response;
                }
                response.Success = false;
                response.Message = "Fornecedor não encontrado";
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

        public Response IsCnpjUnique(string cnpj) {
            QueryResponse<Supplier> response = new QueryResponse<Supplier>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();
            SqlCommand command = new SqlCommand();
            command.CommandText =
                "SELECT ID FROM SUPPLIERS WHERE CNPJ = @CNPJ";
            command.Parameters.AddWithValue("@CNPJ", cnpj);
            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    response.Success = false;
                    response.Message = "CNPJ já cadastrado!";

                } else {
                    response.Success = true;
                    response.Message = "CNPJ único.";
                }

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
