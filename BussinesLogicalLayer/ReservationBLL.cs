using Common;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class ReservationBLL : BaseValidator<Reservation>
    {
        private ReservationDAO reservationDAO = new ReservationDAO();
        public Response Insert(Reservation item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return reservationDAO.Insert(item);
            }
            return response;
        }
        public Response Update(Reservation item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return reservationDAO.Update(item);
            }
            return response;
        }
        public Response Delete(Reservation item)
        {
            return reservationDAO.Delete(item);
        }
        public QueryResponse<ReservationQueryModel> GetAllReservations()
        {
            QueryResponse<ReservationQueryModel> responseReservations = reservationDAO.GetAllReservations();
            List<ReservationQueryModel> temp = responseReservations.Data;
            foreach (ReservationQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseReservations;
        }
        public QueryResponse<ReservationQueryModel> GetAllReservationsbyReservationDate(SearchObject search)
        {
            QueryResponse<ReservationQueryModel> responseReservations = reservationDAO.GetAllReservationsbyReservationDate(search);
            List<ReservationQueryModel> temp = responseReservations.Data;
            foreach (ReservationQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseReservations;
        }
        public QueryResponse<ReservationQueryModel> GetAllProductOutputbyEmployeeID(SearchObject search)
        {
            QueryResponse<ReservationQueryModel> responseReservations = reservationDAO.GetAllReservationsByRoomsNumber(search);
            List<ReservationQueryModel> temp = responseReservations.Data;
            foreach (ReservationQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseReservations;
        }
        public QueryResponse<ReservationQueryModel> GetAllProductOutputbyClientID(SearchObject search)
        {
            QueryResponse<ReservationQueryModel> responseReservations = reservationDAO.GetAllReservationsbyClientCPF(search);
            List<ReservationQueryModel> temp = responseReservations.Data;
            foreach (ReservationQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseReservations;
        }
        public override Response Validate(Reservation item)
        {
            return base.Validate(item);
        }

    }
}
