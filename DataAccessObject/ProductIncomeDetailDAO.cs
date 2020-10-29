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
    public class ProductIncomeDetailDAO {

        public Response Insert(ProductIncomeDetail productIncomeDetail) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO PRODUCTS_INCOME_DETAIL (PRECO, QUANTIDADE) VALUES(@PRECO, @QUANTIDADE)";
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
                "UPDATE PRODUCTS_INCOME_DETAIL SET PRECO = @PRECO, QUANTIDADE = @QUANTIDADE WHERE ID = @ID";
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

        public QueryResponse<ProductIncomeDetail> GetAllProductsIncomeDetail() {
            QueryResponse<ProductIncomeDetail> response = new QueryResponse<ProductIncomeDetail>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PD.PRECO, PD.QUANTIDADE, P.ID, P.NOME, P.PRECO, P.VALIDADE," +
                                  "PI.ID, PI.DATAENTRADA, PI.IDFUNCIONARIO, PI.IDFORNECEDOR, PI.VALORTOTAL FROM PRODUCTS_INCOME_DETAIL PD INNER JOIN PRODUCTS P ON PD.IDPRODUCTS = P.ID" +
                                  "INNER JOIN PRODUCTS_INCOME PI ON PD.IDPRODUCTS_INCOME = PI.ID";

            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductIncomeDetail> productsIncomeDetail = new List<ProductIncomeDetail>();

                while (reader.Read()) {
                    ProductIncomeDetail productIncomeDetail = new ProductIncomeDetail();
                    productIncomeDetail.IDProductIncome = (int)reader["IDPRODUCTS_INCOME"];
                    productIncomeDetail.IDProduct = (int)reader["IDPRODUCTS"];
                    productIncomeDetail.Price = (double)reader["PRECO"];
                    productIncomeDetail.Quantity = (double)reader["QUANTIDADE"];

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
