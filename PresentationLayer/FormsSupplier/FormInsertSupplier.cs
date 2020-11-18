using BussinesLogicalLayer;
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
    public partial class FormInsertSupplier : Form {
        public FormInsertSupplier() {
            InitializeComponent();
        }

        Supplier supplier = new Supplier();
        SupplierBLL supplierBLL = new SupplierBLL();

        private void button1_Click(object sender, EventArgs e) {
            supplier.CompanyName = txtCompanyName.Text;
            supplier.ContactName = txtContactName.Text;
            supplier.CNPJ = txtCNPJ.Text;
            supplier.Email = txtEmail.Text;
            supplier.PhoneNumber = txtPhoneNumber.Text;
            MessageBox.Show(supplierBLL.Insert(supplier).Message);   
        }
    }
}
