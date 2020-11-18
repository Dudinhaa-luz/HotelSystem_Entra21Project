using BussinesLogicalLayer;
using Common.Infrastructure;
using Entities;
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
    public partial class FormDeleteClient : Form {
        public FormDeleteClient() {
            InitializeComponent();
        }

        ClientBLL clientBLL = new ClientBLL();
        Client client = new Client();
        SearchObject searchObject = new SearchObject();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(clientBLL.Delete(client).Message);
            dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;
        }

        private void FormDeleteClient_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 1;
            dgvClients.DataSource = clientBLL.GetAllClientsByActive().Data;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
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
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            this.client.ID = Convert.ToInt32(this.dgvClients.CurrentRow.Cells["ID"].Value);
        }

    }
}
