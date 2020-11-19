using BussinesLogicalLayer;
using Common.Infrastructure;
using DataAccessObject;
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
    public partial class FormInsertSupplier : Form{
        public FormInsertSupplier() {
            InitializeComponent();
        }

        Product product = new Product();
        public Supplier supplier = new Supplier();
        SupplierBLL supplierBLL = new SupplierBLL();
        ProductBLL productBLL = new ProductBLL();
        SearchObject searchObject = new SearchObject();

        private void button1_Click(object sender, EventArgs e) {
            supplier.CompanyName = txtCompanyName.Text;
            supplier.ContactName = txtContactName.Text;
            supplier.CNPJ = txtCNPJ.Text;
            supplier.Email = txtEmail.Text;
            supplier.PhoneNumber = txtPhoneNumber.Text;

            if (supplier.Items.Count == 0) {
                MessageBox.Show("Vincule produtos ao fornecedor");
            }

            MessageBox.Show(supplierBLL.Insert(supplier).Message);
        }

        private void FormInsertSupplier_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            if (!(productBLL.GetAllProductsByActive() == null)) {
                dgvProducts.DataSource = productBLL.GetAllProductsByActive().Data;
            }

        }

        private void btnLink_Click(object sender, EventArgs e) {
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = Convert.ToDouble(txtPrice.Text);
            product.ProfitMargin = Convert.ToDouble(txtProfitMargin.Text);

            MessageBox.Show(productBLL.LinkProductToSupplier(product, supplier).Message);
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e) {
            this.txtName.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Name"].Value);
            this.txtDescription.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Description"].Value);
            this.txtPrice.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Price"].Value);
            this.txtProfitMargin.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["ProfitMargin"].Value);
            this.product.ID = Convert.ToInt32(this.dgvProducts.CurrentRow.Cells["ID"].Value);
            this.product.IsActive = Convert.ToBoolean(this.dgvProducts.CurrentRow.Cells["IsActive"].Value);
            this.product.Storage = Convert.ToDouble(this.dgvProducts.CurrentRow.Cells["Storage"].Value);
            this.product.Validity = (DateTime)(this.dgvProducts.CurrentRow.Cells["Validity"].Value);

        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            if (cmbSearch.Text == "Nome") {
                searchObject.SearchName = txtSource.Text;
                dgvProducts.DataSource = productBLL.GetAllProductsByName(searchObject);
            } else {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvProducts.DataSource = productBLL.GetAllProductsByID(searchObject.SearchID);
            }
        }
    }
}
