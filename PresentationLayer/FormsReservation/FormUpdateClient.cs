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
    public partial class FormUpdateClient : Form {
        public FormUpdateClient() {
            InitializeComponent();
        }

        ClientBLL clientBLL = new ClientBLL();
        Client client = new Client();
        SearchObject search = new SearchObject();



        private void FormUpdateClient_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;

        }

        private void dgvClients_SelectionChanged_1(object sender, EventArgs e) {
            this.txtName.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Name"].Value);
            this.txtPhoneNumber.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber1"].Value);
            this.txtEmail.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Email"].Value);
            this.client.ID = Convert.ToInt32(this.dgvClients.CurrentRow.Cells["ID"].Value);
        }

        private void button1_Click(object sender, EventArgs e) {

            client.Name = txtName.Text;
            client.PhoneNumber1 = txtPhoneNumber.Text;
            client.Email = txtEmail.Text;

            MessageBox.Show(clientBLL.Update(client).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            search.SearchName = txtSource.Text;
            dgvClients.DataSource = clientBLL.GetAllClientsByName(search).Data;
        }
    }
}
