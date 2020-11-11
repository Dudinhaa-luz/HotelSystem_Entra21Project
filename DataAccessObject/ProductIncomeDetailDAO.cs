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

namespace DataAccessObject {
    public class ProductIncomeDetailDAO {

        public Response Insert(ProductIncomeDetail productIncomeDetail) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO PRODUCTS_INCOME_DETAILS (PRECO, QUANTIDADE) VALUES(@PRECO, @QUANTIDADE)";
            command.Parameters.AddWithValue("@PRECO", productIncomeDetail.Price);
            command.Parameters.AddWithValue("@QUANTIDADE", productIncomeDetail.Quantity);

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

        public Response Update(ProductIncomeDetail productIncomeDetail) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE PRODUCTS_INCOME_DETAILS SET PRECO = @PRECO, QUANTIDADE = @QUANTIDADE WHERE ID = @ID";
            command.Parameters.AddWithValue("@PRECO", productIncomeDetail.Price);
            command.Parameters.AddWithValue("@QUANTIDADE", productIncomeDetail.Quantity);
            command.Parameters.AddWithValue("@ID", productIncomeDetail.IDProductIncome);

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

        public QueryResponse<ProductIncomeDetailQueryModel> GetAllProductsIncomeDetail() {
            QueryResponse<ProductIncomeDetailQueryModel> response = new QueryResponse<ProductIncomeDetailQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PD.PRECO, PD.QUANTIDADE, P.ID, P.NOME, P.PRECO, P.VALIDADE," +
                                  "PI.ID, PI.DATAENTRADA, PI.VALORTOTAL FROM PRODUCTS_INCOME_DETAILS PD INNER JOIN PRODUCTS P ON PD.IDPRODUCTS = P.ID" +
                                  "INNER JOIN PRODUCTS_INCOME PI ON PD.IDPRODUCTS_INCOME = PI.ID";

            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeDetailQueryModel> productsIncomeDetail = new List<ProductIncomeDetailQueryModel>();

                while (reader.Read()) {
                    ProductIncomeDetailQueryModel productIncomeDetail = new ProductIncomeDetailQueryModel();
                    productIncomeDetail.ProductIncomeDetailPrice = (double)reader["PRECO"];
                    productIncomeDetail.ProductIncomeDetailQuantity = (double)reader["QUANTIDADE"];
                    productIncomeDetail.ProductID = (int)reader["ID"];
                    productIncomeDetail.ProductName = (string)reader["NOME"];
                    productIncomeDetail.ProductIncomeDetailPrice = (double)reader["PRECO"];
                    productIncomeDetail.ProductValidity = (DateTime)reader["VALIDADE"];
                    productIncomeDetail.ProductIncomeID = (int)reader["ID"];
                    productIncomeDetail.ProductIncomeEntryDate = (DateTime)reader["DATAENTRADA"];
                    productIncomeDetail.ProductIncomeTotalValue = (double)reader["VALORTOTAL"];

                    productsIncomeDetail.Add(productIncomeDetail);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = productsIncomeDetail;
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
