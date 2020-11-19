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
    public partial class FormUpdateReservation : Form {
        public FormUpdateReservation() {
            InitializeComponent();
        }

        ClientBLL clientBLL = new ClientBLL();
        Client client = new Client();
        SearchObject search = new SearchObject();



        private void FormUpdateClient_Load(object sender, EventArgs e) {

            cmbSearchRoom.SelectedIndex = 1;
            dgvRooms.DataSource = clientBLL.GetAllClientsByActive().Data;

        }

        private void dgvClients_SelectionChanged_1(object sender, EventArgs e) {
            this.txtClient.Text = Convert.ToString(this.dgvRooms.CurrentRow.Cells["Name"].Value);
            //this.txtPhoneNumber.Text = Convert.ToString(this.dgvRooms.CurrentRow.Cells["PhoneNumber1"].Value);
            this.txtRoom.Text = Convert.ToString(this.dgvRooms.CurrentRow.Cells["Email"].Value);
            this.client.ID = Convert.ToInt32(this.dgvRooms.CurrentRow.Cells["ID"].Value);
        }

        private void button1_Click(object sender, EventArgs e) {

            client.Name = txtClient.Text;
            //client.PhoneNumber1 = txtPhoneNumber.Text;
            client.Email = txtRoom.Text;

            MessageBox.Show(clientBLL.Update(client).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            search.SearchName = txtSourceRoom.Text;
            dgvRooms.DataSource = clientBLL.GetAllClientsByName(search).Data;
        }
    }
}
