using BussinesLogicalLayer.Extensions;
using Common;
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
            Response response = new Response();
            if (response.Success)
            {
                return clientDAO.Insert(item);
            }
            return response;
        }

        public Response Update(Client item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return clientDAO.Update(item);
            }
            return response;
        }
        public Response UpdateActiveClient(Client item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return clientDAO.Update(item);
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
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
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
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
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
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                }
            }
            return responseClients;
        }
        public QueryResponse<Client> GetAllClientsByCPF(SearchObject search)
        {
            QueryResponse<Client> responseClients = clientDAO.GetAllClientByCPF(search);
            List<Client> temp = responseClients.Data;
            foreach (Client item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber1 = item.PhoneNumber1.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                if (item.PhoneNumber2 != null)
                {
                    item.PhoneNumber2 = item.PhoneNumber2.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                }
            }
            return responseClients;
        }
        public SingleResponse<Client> GetClientsByID(int id)
        {
            SingleResponse<Client> responseClients = clientDAO.GetByID(id);
            Client idgerado = responseClients.Data;

                idgerado.CPF = idgerado.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                idgerado.RG = idgerado.RG.Insert(1, ".").Insert(4, ".");
                idgerado.PhoneNumber1 = idgerado.PhoneNumber1.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                if (idgerado.PhoneNumber2 != null)
                {
                idgerado.PhoneNumber2 = idgerado.PhoneNumber2.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
                }
            return responseClients;
        }

        public override Response Validate(Client item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Name.Length < 3 || item.Name.Length < 80)
            {
                AddError("O nome deve conter entre 3 e 80 caracteres.");
            }
            for (int i = 0; i < item.Name.Length; i++)
            {
                if (!char.IsLetter(item.Name[i]))
                {
                    AddError("O nome deve contêr apenas letras.");
                }
            }
            if (string.IsNullOrWhiteSpace(item.PhoneNumber1))
            {
                AddError("O telefone deve ser informado!");
            }
            else if (item.PhoneNumber1.Length < 12)
            {
                AddError("O telefone deve contêr 12 caracteres");
            }
            if (item.PhoneNumber2 != null)
            {
                if (item.PhoneNumber2.Length < 12)
                {
                    AddError("O telefone deve contêr 12 caracteres");
                }
            }
            if (string.IsNullOrWhiteSpace(item.RG))
            {
                AddError("O RG deve ser informado!");
            }
            else if (item.RG.Length != 7)
            {
                AddError("O RG deve contêr 7 caracteres.");
            }
            for (int i = 0; i < item.RG.Length; i++)
            {
                if (char.IsLetter(item.RG[i]))
                {
                    AddError("RG deve contêr apenas números.");
                }
            }
            
            AddError(item.PhoneNumber1.IsValidPhoneNumber());

            AddError(item.PhoneNumber2.IsValidPhoneNumber());

            AddError(item.CPF.IsValidCPF());

            AddError(item.Email.IsValidEmail());

            Response responseCPF = clientDAO.IsCPFUnique(item.CPF);
            if (!responseCPF.Success)
            {
                AddError(responseCPF.Message);
            }
            return base.Validate(item);
        }
    }
}
