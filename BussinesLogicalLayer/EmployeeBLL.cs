using Common;
using DataAccessObject;
using Entities;
using System;
using System.Collections.Generic;
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
        public QueryResponse<Employee> GetAllEmployeesByName()
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
        public QueryResponse<Employee> GetAllEmployeesByCPF()
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

    }
}
