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
    public partial class FormRoom : Form {
        public FormRoom() {
            InitializeComponent();
        }
        private void OpenForm(object form) {
            if (this.pnlInitialRoom.Controls.Count > 0)
                this.pnlInitialRoom.Controls.RemoveAt(0);
                Form fh = form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlInitialRoom.Controls.Add(fh);
                this.pnlInitialRoom.Tag = fh;
                fh.Show();
            
        }
        private void btnInsert_Click(object sender, EventArgs e) {

            OpenForm(new FormInsertRoom());
        }
        private void btnInsertTypeRoom_Click(object sender, EventArgs e)
        {
            OpenForm(new FormInsertTypeRoom());
        }

        private void FormInitialScreem_Load(object sender, EventArgs e) {
            OpenForm(new FormInsertRoom());
        }

     
    }
}
