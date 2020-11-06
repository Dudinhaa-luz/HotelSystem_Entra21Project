using BussinesLogicalLayer.Extensions;
using Common;
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

        public Response Insert(Supplier item) {
            Response response = Validate(item);
            bool success = true;
            if (response.Success) {
                using (TransactionScope scope = new TransactionScope()) {
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
            Response response = new Response();
            if (response.Success) {
                return supplierDAO.Update(item);
            }
            return response;
        }

        public Response Delete(Supplier item) {
            return supplierDAO.Delete(item);
        }

        public Response UpdateActiveSupplier(Supplier item) {
            Response response = new Response();
            if (response.Success) {
                return supplierDAO.UpdateActiveSupplier(item);
            }
            return response;
        }

        public QueryResponse<Supplier> GetAllSuppliersByActive() {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByActive();

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseSuppliers;
        }

        public QueryResponse<Supplier> GetAllSuppliersByInactive() {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByInactive();

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseSuppliers;

        }

        public QueryResponse<Supplier> GetAllSuppliersByCompanyName(SearchObject search) {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByCompanyName(search);

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseSuppliers;
        }

        public QueryResponse<Supplier> GetAllSuppliersByCNPJ(SearchObject search) {

            QueryResponse<Supplier> responseSuppliers = supplierDAO.GetAllSuppliersByCNPJ(search);

            List<Supplier> temp = responseSuppliers.Data;

            foreach (Supplier item in temp) {

                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseSuppliers;
        }

        public SingleResponse<Supplier> GetSuppliersById(int id) {

            SingleResponse<Supplier> responseSuppliers = supplierDAO.GetById(id);
            Supplier idgerado = responseSuppliers.Data;

            idgerado.CNPJ = idgerado.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            idgerado.PhoneNumber = idgerado.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");

            return responseSuppliers;
        }

        public override Response Validate(Supplier item) {


            AddError(item.PhoneNumber.IsValidPhoneNumber());
            AddError(item.Email.IsValidEmail());
            AddError(item.CNPJ.IsValidCNPJ());

            Response responseCNPJ = supplierDAO.IsCnpjUnique(item.CNPJ);

            if (!responseCNPJ.Success) {
                AddError(responseCNPJ.Message);
            }


            if (string.IsNullOrWhiteSpace(item.CompanyName)) {
                AddError("O nome deve ser informado.");
            } else if (item.CompanyName.Length < 3 || item.CompanyName.Length < 100) {
                AddError("A razão social deve conter entre 3 e 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(item.ContactName)) {
                AddError("O nome de contato deve ser informado.");
            } else if (item.ContactName.Length < 3 || item.CompanyName.Length < 80) {
                AddError("A razão social deve conter entre 3 e 80 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(item.Email)) {
                AddError("O Email deve ser informado.");
            }

                if (string.IsNullOrWhiteSpace(item.PhoneNumber)) {
                AddError("O telefone deve ser informado!");
            } else if (item.PhoneNumber.Length < 12) {
                AddError("O telefone deve conter 12 caracteres");
            }

            if (string.IsNullOrWhiteSpace(item.CNPJ)) {
                AddError("O CNPJ deve ser informado!");
            } else if (item.CNPJ.Length != 14) {
                AddError("O CNPJ deve conter 14 caracteres.");
            }
            for (int i = 0; i < item.CNPJ.Length; i++) {
                if (char.IsLetter(item.CNPJ[i])) {
                    AddError("CNPJ deve conter apenas números.");
                }
            }

            return base.Validate(item);
        }
    }
}
