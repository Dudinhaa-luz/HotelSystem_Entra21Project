using Common;
using Common.Infrastructure;
using DataAccessObject;
using DataAccessObject.Infrastructure;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicalLayer
{
    public class CheckoutClientBLL : BaseValidator<CheckoutClient>
    {
        private CheckoutClientDAO checkoutClientDAO = new CheckoutClientDAO();
        private RoomDAO roomDAO = new RoomDAO();
        private RoomTypeDAO roomTypeDAO = new RoomTypeDAO();

        public Response Insert(CheckoutClient item)
        {
            Response response = new Response();
            if (response.Success)
            {
                return checkoutClientDAO.Insert(item);
            }
            return response;
        }
        public QueryResponse<CheckoutQueryModel> GetAllCheckouts()
        {
            QueryResponse<CheckoutQueryModel> responseCheckoutClient = checkoutClientDAO.GetAllCheckouts();
            List<CheckoutQueryModel> temp = responseCheckoutClient.Data;
            foreach (CheckoutQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckoutClient;
        }
        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByExitDate(SearchObject search)
        {
            QueryResponse<CheckoutQueryModel> responseCheckoutClient = checkoutClientDAO.GetAllCheckoutsByExitDate(search);
            List<CheckoutQueryModel> temp = responseCheckoutClient.Data;
            foreach (CheckoutQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckoutClient;
        }
        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByClientID(SearchObject search)
        {
            QueryResponse<CheckoutQueryModel> responseCheckoutClient = checkoutClientDAO.GetAllCheckoutsByClientID(search);
            List<CheckoutQueryModel> temp = responseCheckoutClient.Data;
            foreach (CheckoutQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckoutClient;
        }
        public QueryResponse<CheckoutQueryModel> GetAllCheckoutsByEmployeeID(SearchObject search)
        {
            QueryResponse<CheckoutQueryModel> responseCheckoutClient = checkoutClientDAO.GetAllCheckoutsByEmployeeID(search);
            List<CheckoutQueryModel> temp = responseCheckoutClient.Data;
            foreach (CheckoutQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckoutClient;
        }
        public override Response Validate(CheckoutClient item)
        {
            return base.Validate(item);
        }

        public void PenaltyCalculation(CheckinClient checkin, CheckoutClient checkout)
        {
            if (checkin.ExitDate == checkout.ExitDate)
            {
                checkout.ExitOnTime = true;
                checkout.Penalty = 0;
            }
            else if (checkin.ExitDate > checkout.ExitDate)
            {
                checkout.ExitOnTime = true;
                checkout.Penalty = 0;
            }
            else
            {
                int roomTypeID = Convert.ToInt32(roomDAO.GetRoomTypeIDByRoomID(checkin.RoomID).Data);

                double dailyValue = Convert.ToDouble(roomTypeDAO.GetDailyValueByRoomTypeID(roomTypeID).Data);

                int days = checkout.ExitDate.Day - checkin.ExitDate.Day;

                checkout.ExitOnTime = false;
                checkout.Penalty = dailyValue * days;
            }

        }

    }
}
