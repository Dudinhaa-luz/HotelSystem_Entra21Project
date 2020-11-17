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


namespace PresentationLayer {
    public partial class FormInsertClient : Form {
        public FormInsertClient() {
            InitializeComponent();
        }

        Client client = new Client();
        ClientBLL clientBLL = new ClientBLL();
        
        

        private void btnInsert_Click(object sender, EventArgs e) {
            client.Name = txtName.Text;
            client.CPF = txtCPF.Text;
            client.RG = txtRG.Text;
            client.PhoneNumber1 = txtPhoneNumber1.Text;
            client.PhoneNumber2 = txtPhoneNumber2.Text;
            client.Email = txtEmail.Text;
            clientBLL.Insert(client);
        }
    }
}
