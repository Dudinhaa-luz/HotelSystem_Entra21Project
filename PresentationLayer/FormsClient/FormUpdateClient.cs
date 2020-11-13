using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Entities;
using BussinesLogicalLayer;
using Common.Infrastructure;

namespace PresentationLayer {
    public partial class FormUpdateClient : Form {
        public FormUpdateClient() {
            InitializeComponent();
        }

        ClientBLL clientBLL = new ClientBLL();
        Client client = new Client();
        SearchObject searchObject = new SearchObject();

        private void FormUpdateClient_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;
        }

        private void dgvClients_SelectionChanged_1(object sender, EventArgs e) {
            this.txtName.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Name"].Value);
            this.txtPhoneNumber1.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber1"].Value);
            this.txtPhoneNumber2.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber2"].Value);
            this.txtEmail.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Email"].Value);
            this.client.ID = Convert.ToInt32(this.dgvClients.CurrentRow.Cells["ID"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {

            client.Name = txtName.Text;
            client.PhoneNumber1 = txtPhoneNumber1.Text;
            client.PhoneNumber2 = txtPhoneNumber2.Text;
            client.Email = txtEmail.Text;

            MessageBox.Show(clientBLL.Update(client).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {

            if (cmbSearch.Text == "Nome")
            {
                searchObject.SearchName = txtSource.Text;
                dgvClients.DataSource = clientBLL.GetAllClientsByName(searchObject);
            }
            else if (cmbSearch.Text == "CPF")
            {
                searchObject.SearchCPF = txtSource.Text;
                dgvClients.DataSource = clientBLL.GetAllClientsByCPF(searchObject);
            }
            else
            {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvClients.DataSource = clientBLL.GetClientsByID(searchObject.SearchID);
            }
        }
    }
}
