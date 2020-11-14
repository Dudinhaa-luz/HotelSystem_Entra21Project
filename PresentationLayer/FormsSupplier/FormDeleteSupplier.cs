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
    public partial class FormDeleteSupplier : Form {
        public FormDeleteSupplier() {
            InitializeComponent();
        }

        SupplierBLL supllierBLL = new SupplierBLL();
        Supplier suppliers = new Supplier();
        SearchObject searchObject = new SearchObject();

        private void btnDelete_Click(object sender, EventArgs e) {
            supllierBLL.Delete(suppliers);
        }

        private void FormDeleteSupplier_Load(object sender, EventArgs e) {
            cmbSearch.SelectedIndex = 1;
            dgvSuppliers.DataSource = supllierBLL.GetAllSuppliersByActive().Data;
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {

            if (cmbSearch.Text == "Razão Social") {
                searchObject.SearchName = txtSource.Text;
                dgvSuppliers.DataSource = supllierBLL.GetAllSuppliersByCompanyName(searchObject);
            } else if (cmbSearch.Text == "CNPJ") {
                searchObject.SearchCPF = txtSource.Text;
                dgvSuppliers.DataSource = supllierBLL.GetAllSuppliersByCNPJ(searchObject);
            } else {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvSuppliers.DataSource = supllierBLL.GetSuppliersById(searchObject.SearchID);
            }
        }

        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e) {
            this.suppliers.ID = Convert.ToInt32(this.dgvSuppliers.CurrentRow.Cells["ID"].Value);
        }
    }
}
