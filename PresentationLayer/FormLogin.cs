using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entities;
using BussinesLogicalLayer;
using System.Security.Policy;
using System.Security.Cryptography;
using Common;

namespace PresentationLayer {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }
        Employee employee = new Employee();
        EmployeeBLL employeeBLL = new EmployeeBLL();
        private void txtUser_Enter(object sender, EventArgs e) {
            if (txtUser.Text == "E-MAIL") {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e) {
            if (txtUser.Text == "") {
                txtUser.Text = "E-MAIL";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e) {
            if (txtPassword.Text == "SENHA") {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e) {
            if (txtPassword.Text == "") {
                txtPassword.Text = "SENHA";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FormLogin_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void OpenForm(object form)
        {
            Form fh = form as Form;
            fh.Show();
        }
        private void btnAccess_Click(object sender, EventArgs e)
        {
            
            Response response = employeeBLL.CheckPassword(txtUser.Text, employeeBLL.EncryptPassword(txtPassword.Text));
            if (response.Success)
            {
                OpenForm(new FormMainMenu());
                this.Visible = false;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }
    }
}
