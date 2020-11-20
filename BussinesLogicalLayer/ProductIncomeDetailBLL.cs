using Common;
using DataAccessObject;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class ProductIncomeDetailBLL : BaseValidator<ProductIncomeDetail>
    {
        private ProductIncomeDetailDAO productIncomeDetailDAO = new ProductIncomeDetailDAO();
        public Response Insert(ProductIncomeDetail item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return productIncomeDetailDAO.Insert(item);
            }
            return response;
        }
        public Response Update(ProductIncomeDetail item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return productIncomeDetailDAO.Update(item);
            }
            return response;
        }
        public QueryResponse<ProductIncomeDetailQueryModel> GetAllProductsIncomeDetail()
        {
            QueryResponse<ProductIncomeDetailQueryModel> responseProductIncomeDetail = productIncomeDetailDAO.GetAllProductsIncomeDetail();
            List<ProductIncomeDetailQueryModel> temp = responseProductIncomeDetail.Data;
         
            return responseProductIncomeDetail;
        }
        public override Response Validate(ProductIncomeDetail item)
        {
            return base.Validate(item);
        }

        public QueryResponse<ProductIncomeDetail> LinkProductIncomeDetailToProductIncome(ProductIncomeDetail productIncomeDetail, ProductIncome productIncome) {

            QueryResponse<ProductIncomeDetail> response = new QueryResponse<ProductIncomeDetail>();

            if (productIncome.Items.Count > 0) {

                foreach (var item in productIncome.Items) {

                    if (item.IDProductIncome == productIncome.ID) {
                        response.Success = false;
                        response.Message = "Produto já vinculado";
                        return response;
                    }
                }
            }
            productIncome.Items.Add(productIncomeDetail);
            response.Success = true;
            response.Message = "Produto vinculado com sucesso!";

            return response;
        }

    }
}
