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
    public partial class FormUpdateSupplier : Form {
        public FormUpdateSupplier() {
            InitializeComponent();
        }

        SupplierBLL supplierBLL = new SupplierBLL();
        Supplier supplier = new Supplier();
        SearchObject search = new SearchObject();

        private void FormUpdateSupplier_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 1;
            dgvSuppliers.DataSource = supplierBLL.GetAllSuppliersByActive().Data;
        }

        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            this.txtCompanyName.Text = Convert.ToString(this.dgvSuppliers.CurrentRow.Cells["CompanyName"].Value);
            this.txtContactName.Text = Convert.ToString(this.dgvSuppliers.CurrentRow.Cells["ContactName"].Value);
            this.txtPhoneNumber.Text = Convert.ToString(this.dgvSuppliers.CurrentRow.Cells["PhoneNumber"].Value);
            this.txtEmail.Text = Convert.ToString(this.dgvSuppliers.CurrentRow.Cells["Email"].Value);
            this.supplier.ID = Convert.ToInt32(this.dgvSuppliers.CurrentRow.Cells["ID"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplier.CompanyName = txtCompanyName.Text;
            supplier.PhoneNumber = txtPhoneNumber.Text;
            supplier.ContactName = txtContactName.Text;
            supplier.Email = txtEmail.Text;
            supplierBLL.Update(supplier);

            MessageBox.Show(supplierBLL.Update(supplier).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Razão Social")
            {
                search.SearchName = txtSource.Text;
                dgvSuppliers.DataSource = supplierBLL.GetAllSuppliersByCompanyName(search);
            }
            else if (cmbSearch.Text == "CNPJ")
            {
                search.SearchCPF = txtSource.Text;
                dgvSuppliers.DataSource = supplierBLL.GetAllSuppliersByCNPJ(search);
            }
            else
            {
                search.SearchID = Convert.ToInt32(txtSource.Text);
                dgvSuppliers.DataSource = supplierBLL.GetSuppliersById(search.SearchID);
            }
        }
    }
}
