using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentationLayer
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnRestore.Visible = true;
        }

        private void btnRestore_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            btnMaximize.Visible = true;
            btnRestore.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlHigher_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void OpenForm(object form) {

            if (this.pnlMiddle.Controls.Count>0) 
                this.pnlMiddle.Controls.RemoveAt(0);
                Form fh = form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlMiddle.Controls.Add(fh);
                this.pnlMiddle.Tag = fh;
                fh.Show();
            
        }
        private void button5_Click(object sender, EventArgs e) {
            OpenForm(new FormInitialScreem());
        }

        private void btnProducts_Click(object sender, EventArgs e) {
            OpenForm(new FormProduct());
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            OpenForm(new FormRoom());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenForm(new FormEmployee());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenForm(new FormSupplier());
        }
    
    }
}
