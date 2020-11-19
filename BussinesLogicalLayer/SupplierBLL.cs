using BussinesLogicalLayer.Extensions;
using Common;
using Common.Infrastructure;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BussinesLogicalLayer {
    public class SupplierBLL : BaseValidator<Supplier> {

        private SupplierDAO supplierDAO = new SupplierDAO();
        Supplier supplier = new Supplier();


        public Response Insert(Supplier item) {
            Response response = Validate(item);
            bool success = true;
            if (response.Success) {
                using (TransactionScope scope = new TransactionScope()) {

                    item.CNPJ = item.CNPJ.RemoveMaskCNPJ();
                    item.PhoneNumber = item.PhoneNumber.RemoveMaskPhoneNumber();

                    SingleResponse<int> responseInsert = supplierDAO.Insert(item);
                    if (responseInsert.Success) {

                        for (int i = 0; i < item.Items.Count; i++) {

                            response = supplierDAO.InsertProducts(item.Items[i].ID, responseInsert.Data);

                            if (!response.Success) {

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

        public Response Update(Supplier item) {
            Response response = Validate(item);
            if (response.Success) {
                return supplierDAO.Update(item);
            }
            return response;
        }

        public Response Delete(Supplier item) {
            return supplierDAO.Delete(item);
        }

        public Response UpdateActiveSupplier(Supplier item) {
            Response response = Validate(item);
            if (response.Success) {
                return supplierDAO.UpdateActiveSupplier(item);
            }
            return response;
        }

        public QueryResponse<Supplier> GetAllSuppliersByActive()
        {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByActive();

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp)
            {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseSuppliers;

        }

        public QueryResponse<Supplier> GetAllSuppliersByInactive() {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByInactive();

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseSuppliers;

        }

        public QueryResponse<Supplier> GetAllSuppliersByCompanyName(SearchObject search) {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByCompanyName(search);

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseSuppliers;
        }

        public QueryResponse<Supplier> GetAllSuppliersByCNPJ(SearchObject search) {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByCNPJ(search);

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseSuppliers;
        }

        public QueryResponse<Supplier> GetSuppliersById(int id) {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetById(id);
            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp)
            {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseSuppliers;
        }

        public SingleResponse<Supplier> GetIDSuppliersByCompanyName(SearchObject search)
        {

            SingleResponse<Supplier> responseSuppliers = supplierDAO.GetIDSuppliersByCompanyName(search);

            //List<Supplier> temp = responseSuppliers.Data;

            return responseSuppliers;
        }
        public QueryResponse<Supplier> GetCompanyNameSupplierByID(SearchObject search)
        {
            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetCompanyNameSupplierByID(search);
            List<Supplier> temp = responseSuppliers.Data;

            return responseSuppliers;
        }

        public override Response Validate(Supplier item) {


            AddError(item.PhoneNumber.IsValidPhoneNumber());
            AddError(item.Email.IsValidEmail());
            AddError(item.CNPJ.IsValidCNPJ());
            AddError(item.Email.IsValidEmail());

            Response responseCNPJ = supplierDAO.IsCnpjUnique(item.CNPJ);

            if (!responseCNPJ.Success) {
                AddError(responseCNPJ.Message);
            }


            if (string.IsNullOrWhiteSpace(item.CompanyName))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.CompanyName.Length < 3 || item.CompanyName.Length > 80)
            {
                AddError("O nome deve conter entre 3 e 80 caracteres.");
            }
            for (int i = 0; i < item.CompanyName.Length; i++)
            {
                if (char.IsDigit(item.CompanyName[i]))
                {
                    AddError("O nome deve contêr apenas letras.");
                }
            }

            return base.Validate(item);
        }

    }
}
