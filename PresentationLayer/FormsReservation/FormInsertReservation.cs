using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessObject;
using Common;
using Entities;
using DataAccessObject.Infrastructure;
using Common.Infrastructure;
using BussinesLogicalLayer;

namespace PresentationLayer {
    public partial class FormInsertReservations : Form {
        public FormInsertReservations() {
            InitializeComponent();
        }

        ReservationBLL reservationBLL = new ReservationBLL();
        Reservation reservation = new Reservation();
        ClientBLL clientBLL = new ClientBLL();
        RoomBLL roomBLL = new RoomBLL();
        SearchObject searchObject = new SearchObject();

        private void FormInsertReservations_Load(object sender, EventArgs e) {
            cmbSearchRoom.SelectedIndex = 1;
            cmbSourceClient.SelectedIndex = 1;
            dgvClient.DataSource = clientBLL.GetAllClientsByActive();
            dgvRooms.DataSource = roomBLL.GetAllRoomsAvailable();
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e) {
            this.txtRoom.Text = Convert.ToString(this.dgvRooms.CurrentRow.Cells["Description"].Value);
            reservation.RoomID = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["ID"].Value);
        }

        private void dgvClient_SelectionChanged(object sender, EventArgs e) {
            this.txtClient.Text = Convert.ToString(this.dgvRooms.CurrentRow.Cells["Name"].Value);
            reservation.ClientID = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["ID"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            dtpCheckInDate.Value = reservation.ReservationDate;
            dtpCheckOutDate.Value = reservation.ExitDatePrevision;

            MessageBox.Show(reservationBLL.Insert(reservation).Message);
        }

        private void txtSourceRoom_TextChanged(object sender, EventArgs e) {
            if (cmbSearchRoom.Text == "Número Quarto") {
                searchObject.SearchNumberRoom = txtSourceRoom.Text;
                dgvRooms.DataSource = roomBLL.GetAllRoomsByNumberRoom(searchObject).Data;
            } 
            else {
                if (txtSourceRoom.Text == "") {
                    dgvRooms.DataSource = roomBLL.GetAllRoomsAvailable().Data;
                    return;
                } else {
                    searchObject.SearchID = Convert.ToInt32(txtSourceRoom.Text);
                    dgvRooms.DataSource = roomBLL.GetById(searchObject.SearchID).Data;
                }

            }
        }

        private void txtSourceClient_TextChanged(object sender, EventArgs e) {
            if (cmbSourceClient.Text == "Nome") {
                searchObject.SearchName = txtSourceClient.Text;
                dgvClient.DataSource = clientBLL.GetAllClientsByName(searchObject).Data;
            } 
            else if (cmbSourceClient.Text == "CPF") {
                searchObject.SearchCPF = txtSourceClient.Text;
                dgvClient.DataSource = clientBLL.GetAllClientsByCPF(searchObject).Data;
            } 
            else {
                if (txtSourceClient.Text == "") {
                    dgvClient.DataSource = clientBLL.GetAllClientsByActive().Data;
                    return;
                } else {
                    searchObject.SearchID = Convert.ToInt32(txtSourceClient.Text);
                    dgvClient.DataSource = clientBLL.GetClientsByID(searchObject.SearchID).Data;
                }

            }
        }
    }
}
