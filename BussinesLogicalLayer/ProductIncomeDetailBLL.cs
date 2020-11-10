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
            //foreach (ProductIncomeDetailQueryModel item in temp)
            //{
            //    item.Price.ToString("C2");
            //}
            return responseProductIncomeDetail;
        }
        public override Response Validate(ProductIncomeDetail item)
        {
            return base.Validate(item);
        }
    }
}
