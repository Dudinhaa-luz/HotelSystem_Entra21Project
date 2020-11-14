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
    public partial class FormDeleteProduct : Form {
        public FormDeleteProduct() {
            InitializeComponent();
        }
        ProductBLL productBLL = new ProductBLL();
        Product product = new Product();
        SearchObject searchObject = new SearchObject();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productBLL.Delete(product);
        }
        private void FormDeleteProduct_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 1;
            dgvProducts.DataSource = productBLL.GetAllProductsByActive().Data;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Nome")
            {
                searchObject.SearchName = txtSource.Text;
                dgvProducts.DataSource = productBLL.GetAllProductsByName(searchObject);
            }
            else if (cmbSearch.Text == "ID")
            {
                searchObject.SearchID = Convert.ToInt32(txtSource.Text);
                dgvProducts.DataSource = productBLL.GetAllProductsByID(searchObject.SearchID);
            }
        }
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            this.product.ID = Convert.ToInt32(this.dgvProducts.CurrentRow.Cells["ID"].Value);
        }
    }
}
