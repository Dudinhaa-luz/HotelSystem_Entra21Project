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
    public partial class FormOccuppyRoom : Form {
        public FormOccuppyRoom() {
            InitializeComponent();
        }

        RoomBLL roomBLL = new RoomBLL();
        Room room = new Room();
        ReservationBLL reservationBLL = new ReservationBLL();
        Reservation reservation = new Reservation();
        SearchObject search = new SearchObject();

        private void FormUpdateClient_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            dgvRooms.DataSource = reservationBLL.GetAllReservations().Data;

        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            if (cmbSearch.Text == "Número Quarto") 
                {
                search.SearchName = txtSource.Text;
                dgvRooms.DataSource = roomBLL.GetAllOccuppyRoomsByNumberRoom(search).Data;

            } else if (cmbSearch.Text == "Data Check-In") 
                {
                search.SearchDate = dtpCheckInDate.Value;
                dgvRooms.DataSource = reservationBLL.GetAllReservationsbyReservationDate(search).Data;

            } else 
            {
                if (txtSource.Text == "") {
                    dgvRooms.DataSource = reservationBLL.GetAllReservations().Data;
                    return;

                } else {
                    search.SearchDate = dtpCheckInDate.Value;
                    dgvRooms.DataSource = reservationBLL.GetAllReservationsbyExitDate(search).Data;
                }

            }
        }

    }
}
