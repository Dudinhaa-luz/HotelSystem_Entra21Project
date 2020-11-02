using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessObject;
using DataAccessObject.Infrastructure;

namespace BussinesLogicalLayer {
    public class RoomTypeBLL : BaseValidator<RoomType> {

        RoomTypeDAO roomTypeDAO = new RoomTypeDAO();
        public Response Insert(RoomType item) {
            Response response = new Response();
            if (response.Success) {
                return roomTypeDAO.Insert(item);
            }
            return response;
        }
        public Response Update(RoomType item) {
            Response response = new Response();
            if (response.Success) {
                return roomTypeDAO.Update(item);
            }
            return response;
        }

        public Response UpdateDescription(RoomType item) {
            Response response = new Response();
            if (response.Success) {
                return roomTypeDAO.UpdateDescription(item);
            }
            return response;
        }

        public Response Delete(RoomType item) {
            Response response = new Response();
            if (response.Success) {
                return roomTypeDAO.Delete(item);
            }
            return response;
        }

        public QueryResponse<RoomType> GetAllRoomsType() {
            QueryResponse<RoomType> responseProducts = roomTypeDAO.GetAllRoomsType();
            List<RoomType> temp = responseProducts.Data;
            foreach (RoomType item in temp) {
                item.Value.ToString("C2");
                item.DailyValue.ToString("C2");
            }
            return responseProducts;
        }

        public QueryResponse<RoomType> GetAllRoomsTypeByDescription(SearchObject search) {
            QueryResponse<RoomType> responseProducts = roomTypeDAO.GetAllRoomsTypeByDescription(search);
            List<RoomType> temp = responseProducts.Data;
            foreach (RoomType item in temp) {
                item.Value.ToString("C2");
                item.DailyValue.ToString("C2");
            }
            return responseProducts;
        }

        public QueryResponse<RoomType> GetAllRoomsTypeByGuestNumber(SearchObject search) {
            QueryResponse<RoomType> responseProducts = roomTypeDAO.GetAllRoomsTypeByGuestNumber(search);
            List<RoomType> temp = responseProducts.Data;
            foreach (RoomType item in temp) {
                item.Value.ToString("C2");
                item.DailyValue.ToString("C2");
            }
            return responseProducts;
        }

        public SingleResponse<RoomType> GetById(int id) {
            SingleResponse<RoomType> responseProducts = roomTypeDAO.GetById(id);

            RoomType room = new RoomType();

            room.Value.ToString("C2");
            room.DailyValue.ToString("C2");

            return responseProducts;
        }

    }
}
