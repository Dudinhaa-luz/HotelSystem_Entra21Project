using Common;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;


namespace BussinesLogicalLayer
{
    public class ProductIncomeBLL : BaseValidator<ProductIncome>
    {
        ProductsIncomeDAO productsIncomeDAO = new ProductsIncomeDAO();
        StorageBLL storage = new StorageBLL();


        public Response Insert(ProductIncome item) {
            Response response = Validate(item);
            bool success = true;
            if (response.Success) {
                using (TransactionScope scope = new TransactionScope()) {
                    SingleResponse<int> responseInsert = productsIncomeDAO.Insert(item);
                    if (responseInsert.Success) {

                        for (int i = 0; i < item.Items.Count; i++) {

                            item.Items[i].IDProductIncome = responseInsert.Data;
                            Response r = productsIncomeDAO.InsertProductIncomeDetail(item.Items[i]);

                            storage.AddProduct(item.Items[i]);

                            if (!r.Success) {

                                success = false;
                                break;
                            }
                        }

                    }
                    if (success) {
                        scope.Complete();

                    }
                }
            }
            return response;
        }
        public Response Update(ProductIncome item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return productsIncomeDAO.Update(item);
            }
            return response;
        }
        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncome()
        {

            QueryResponse<ProductIncomeQueryModel> responseProductsIncome = productsIncomeDAO.GetAllProductIncome();

            List<ProductIncomeQueryModel> temp = responseProductsIncome.Data;
            foreach (ProductIncomeQueryModel item in temp)
            {
                item.ProductIncomeTotalValue.ToString("C2");
            }

            return responseProductsIncome;
        }
        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebyEntryDate(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> responseProductsIncome = productsIncomeDAO.GetAllProductIncomebyEntryDate(search);

            List<ProductIncomeQueryModel> temp = responseProductsIncome.Data;
            foreach (ProductIncomeQueryModel item in temp)
            {
                item.ProductIncomeTotalValue.ToString("C2");
            }

            return responseProductsIncome;
        }
        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebyEmployeeID(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> responseProductsIncome = productsIncomeDAO.GetAllProductIncomebyEmployeeID(search);

            List<ProductIncomeQueryModel> temp = responseProductsIncome.Data;
            foreach (ProductIncomeQueryModel item in temp)
            {
                item.ProductIncomeTotalValue.ToString("C2");
            }

            return responseProductsIncome;
        }
        public QueryResponse<ProductIncomeQueryModel> GetAllProductIncomebySupplierID(SearchObject search)
        {

            QueryResponse<ProductIncomeQueryModel> responseProductsIncome = productsIncomeDAO.GetAllProductIncomebySupplierID(search);

            List<ProductIncomeQueryModel> temp = responseProductsIncome.Data;
            foreach (ProductIncomeQueryModel item in temp)
            {
                item.ProductIncomeTotalValue.ToString("C2");
            }

            return responseProductsIncome;
        }

        public override Response Validate(ProductIncome item)
        {
            if (string.IsNullOrWhiteSpace(item.Items.ToString()))
            {
                AddError("Insira um produto."); 
            }
            return base.Validate(item);
        }
    }
}
