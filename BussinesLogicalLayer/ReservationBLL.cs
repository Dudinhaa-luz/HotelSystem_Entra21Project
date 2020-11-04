using Common;
using DataAccessObject;
using Entities;
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
        public QueryResponse<Reservation> GetAllReservations()
        {
            QueryResponse<Reservation> responseReservations = reservationDAO.GetAllReservations();
            List<Reservation> temp = responseReservations.Data;
            return responseReservations;
        }
        public QueryResponse<Reservation> GetAllReservationsbyReservationDate()
        {
            QueryResponse<Reservation> responseReservations = reservationDAO.GetAllReservationsbyReservationDate();
            List<Reservation> temp = responseReservations.Data;
            return responseReservations;
        }
        public SingleResponse<Reservation> GetAllProductOutputbyEmployeeID(int id)
        {
            SingleResponse<Reservation> responseReservations = reservationDAO.GetAllProductOutputbyEmployeeID(id);
            Reservation idgerado = responseReservations.Data;
            return responseReservations;
        }
        public SingleResponse<Reservation> GetAllProductOutputbyClientID(int id)
        {
            SingleResponse<Reservation> responseReservations = reservationDAO.GetAllProductOutputbyClientID(id);
            Reservation idgerado = responseReservations.Data;
            return responseReservations;
        }

        }
    }
}
