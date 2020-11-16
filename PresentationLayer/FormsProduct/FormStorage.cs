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
using BussinesLogicalLayer;
using Common.Infrastructure;

namespace PresentationLayer {
    public partial class FormStorage : Form {
        public FormStorage() {
            InitializeComponent();
        }

        ProductBLL productBLL = new ProductBLL();
        StorageBLL storageBLL = new StorageBLL();
        Product product = new Product();
        Storage storage = new Storage();
        SearchObject searchObject = new SearchObject();

        private void FormUpdateProduct_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            if (!(storageBLL.GetAllStorage() == null))
            {
                dgvStorage.DataSource = storageBLL.GetAllStorage().Data;
            }
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {

            if (cmbSearch.Text == "NOME PRODUTO")
            {
                searchObject.SearchName = txtSource.Text;
                dgvStorage.DataSource = productBLL.GetAllProductsByName(searchObject);
            }
            else if (cmbSearch.Text == "ID PRODUTO")
            {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvStorage.DataSource = storageBLL.GetAllStorageByIDProducts(product);
            }
            else
            {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvStorage.DataSource = storageBLL.GetById(searchObject.SearchID);
            }
        }
    }
}
