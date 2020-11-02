﻿using Common;
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
        public Response UpdateActiveProduct(Product item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return producteDAO.Update(item);
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
            foreach (Product item in temp)
            {
                item.Price.ToString("C2");
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
            }
            return responseProducts;
        }
        public SingleResponse<Product> GetAllProductsByID(int id)
        {
            SingleResponse<Product> responseProducts = producteDAO.GetById(id);
            Product idgerado = responseProducts.Data;

            idgerado.Price.ToString("C2");
            return responseProducts;
        }
    }
}