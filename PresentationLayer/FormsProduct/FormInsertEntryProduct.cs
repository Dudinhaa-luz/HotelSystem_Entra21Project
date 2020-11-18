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

namespace PresentationLayer
{
    public partial class FormInsertEntryProduct : Form
    {
        public FormInsertEntryProduct()
        {
            InitializeComponent();
        }
        ProductIncome productIncome = new ProductIncome();
        ProductIncomeBLL productIncomeBLL = new ProductIncomeBLL();

        private void btnInsert_Click(object sender, EventArgs e)
        {
            productIncome.EntryDate = dtpEntryDate.Value;
           // productIncome.TotalValue = Convert.ToDouble(txtTotalValue.Text);
            productIncomeBLL.Insert(productIncome);
        }

       
    }
}