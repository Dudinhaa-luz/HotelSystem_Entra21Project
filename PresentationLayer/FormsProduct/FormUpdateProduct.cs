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
using BussinesLogicalLayer;

namespace PresentationLayer {
    public partial class FormUpdateProduct : Form {
        public FormUpdateProduct() {
            InitializeComponent();
        }

        ProductBLL productBLL = new ProductBLL();
        Product product = new Product();
        SearchObject search = new SearchObject();

        private void FormUpdateProduct_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            if (!(productBLL.GetAllProductsByActive() == null))
            {
                dgvProducts.DataSource = productBLL.GetAllProductsByActive().Data;
            }

        }

        private void dgvProducts_SelectionChanged_1(object sender, EventArgs e)
        {
            this.txtName.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Name"].Value);
            this.txtDescription.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Description"].Value);
            this.txtPrice.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Price"].Value);
            this.txtProfitMargin.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["ProfitMargin"].Value);
            this.product.ID = Convert.ToInt32(this.dgvProducts.CurrentRow.Cells["ID"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {

            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = Convert.ToDouble(txtPrice.Text);
            product.ProfitMargin = Convert.ToDouble(txtProfitMargin.Text);
            productBLL.Update(product);

        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            search.SearchName = txtSource.Text;
            //dgvClients.DataSource = clientDAO.GetAllClientsByName(search).Data;
        }

    }
}
