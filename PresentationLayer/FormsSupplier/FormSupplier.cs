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
    public partial class FormSupplier : Form {
        public FormSupplier() {
            InitializeComponent();
        }
        private void OpenForm(object form) {
            if (this.pnlInitialSupplier.Controls.Count > 0)
                this.pnlInitialSupplier.Controls.RemoveAt(0);
                Form fh = form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlInitialSupplier.Controls.Add(fh);
                this.pnlInitialSupplier.Tag = fh;
                fh.Show();
            
        }
        private void btnInsert_Click(object sender, EventArgs e) {

            OpenForm(new FormInsertSupplier());
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            OpenForm(new FormUpdateSupplier());
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            OpenForm(new FormDeleteSupplier());
        }

        private void FormInitialScreem_Load(object sender, EventArgs e) {
            OpenForm(new FormInsertSupplier());
        }
    }
}
