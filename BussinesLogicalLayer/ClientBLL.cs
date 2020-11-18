using BussinesLogicalLayer.Extensions;
using Common;
using Common.Infrastructure;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class ClientBLL : BaseValidator<Client>
    {
        private ClientDAO clientDAO = new ClientDAO();
        public Response Insert(Client item)
        {
            Response response = Validate(item);

            if (response.Success)
            {
                item.RG = item.RG.RemoveMaskRG();
                item.PhoneNumber1 = item.PhoneNumber1.RemoveMaskPhoneNumber();
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.RemoveMaskPhoneNumber();
                }
                item.CPF = item.CPF.RemoveMaskCPF();
                return clientDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Client item)
        {
            Response response = ValidateUpdate(item);
            if (response.Success)
            {
                item.PhoneNumber1 = item.PhoneNumber1.RemoveMaskPhoneNumber();
                if (item.PhoneNumber2 != null) {
                    item.PhoneNumber2 = item.PhoneNumber2.RemoveMaskPhoneNumber();
                }
                return clientDAO.Update(item);
            }
            return response;
        }
        public Response UpdateActiveClient(Client item)
        {
            Response response = ValidateUpdate(item);
            if (response.Success)
            {
                ValidateUpdate(item);

                return clientDAO.UpdateActiveClient(item);
            }
            return response;
        }
        public Response Delete(Client item)
        {
            return clientDAO.Delete(item);
        }
        public QueryResponse<Client> GetAllClientsByActive()
        {
            QueryResponse<Client> responseClients = clientDAO.GetAllClientsByActive();
            List<Client> temp = responseClients.Data;
            if (temp == null)
            {
                return responseClients;
            }
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                item.RG = item.RG.Insert(1, ".").Insert(5, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                }
            }
            return responseClients;
        }
        public QueryResponse<Client> GetAllClientsByInactive()
        {
            QueryResponse<Client> responseClients = clientDAO.GetAllClientsByInactive();
            List<Client> temp = responseClients.Data;
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                }
            }
            return responseClients;
        }
        public QueryResponse<Client> GetAllClientsByName(SearchObject search)
        {
            QueryResponse<Client> responseClients = clientDAO.GetAllClientByName(search);
            List<Client> temp = responseClients.Data;
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                }
            }
            return responseClients;
        }
        public QueryResponse<Client> GetAllClientsByCPF(SearchObject search)
        {
            QueryResponse<Client> responseClients = clientDAO.GetAllClientByCPF(search);
            List<Client> temp = responseClients.Data;
            if (temp == null)
            {
                return responseClients;
            }
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                }
            }
            return responseClients;
        }
        public QueryResponse<Client> GetClientsByID(int id)
        {
            QueryResponse<Client> responseClients = clientDAO.GetByID(id);
            List<Client> temp = responseClients.Data;
            if (temp == null)
            {
                return responseClients;
            }
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "(").Insert(3, ")").Insert(9, "-");
                }
            }
            return responseClients;
        }
        public override Response Validate(Client item)
        {
            AddError(item.PhoneNumber1.IsValidPhoneNumber());

            AddError(item.PhoneNumber2.IsValidPhoneNumber());

            AddError(item.CPF.IsValidCPF());

            AddError(item.Email.IsValidEmail());

            AddError(item.RG.IsValidRG());

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Name.Length < 3 || item.Name.Length > 80)
            {
                AddError("O nome deve conter entre 3 e 80 caracteres.");
            }
            for (int i = 0; i < item.Name.Length; i++)
            {
                if (char.IsDigit(item.Name[i]))
                {
                    AddError("O nome deve contêr apenas letras.");
                }
            }

            Response responseCPF = clientDAO.IsCPFUnique(item.CPF);
            if (!responseCPF.Success)
            {
                AddError(responseCPF.Message);
            }
            
            return base.Validate(item);
        }
        public override Response ValidateUpdate(Client item)
        {
            AddError(item.PhoneNumber1.IsValidPhoneNumber());

            AddError(item.PhoneNumber2.IsValidPhoneNumber());

            AddError(item.Email.IsValidEmail());

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Name.Length < 3 || item.Name.Length > 80)
            {
                AddError("O nome deve conter entre 3 e 80 caracteres.");
            }
            for (int i = 0; i < item.Name.Length; i++)
            {
                if (char.IsLetter(item.Name[i]) || item.Name == " ")
                {
                    break;
                }
                else
                {
                    AddError("O nome deve contêr apenas letras.");
                }
            }

            return base.ValidateUpdate(item);
        }
    }
}
