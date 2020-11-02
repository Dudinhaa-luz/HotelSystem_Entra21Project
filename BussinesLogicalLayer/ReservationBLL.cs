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
        }

    }
}
