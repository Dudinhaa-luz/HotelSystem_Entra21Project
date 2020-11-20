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
    public class CheckinClientsBLL : BaseValidator<CheckinClient>
    {
        private CheckinClientsDAO checkinClientsDAO = new CheckinClientsDAO();
        public Response Insert(CheckinClient item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return checkinClientsDAO.Insert(item);
            }
            return response;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckins()
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckins();
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyEntryDate(SearchObject search)
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckinsbyEntryDate(search);
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyExitDate(SearchObject search)
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckinsbyExitDate(search);
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyClientID(SearchObject search)
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckinsbyClientID(search);
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyRoomID(SearchObject search)
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckinsbyRoomID(search);
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public QueryResponse<CheckinQueryModel> GetAllCheckinsbyEmployeeID(SearchObject search)
        {
            QueryResponse<CheckinQueryModel> responseCheckinClient = checkinClientsDAO.GetAllCheckinsbyEmployeeID(search);
            List<CheckinQueryModel> temp = responseCheckinClient.Data;
            foreach (CheckinQueryModel item in temp)
            {
                item.ClientCPF = item.ClientCPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
                item.ClientPhoneNumber = item.ClientPhoneNumber.Insert(0, "+").Insert(3, "(").Insert(6, ")").Insert(12, "-");
            }
            return responseCheckinClient;
        }
        public override Response Validate(CheckinClient item)
        {
            return base.Validate(item);
        }

    }
}
