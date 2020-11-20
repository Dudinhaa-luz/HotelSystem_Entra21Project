using BussinesLogicalLayer;
using DataAccessObject;
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
    public partial class FormInsertEmployee : Form {
        public FormInsertEmployee() {
            InitializeComponent();
        }

        Employee employee = new Employee();
        EmployeeBLL employeeBLL = new EmployeeBLL();

        private void button1_Click(object sender, EventArgs e) {
            employee.Name = txtName.Text;
            employee.RG = txtRG.Text;
            employee.CPF = txtCPF.Text;
            employee.Address = txtAddress.Text;
            employee.Email = txtEmail.Text;
            employee.Password = employeeBLL.EncryptPassword(txtPassword.Text);
            employee.PhoneNumber = txtPhoneNumber1.Text;
            if (cbAdm.Checked) {
                employee.IsAdm = true;
            } else {
                employee.IsAdm = false;
            }
            MessageBox.Show(employeeBLL.Insert(employee).Message);
        }

    }
}
