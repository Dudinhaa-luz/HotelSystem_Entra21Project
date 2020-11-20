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
                
                item.Quantity = storageDAO.GetQuantityByIDProducts(item).Quantity;
                storage.Quantity = item.Quantity;
                Update(storage);
            }
            else if (storageDAO.GetQuantityByIDProducts(item).Quantity > 0)
            {
                ProductPriceAtt(item);
                item.Quantity += storageDAO.GetQuantityByIDProducts(item).Quantity;
                storage.Quantity = item.Quantity;
                Update(storage);
            }
            return singleResponse;
        }
        private void ProductPriceAtt(ProductIncomeDetail item)
        {
            ProductBLL productBLL = new ProductBLL();
            Storage storage = new Storage();
            storage.ProductsID = item.IDProduct;
            
                double qtdProductsStorage = Convert.ToDouble(storageDAO.GetQuantityByIDProducts(item).Data);
                double productPrice = Convert.ToDouble(productBLL.GetPriceByID(item.IDProduct));
                double qtdProductsEntry = item.Quantity;
                double products = ((qtdProductsStorage * productPrice) + 
                (qtdProductsEntry * item.Price)) / qtdProductsStorage + qtdProductsEntry;
                productBLL.UpdatePrice(item.IDProduct, products);
        }
        public SingleResponse<Storage> DeleteProduct(ProductOutputDetail item)
        {
            SingleResponse<Storage> singleResponse = new SingleResponse<Storage>();
            Storage storage = new Storage();
            storage.ProductsID = item.IDProduct;

            StorageDAO storageDAO = new StorageDAO();
            if (storageDAO.GetQuantityByIDProductsOutput(item).Quantity == 0)
            {
                singleResponse.Message = "Estoque zerado";
                singleResponse.Success = false;
            }
            else if (storageDAO.GetQuantityByIDProductsOutput(item).Quantity > 0)
            {
                item.Quantity -= storageDAO.GetQuantityByIDProductsOutput(item).Quantity;
                storage.Quantity = item.Quantity;
                singleResponse.Success = true;
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
        public QueryResponse<Storage> GetAllStorageByIDProducts(Product item)
        {
            QueryResponse<Storage> response = new QueryResponse<Storage>();
            if (response.Success)
            {
                return storageDAO.GetAllStorageByIDProducts(item);
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
