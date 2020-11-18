using BussinesLogicalLayer;
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
    public partial class FormInsertProduct : Form {
        public FormInsertProduct() {
            InitializeComponent();
        }
        Product product = new Product();
        ProductBLL productBLL = new ProductBLL();

        private void btnInsert_Click(object sender, EventArgs e)
        {
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = Convert.ToDouble(txtPrice.Text);
            product.ProfitMargin = Convert.ToDouble(txtProfitMargin.Text);
            product.Validity = dtpValidity.Value;
            MessageBox.Show(productBLL.Insert(product).Message);
        }
    }
}
