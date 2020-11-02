using Common;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer {
    class RoomBLL : BaseValidator<Room> {

        private RoomDAO roomDAO = new RoomDAO();

        public Response Insert(Room item) {
            Response response = new Response();
            if (response.Success) {
                return roomDAO.Insert(item);
            }
            return response;
        }
        public Response UpdateOcuppyRoom(Room item) {
            Response response = new Response();
            if (response.Success) {
                return roomDAO.UpdateOcuppyRoom(item);
            }
            return response;
        }

        public QueryResponse<Room> GetAllRoomsAvailable() {
            QueryResponse<Room> responseRooms = roomDAO.GetAllRoomsAvailable();
            List<Room> temp = responseRooms.Data;

            return responseRooms;
        }

        public QueryResponse<Room> GetAllRoomsOccupy() {
            QueryResponse<Room> responseRooms = roomDAO.GetAllRoomsOccupy();
            List<Room> temp = responseRooms.Data;

            return responseRooms;
        }

        public QueryResponse<Room> GetAllRoomsByNumberRoom(SearchObject search) {
            QueryResponse<Room> responseRooms = roomDAO.GetAllRoomsByNumberRoom(search);
            List<Room> temp = responseRooms.Data;

            return responseRooms;
        }

        public SingleResponse<Room> GetById(int id) {

            SingleResponse<Room> responseRooms = roomDAO.GetById(id);

            return responseRooms;
        }

        public override Response Validate(Room item) {

            if (string.IsNullOrWhiteSpace(item.NumberRoom)) {
                AddError("O número do quarto deve ser informado.");
            } else if (item.NumberRoom.Length < 1 || item.NumberRoom.Length < 5) {
                AddError("O número do quarto deve conter entre 1 e 5 caracteres");
            }
            if (string.IsNullOrWhiteSpace(item.Description)) {
                AddError("A descrição do quarto deve ser informada.");
            } else if (item.NumberRoom.Length < 1 || item.NumberRoom.Length < 5) {
                AddError("A descriçãodeve conter entre 3 e 100 caracteres");
            }
            if (item.IDRoomType == 0) {
                AddError("O tipo do quarto deve ser informado");
            }

            return base.Validate(item);
        }

    }
}
