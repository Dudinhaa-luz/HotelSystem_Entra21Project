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

namespace PresentationLayer {
    public partial class FormUpdateProduct : Form {
        public FormUpdateProduct() {
            InitializeComponent();
        }

        ClientDAO clientDAO = new ClientDAO();
        Client client = new Client();
        SearchObject search = new SearchObject();



        private void FormUpdateClient_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            dgvClients.DataSource = clientDAO.GetAllClientsByActive().Data;

        }

        private void dgvClients_SelectionChanged_1(object sender, EventArgs e) {
            this.txtName.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Name"].Value);
            this.txtPhoneNumber1.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber1"].Value);
            this.txtPhoneNumber2.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["PhoneNumber2"].Value);
            this.txtDescription.Text = Convert.ToString(this.dgvClients.CurrentRow.Cells["Email"].Value);
            this.client.ID = Convert.ToInt32(this.dgvClients.CurrentRow.Cells["ID"].Value);
        }

        private void button1_Click(object sender, EventArgs e) {

            client.Name = txtName.Text;
            client.PhoneNumber1 = txtPhoneNumber1.Text;
            client.PhoneNumber2 = txtPhoneNumber2.Text;
            client.Email = txtDescription.Text;

            //dando erro (no método update cai direto no catch)- tem que passar pelo BLL

            MessageBox.Show(clientDAO.Update(client).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            search.SearchName = txtSource.Text;
            //dgvClients.DataSource = clientDAO.GetAllClientsByName(search).Data;
        }
    }
}
