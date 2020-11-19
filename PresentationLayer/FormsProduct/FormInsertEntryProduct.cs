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
    public partial class FormInsertEntryProduct : Form
    {
        public FormInsertEntryProduct()
        {
            InitializeComponent();
        }
        ProductIncome productIncome = new ProductIncome();
        ProductIncomeDetail productIncomeDetail = new ProductIncomeDetail();
        Product product = new Product();
        ProductBLL productBLL = new ProductBLL();
        SupplierBLL supplierBLL = new SupplierBLL();
        ProductIncomeBLL productIncomeBLL = new ProductIncomeBLL();
        ProductIncomeDetailBLL productIncomeDetailBLL = new ProductIncomeDetailBLL();
        Storage storage = new Storage();
        StorageBLL storageBLL = new StorageBLL();
        SearchObject search = new SearchObject();

        private void btnInsert_Click(object sender, EventArgs e)
        {
            productIncome.EntryDate = dtpEntryDate.Value;
            //List<ProductIncomeDetail> items = 
            productIncome.SuppliersID = Convert.ToInt32(txtIDSupplier.Text);
            productIncomeDetail.Price = Convert.ToDouble(txtPrice.Text);
            productIncomeDetail.Quantity = Convert.ToDouble(txtQuantity.Text);
            productIncomeBLL.Insert(productIncome);
            storage.Quantity = productIncomeDetail.Quantity;
            storageBLL.AddProduct(productIncomeDetail);
        }
        private void FormInsertEntryProduct_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = productBLL.GetAllProductsByActive().Data;
        }
        private void txtSource_TextChanged(object sender, EventArgs e)
        {
         
             if (cmbSearch.Text == "Nome")
            {
                search.SearchName = txtSource.Text;
                dgvProducts.DataSource = productBLL.GetAllProductsByName(search).Data;
            }
            else
            {
                if (txtSource.Text == "")
                {
                    dgvProducts.DataSource = productBLL.GetAllProductsByActive().Data;
                    return;
                }
                search.SearchID = Convert.ToInt32(txtSource.Text);
                    dgvProducts.DataSource = productBLL.GetAllProductsByID(search.SearchID).Data;
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            this.txtDescription.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Description"].Value);
            this.txtPrice.Text = Convert.ToString(this.dgvProducts.CurrentRow.Cells["Price"].Value);
            this.productIncome.ID = Convert.ToInt32(this.dgvProducts.CurrentRow.Cells["ID"].Value);
            this.product.ID = Convert.ToInt32(this.dgvProducts.CurrentRow.Cells["ID"].Value);
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {

        }
        private void txtIDSupplier_TextChanged(object sender, EventArgs e)
        {
            search.SearchID = Convert.ToInt32(txtIDSupplier.Text);
            //txtNameSupplier.Text = supplierBLL.GetCompanyNameSupplierByID(search.SearchID).Data.ID;
        }
        private void dgvProductsEntry_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
