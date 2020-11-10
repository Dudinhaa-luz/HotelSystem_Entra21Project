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
    public partial class FormProduct : Form {
        public FormProduct() {
            InitializeComponent();
        }
        private void OpenForm(object form) {
            if (this.pnlInitialClient.Controls.Count > 0)
                this.pnlInitialClient.Controls.RemoveAt(0);
                Form fh = form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlInitialClient.Controls.Add(fh);
                this.pnlInitialClient.Tag = fh;
                fh.Show();
            
        }
        private void btnInsert_Click(object sender, EventArgs e) {

            OpenForm(new FormInsertProduct());
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
        }

        private void btnDelete_Click(object sender, EventArgs e) {
        }

        private void FormInitialScreem_Load(object sender, EventArgs e) {
        }
    }
}
