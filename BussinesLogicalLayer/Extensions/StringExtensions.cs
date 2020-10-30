using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace BussinesLogicalLayer.Extensions
{
    static class StringExtensions
    {
		public static string IsValidCPF(this string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return "CPF deve conter 11 caracteres.";
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			bool val = cpf.EndsWith(digito);
			if (val)
			{
				return "";
			}
			return "CPF inválido.";
		}
        public static string IsValidPhoneNumber (this string phonenumber)
		{
			phonenumber.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-","");
			Regex regex = new Regex(@"^(\([0 - 9]{ 2 }\))\s([9]{ 1})?([0 - 9]{ 4})-([0 - 9]{ 4})$");
            if (regex.IsMatch(phonenumber))
            {
				return "";
            }
			return "Telefone inválido";
		}
        public static string IsValidEmail (this string email)
        {
				Regex regex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (regex.IsMatch(email))
            {
				return "";
            }
				return "Email inválido";
		}
    }
}
