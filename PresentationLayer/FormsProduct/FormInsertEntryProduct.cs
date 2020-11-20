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

namespace PresentationLayer
{
    public partial class txtName : Form {
        public txtName() {
            InitializeComponent();
        }

        EmployeeBLL employeeBLL = new EmployeeBLL();
        SupplierBLL supplierBLL = new SupplierBLL();
        Product product = new Product();
        ProductBLL productBLL = new ProductBLL();
        ProductIncome productIncome = new ProductIncome();
        ProductIncomeBLL productIncomeBLL = new ProductIncomeBLL();
        ProductIncomeDetailBLL productIncomeDetailBLL = new ProductIncomeDetailBLL();
        SearchObject search = new SearchObject();

        private void FormInsertEntryProduct_Load(object sender, EventArgs e) {
            cmbSearch.SelectedIndex = 1;
            if (!(productBLL.GetAllProductsByActive() == null)) {
                dgvInsertProduct.DataSource = productBLL.GetAllProductsByActive().Data;
            }
        }

        private void txtIDEmployee_Leave(object sender, EventArgs e) {
            if (txtIDEmployee.Text != "") {
                search.SearchID = Convert.ToInt32(txtIDEmployee.Text);
                txtNameEmployee.Text = employeeBLL.GetNameByEmployeeID(search).Data.Name;
            }
        }

        private void txtIDSupplier_Leave(object sender, EventArgs e) {
            if (txtIDSupplier.Text != "") {
                search.SearchID = Convert.ToInt32(txtIDSupplier.Text);
                txtNameSupplier.Text = supplierBLL.GetCompanyNameSupplierByID(search).Data.CompanyName;
            }
        }


        private void txtNameSupplier_Leave(object sender, EventArgs e) {

            if (txtNameSupplier.Text != "") {
                search.SearchName = txtNameSupplier.Text;
                txtIDSupplier.Text = Convert.ToString(supplierBLL.GetIDSuppliersByCompanyName(search).Data.ID);
            }
        }

        private void txtNameEmployee_TextChanged(object sender, EventArgs e) {
            if (txtNameEmployee.Text != "") {
                search.SearchName = txtNameEmployee.Text;
                txtIDEmployee.Text = Convert.ToString(employeeBLL.GetIDByEmployeeName(search).Data.ID);
            }
        }

        private void dgvInsertProduct_SelectionChanged(object sender, EventArgs e) {
            this.txtNameProduct.Text = Convert.ToString(this.dgvInsertProduct.CurrentRow.Cells["Name"].Value);
            this.txtDescription.Text = Convert.ToString(this.dgvInsertProduct.CurrentRow.Cells["Description"].Value);
            this.txtPrice.Text = Convert.ToString(this.dgvInsertProduct.CurrentRow.Cells["Price"].Value);
            this.product.ProfitMargin = Convert.ToDouble(this.dgvInsertProduct.CurrentRow.Cells["ProfitMargin"].Value);
            this.product.ID = Convert.ToInt32(this.dgvInsertProduct.CurrentRow.Cells["ID"].Value);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            if (txtSource.Text == "") {
                dgvInsertProduct.DataSource = productBLL.GetAllProductsByActive().Data;
                return;
            } else if (cmbSearch.Text == "Nome") {
                search.SearchName = txtSource.Text;
                dgvInsertProduct.DataSource = productBLL.GetAllProductsByName(search).Data;
            } else {
                search.SearchID = Convert.ToInt32(txtSource.Text);
                dgvInsertProduct.DataSource = productBLL.GetAllProductsByID(search.SearchID).Data;
            }
        }

        private void btnInsertProductsIncomeDetail_Click(object sender, EventArgs e) {
            ProductIncomeDetail productIncomeDetail = new ProductIncomeDetail();

            productIncomeDetail.IDProduct = product.ID;
            productIncomeDetail.Price = Convert.ToDouble(txtPrice.Text);
            productIncomeDetail.Quantity = Convert.ToDouble(txtQuantity.Text);

            productIncome.Items.Add(productIncomeDetail);
            MessageBox.Show("Produto vinculado com sucesso!");

            if (productIncome.Items.Count == 0) {
                MessageBox.Show("É necessário vincular produtos.");
            }
        }

        private void btnFinish_Click(object sender, EventArgs e) {
            productIncome.SuppliersID = Convert.ToInt32(txtIDSupplier.Text);

            productIncomeBLL.Insert(productIncome);
        }
    }
}
