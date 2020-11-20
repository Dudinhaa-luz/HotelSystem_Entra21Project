using BussinesLogicalLayer;
using Common.Infrastructure;
using Entities;
using Entities.QueryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentationLayer {
    public partial class FormInsertCheckIn : Form {
        public FormInsertCheckIn() {
            InitializeComponent();
        }

        CheckinClient checkinClient = new CheckinClient();
        CheckinClientsBLL checkinClientBLL = new CheckinClientsBLL();
        ClientBLL clientBLL = new ClientBLL();
        Client client = new Client();
        RoomBLL roomBLL = new RoomBLL();
        Room room = new Room();
        RoomType roomType = new RoomType();
        RoomTypeBLL roomTypeBLL = new RoomTypeBLL();
        EmployeeBLL employeeBLL = new EmployeeBLL();
        Employee employee = new Employee();
        SearchObject search = new SearchObject();
        RoomQueryModel roomQueryModel = new RoomQueryModel();

        private void btnInsert_Click(object sender, EventArgs e) {
            checkinClient.ExitDate = dtpExitDate.Value;
            checkinClient.ClientID = client.ID;
            checkinClient.EmployeesID = employee.ID;
            checkinClient.RoomID = room.ID;
            MessageBox.Show(checkinClientBLL.Insert(checkinClient).Message);
            roomBLL.UpdateOcuppyRoom(room);
        }
 
        private void FormInsertCheckIn_Load(object sender, EventArgs e)
        {
            cmbSearchClient.SelectedIndex = 1;
            dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;
            cmbSearchRoom.SelectedIndex = 1;
            dgvRooms.DataSource = roomTypeBLL.GetAllRoomsType().Data;
            cmbSearchEmployee.SelectedIndex = 1;
            dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByActive().Data;
        }
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            client.Name = Convert.ToString(this.dgvClients.CurrentRow.Cells["Name"].Value);
            client.PhoneNumber1 = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber1"].Value);
            client.PhoneNumber2 = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber2"].Value);
            client.Email = Convert.ToString(this.dgvClients.CurrentRow.Cells["Email"].Value);
            client.ID = Convert.ToInt32(this.dgvClients.CurrentRow.Cells["ID"].Value);
        }
        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            room.ID = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["ID"].Value);
            room.Description = Convert.ToString(this.dgvRooms.CurrentRow.Cells["Description"].Value);
            room.IDRoomType = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["ID"].Value);
            roomType.DailyValue = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["DailyValue"].Value);
            roomType.GuestNumber = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["GuestNumber"].Value);
            roomType.Value = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["Value"].Value);
        }
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            employee.Name = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Name"].Value);
            employee.PhoneNumber = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["PhoneNumber"].Value);
            employee.Email = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Email"].Value);
            employee.Address = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Address"].Value);
            employee.ID = Convert.ToInt32(this.dgvEmployees.CurrentRow.Cells["ID"].Value);
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchClient.Text == "Nome")
            {
                search.SearchName = txtSearchClient.Text;
                dgvClients.DataSource = clientBLL.GetAllClientsByName(search).Data;
            }
            else if (cmbSearchClient.Text == "CPF")
            {
                search.SearchCPF = txtSearchClient.Text;
                dgvClients.DataSource = clientBLL.GetAllClientsByCPF(search).Data;
            }
            else
            {
                if (txtSearchClient.Text == "")
                {
                    dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;
                    return;
                }
                else
                {
                    search.SearchID = Convert.ToInt32(txtSearchClient.Text);
                    dgvClients.DataSource = clientBLL.GetClientsByID(search.SearchID).Data;
                }

            }
        }

        private void txtSearchRoom_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchRoom.Text == "Descrição")
            {
                search.SearchDescription = txtSearchRoom.Text;
                dgvRooms.DataSource = roomTypeBLL.GetAllRoomsTypeByDescription(search).Data;
            }
            else
            {
                if (txtSearchRoom.Text == "")
                {
                    dgvRooms.DataSource = roomTypeBLL.GetAllRoomsType().Data;
                    return;
                }
                else
                {
                    search.SearchID = Convert.ToInt32(txtSearchRoom.Text);
                    dgvRooms.DataSource = roomTypeBLL.GetById(search.SearchID).Data;
                }

            }
        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchEmployee.Text == "")
            {
                dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByActive().Data;
                return;
            }
            else if (cmbSearchEmployee.Text == "Nome")
            {
                search.SearchName = txtSearchEmployee.Text;
                dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByName(search).Data;
            }
            else if (cmbSearchEmployee.Text == "CPF")
            {
                search.SearchCPF = txtSearchEmployee.Text;
                dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByCPF(search).Data;
            }
            else
            {
                    search.SearchID = Convert.ToInt32(txtSearchEmployee.Text);
                    dgvEmployees.DataSource = employeeBLL.GetEmployeesByID(search.SearchID).Data;
            }
        }
    }
    
}

