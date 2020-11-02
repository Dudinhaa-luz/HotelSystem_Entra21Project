using Common;
using DataAccessObject;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class StorageBLL : BaseValidator<Storage>
    {
        private StorageDAO storageDAO = new StorageDAO();
        public Response Insert(Storage item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return storageDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Storage item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return storageDAO.Update(item);
            }
            return response;
        }
        public SingleResponse<Storage> AddProduct(ProductIncomeDetail item)
        {
            SingleResponse<Storage> singleResponse = new SingleResponse<Storage>();
            Storage storage = new Storage();
            storage.ProductsID = item.IDProduct;

            StorageDAO storageDAO = new StorageDAO();
            if (storageDAO.GetQuantityByIDProducts(item).Quantity == 0)
            {
                item.Quantity += storageDAO.GetQuantityByIDProducts(item).Quantity;
                storage.Quantity = item.Quantity;
                Insert(storage);
            }
            else if (storageDAO.GetQuantityByIDProducts(item).Quantity > 0)
            {
                item.Quantity += storageDAO.GetQuantityByIDProducts(item).Quantity;
                storage.Quantity = item.Quantity;
                Update(storage);
            }
            return singleResponse;
        }
        public SingleResponse<Storage> DeleteProduct(ProductIncomeDetail item)
        {
            SingleResponse<Storage> singleResponse = new SingleResponse<Storage>();
            Storage storage = new Storage();
            storage.ProductsID = item.IDProduct;

            StorageDAO storageDAO = new StorageDAO();
            if (storageDAO.GetQuantityByIDProducts(item).Quantity == 0)
            {
                singleResponse.Message = "Estoque zerado";
            }
            else if (storageDAO.GetQuantityByIDProducts(item).Quantity > 0)
            {
                item.Quantity -= storageDAO.GetQuantityByIDProducts(item).Quantity;
                storage.Quantity = item.Quantity;
                Update(storage);
            }
            return singleResponse;
        }
        public QueryResponse<Storage> GetAllStorage()
        {
            QueryResponse<Storage> response = new QueryResponse<Storage>();
            if(response.Success)
            {
                return storageDAO.GetAllStorage();
            }
            return response;
        }
        public QueryResponse<Storage> GetAllStorageByIDProducts()
        {
            QueryResponse<Storage> response = new QueryResponse<Storage>();
            if (response.Success)
            {
                return storageDAO.GetAllStorageByIDProducts();
            }
            return response;
        }
        public SingleResponse<Storage> GetById(int id)
        {
            SingleResponse<Storage> responseStorage = storageDAO.GetById(id);
            Storage idgerado = responseStorage.Data;
            return responseStorage;
        }
    }
}
