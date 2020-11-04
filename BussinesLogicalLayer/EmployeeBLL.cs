using BussinesLogicalLayer.Extensions;
using Common;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BussinesLogicalLayer
{
    public class EmployeeBLL : BaseValidator<Employee>
    {
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        public Response Insert(Employee item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return employeeDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Employee item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return employeeDAO.Update(item);
            }
            return response;
        }
        public Response UpdateActiveEmployee(Employee item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return employeeDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Employee item)
        {
            return employeeDAO.Delete(item);
        }
        public QueryResponse<Employee> GetAllEmployeesByActive()
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByActive();
            List<Employee> temp = responseEmployees.Data;
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseEmployees;
        }
        public QueryResponse<Employee> GetAllEmployeesByInactive()
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByInactive();
            List<Employee> temp = responseEmployees.Data;
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseEmployees;
        }
        public QueryResponse<Employee> GetAllEmployeesByName(SearchObject search)
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByName(search);
            List<Employee> temp = responseEmployees.Data;
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseEmployees;
        }
        public QueryResponse<Employee> GetAllEmployeesByCPF(SearchObject search)
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByCPF(search);
            List<Employee> temp = responseEmployees.Data;
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseEmployees;
        }
        public SingleResponse<Employee> GetClientsByID(int id)
        {
            SingleResponse<Employee> responseEmployees = employeeDAO.GetById(id);
            Employee idgerado = responseEmployees.Data;

            idgerado.CPF = idgerado.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
            idgerado.RG = idgerado.RG.Insert(1, ".").Insert(4, ".");
            idgerado.PhoneNumber = idgerado.PhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            return responseEmployees;
        }
        public Response IsADM(Employee item)
        {
            Response response = new Response();
            if (!item.IsAdm)
            {
                response.Success = false;
            }
            response.Success = true;
            return response;
        }
        public override Response Validate(Employee item)
        {

            AddError(item.PhoneNumber.IsValidPhoneNumber());

            AddError(item.CPF.IsValidCPF());

            AddError(item.Email.IsValidEmail());

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
            if (string.IsNullOrWhiteSpace(item.PhoneNumber))
            {
                AddError("O telefone deve ser informado!");
            }
            else if (item.PhoneNumber.Length < 12)
            {
                AddError("O telefone deve contêr 12 caracteres");
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

            Response responseCPF = employeeDAO.IsCPFUnique(item.CPF);
            if (!responseCPF.Success)
            {
                AddError(responseCPF.Message);
            }

            Response responseEmail = employeeDAO.IsEmailUnique(item.Email);
            if (!responseEmail.Success) {
                AddError(responseEmail.Message);
            }

            return base.Validate(item);
        }

        private HashAlgorithm _algoritmo;
        public void Hash(HashAlgorithm algoritmo) {
            _algoritmo = algoritmo;
        }

        public string EncryptPassword(string senha) {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword) {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public QueryResponse<Employee> CheckPassword(string senha, string email) {

            QueryResponse<Employee> response = new QueryResponse<Employee>();
            EmployeeDAO employee = new EmployeeDAO();

            if (string.IsNullOrEmpty(senha))
                throw new NullReferenceException("Cadastre uma senha.");

            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var sb = new StringBuilder();

            foreach (var caractere in encryptedPassword) {
                sb.Append(caractere.ToString("X2"));
            }


            if (employee.GetEmployeeByLogin(email, senha).Success) {

                SystemParameter.CurrentEmploye = employee.GetEmployeeByLogin(email, senha).Data;
            }
            response.Message = "Senha incorreta";

            return response;
        }
    }

}
