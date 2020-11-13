using Common;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class ProductBLL : BaseValidator<Product>
    {
        private ProductDAO producteDAO = new ProductDAO();
        public Response Insert(Product item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return producteDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Product item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return producteDAO.Update(item);
            }
            return response;
        }
        public Response UpdatePrice(int id, double price)
        {
            Response response = new Response();
            if (response.Success)
            {
                return producteDAO.UpdatePrice(id,price);
            }
            return response;
        }
        public Response UpdateActiveProduct(Product item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return producteDAO.UpdateActiveProduct(item);
            }
            return response;
        }
        public Response Delete(Product item)
        {
            return producteDAO.Delete(item);
        }

        public double ProfitMarginCalculation(Product item)
        {
            double margemLucro = (item.Price / 100) * item.ProfitMargin;
            double margemLucroTotal = margemLucro + item.Price;
            return margemLucroTotal;
        }

        public QueryResponse<Product> GetAllProductsByActive()
        {
            QueryResponse<Product> responseProducts = producteDAO.GetAllProductsByActive();
            List<Product> temp = responseProducts.Data;
            if (temp == null)
            {
                return responseProducts;
            }
                foreach (Product item in temp)
                {
                    item.Price.ToString("C2");
                    Convert.ToString(item.ProfitMargin + "%");
                }
                return responseProducts;
        }
        public QueryResponse<Product> GetAllProductsByInactive()
        {
            QueryResponse<Product> responseProducts = producteDAO.GetAllProductsByInactive();
            List<Product> temp = responseProducts.Data;
            foreach (Product item in temp)
            {
                item.Price.ToString("C2");
                Convert.ToString(item.ProfitMargin + "%");
            }
            return responseProducts;
        }
        public QueryResponse<Product> GetAllProductsByName(SearchObject search)
        {
            QueryResponse<Product> responseProducts = producteDAO.GetAllProductsByName(search);
            List<Product> temp = responseProducts.Data;
            foreach (Product item in temp)
            {
                item.Price.ToString("C2");
                Convert.ToString(item.ProfitMargin + "%");
            }
            return responseProducts;
        }
        public SingleResponse<Product> GetAllProductsByID(int id)
        {
            SingleResponse<Product> responseProducts = producteDAO.GetById(id);
            Product idgerado = responseProducts.Data;

            idgerado.Price.ToString("C2");
            Convert.ToString(idgerado.ProfitMargin + "%");

            return responseProducts;
        }
        public SingleResponse<Product> GetPriceByID(int id)
        {
            SingleResponse<Product> responseProducts = producteDAO.GetPriceById(id);
            Product idgerado = responseProducts.Data;

            idgerado.Price = Convert.ToDouble(idgerado.Price.ToString("C2"));
            return responseProducts;
        }
        public override Response Validate(Product item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                AddError("O nome deve ser informado.");
            }
            else if (item.Name.Length < 2 || item.Name.Length > 100)
            {
                AddError("O nome deve conter entre 2 e 100 caracteres.");
            }
            for (int i = 0; i < item.Name.Length; i++)
            {
                if (!char.IsLetter(item.Name[i]))
                {
                    AddError("O nome deve conter apenas letras.");
                }
            }
            if (string.IsNullOrWhiteSpace(item.Description))
            {
                AddError("A descrição deve ser informada!");
            }
            else if (item.Description.Length < 5 ||item.Description.Length > 150)
            {
                AddError("A descrição deve conter entre 5 e 150 caracteres");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(item.Storage)))
            {
                AddError("O estoque deve ser informado!");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(item.ProfitMargin)))
            {
                AddError("A margem de lucro deve ser informada!");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(item.Price)))
            {
                AddError("O preço deve ser informado!");
            }

            return base.Validate(item);
        }
    }
}
