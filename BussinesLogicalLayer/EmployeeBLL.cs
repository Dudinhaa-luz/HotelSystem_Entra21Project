using BussinesLogicalLayer.Extensions;
using Common;
using Common.Infrastructure;
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
            Response response = Validate(item);
            if (response.Success)
            {
                item.PhoneNumber = item.PhoneNumber.RemoveMaskPhoneNumber();
                item.CPF = item.CPF.RemoveMaskCPF();
                item.RG = item.RG.RemoveMaskRG();
                return employeeDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Employee item)
        {
            Response response = ValidateUpdate(item);
            if (response.Success)
            {
                item.PhoneNumber = item.PhoneNumber.RemoveMaskPhoneNumber();
                return employeeDAO.Update(item);
            }
            return response;
        }

        public Response UpdateActiveEmployee(Employee item)
        {
            Response response = ValidateUpdate(item);
            if (response.Success)
            {
                return employeeDAO.UpdateActiveEmployee(item);
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
            if (temp == null)
            {
                return responseEmployees;
            }
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseEmployees;
        }

        public QueryResponse<Employee> GetAllEmployeesByInactive()
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByInactive();
            List<Employee> temp = responseEmployees.Data;
            if (temp == null)
            {
                return responseEmployees;
            }
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseEmployees;
        }

        public QueryResponse<Employee> GetAllEmployeesByName(SearchObject search)
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByName(search);
            List<Employee> temp = responseEmployees.Data;
            if (temp == null)
            {
                return responseEmployees;
            }
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseEmployees;
        }

        public QueryResponse<Employee> GetAllEmployeesByCPF(SearchObject search)
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetAllEmployeesByCPF(search);
            List<Employee> temp = responseEmployees.Data;
            if (temp == null)
            {
                return responseEmployees;
            }
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseEmployees;
        }

        public QueryResponse<Employee> GetEmployeesByID(int id)
        {
            QueryResponse<Employee> responseEmployees = employeeDAO.GetById(id);
            List<Employee> temp = responseEmployees.Data;
            if (temp == null)
            {
                return responseEmployees;
            }
            foreach (Employee item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.RG = item.RG.Insert(1, ".").Insert(4, ".");
                item.PhoneNumber = item.PhoneNumber.Insert(0, "(").Insert(3, ")").Insert(9, "-");
            }
            return responseEmployees;
        }

        public SingleResponse<Employee> GetNameByEmployeeID(SearchObject search) {
            SingleResponse<Employee> responseEmployees = employeeDAO.GetNameByEmployeeID(search);

            return responseEmployees;
        }

        public SingleResponse<Employee> GetIDByEmployeeName(SearchObject search) {
            SingleResponse<Employee> responseEmployees = employeeDAO.GetIDByEmployeeName(search);

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

            AddError(item.RG.IsValidRG());

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Name.Length < 3 || item.Name.Length > 80)
            {
                AddError("O nome deve conter entre 3 e 80 caracteres.");
            }
            for (int i = 0; i < item.Name.Length; i++) {
                if (char.IsLetter(item.Name[i]) || item.Name == " ") {
                    break;
                } else {
                    AddError("O nome deve contêr apenas letras.");
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

        public string EncryptPassword(string password) {
            var encodedValue = Encoding.UTF8.GetBytes(password);
            var encryptedPassword = MD5.Create().ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword) {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public SingleResponse<Employee> CheckPassword(string email, string senha) {

            SingleResponse<Employee> response = employeeDAO.GetEmployeeByLogin(email, senha);
            if (!response.Success)
            {
                response.Message = "Email ou senha incorreta";
                response.Success = false;
            }
            else
            {
                SystemParameters.EmployeeName = response.Data.Name;
                SystemParameters.EmployeeADM = response.Data.IsAdm;
                response.Success = true;
            }
            return response;

        }
    }
}
