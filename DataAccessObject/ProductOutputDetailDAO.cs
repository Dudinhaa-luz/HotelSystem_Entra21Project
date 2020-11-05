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
    public class ProductOutputDetailDAO {

        public Response Insert(ProductOutputDetail productOutputDetail) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "INSERT INTO PRODUCTS_OUTPUT_DETAIL (PRECO, QUANTIDADE) VALUES(@PRECO, @QUANTIDADE)";
            command.Parameters.AddWithValue("@PRECO", productOutputDetail.Price);
            command.Parameters.AddWithValue("@QUANTIDADE", productOutputDetail.Quantity);

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

        public Response Update(ProductOutputDetail productOutputDetail) {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                "UPDATE PRODUCTS_INCOME_DETAIL SET PRECO = @PRECO, QUANTIDADE = @QUANTIDADE WHERE ID = @ID";
            command.Parameters.AddWithValue("@PRECO", productOutputDetail.Price);
            command.Parameters.AddWithValue("@QUANTIDADE", productOutputDetail.Quantity);
            command.Parameters.AddWithValue("@ID", productOutputDetail.IDProductOutput);

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

        public QueryResponse<ProductOutputDetailQueryModel> GetAllProductsOutputDetail() {
            QueryResponse<ProductOutputDetailQueryModel> response = new QueryResponse<ProductOutputDetailQueryModel>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionHelper.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PD.PRECO, PD.QUANTIDADE, P.ID, P.NOME, P.PRECO, P.VALIDADE," +
                                  "PO.ID, PO.DATAENTRADA, PO.VALORTOTAL FROM PRODUCTS_OUTPUT_DETAIL PD INNER JOIN PRODUCTS P ON PD.IDPRODUCTS = P.ID" +
                                  "INNER JOIN PRODUCTS_OUTPUT PO ON PD.IDPRODUCTS_OUTPUT = PO.ID";

            command.Connection = connection;
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<ProductOutputDetailQueryModel> productsOutputDetail = new List<ProductOutputDetailQueryModel>();

                while (reader.Read()) {
                    ProductOutputDetailQueryModel productOutputDetail = new ProductOutputDetailQueryModel();
                    productOutputDetail.ProductOutputDetailPrice = (double)reader["PRECO"];
                    productOutputDetail.ProductOutputDetailQuantity = (double)reader["QUANTIDADE"];
                    productOutputDetail.ProductID = (int)reader["ID"];
                    productOutputDetail.ProductName = (string)reader["NOME"];
                    productOutputDetail.ProductOutputDetailPrice = (double)reader["PRECO"];
                    productOutputDetail.ProductValidity = (DateTime)reader["VALIDADE"];
                    productOutputDetail.ProductOutputID = (int)reader["ID"];
                    productOutputDetail.ProductOutputEntryDate = (DateTime)reader["DATAENTRADA"];
                    productOutputDetail.ProductOutputTotalValue = (double)reader["VALORTOTAL"];


                    productsOutputDetail.Add(productOutputDetail);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso";
                response.Data = productsOutputDetail;
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
