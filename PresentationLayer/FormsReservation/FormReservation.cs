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
    public partial class FormReservation : Form {
        public FormReservation() {
            InitializeComponent();
        }
        private void OpenForm(object form) {
            if (this.pnlInitialEmployee.Controls.Count > 0)
                this.pnlInitialEmployee.Controls.RemoveAt(0);
                Form fh = form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlInitialEmployee.Controls.Add(fh);
                this.pnlInitialEmployee.Tag = fh;
                fh.Show();
            
        }

        private void btnInsert_Click(object sender, EventArgs e) {
            OpenForm(new FormInsertReservations());
        }

        private void btnVerifyRoom_Click(object sender, EventArgs e) {
            OpenForm(new FormOccuppyRoom());

        }

        private void FormReservation_Load(object sender, EventArgs e) {
            OpenForm(new FormInsertReservations());
        }
    }
}
