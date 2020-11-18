using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Entities;
using DataAccessObject.Infrastructure;
using Common.Infrastructure;
using DataAccessObject;
using BussinesLogicalLayer;

namespace PresentationLayer {
    public partial class FormUpdateEmployee : Form {
        public FormUpdateEmployee() {
            InitializeComponent();
        }

        EmployeeBLL employeeBLL = new EmployeeBLL();
        Employee employee = new Employee();
        SearchObject search = new SearchObject();

        private void FormUpdateEmployee_Load(object sender, EventArgs e) {
            cmbSearch.SelectedIndex = 1;
            dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByActive().Data;
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e) {
            this.txtName.Text = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Name"].Value);
            this.txtPhoneNumber.Text = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["PhoneNumber"].Value);
            this.txtEmail.Text = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Email"].Value);
            this.txtAddress.Text = Convert.ToString(this.dgvEmployees.CurrentRow.Cells["Address"].Value);
            this.employee.ID = Convert.ToInt32(this.dgvEmployees.CurrentRow.Cells["ID"].Value);
        }

        private void button1_Click(object sender, EventArgs e) {
            employee.Email = txtEmail.Text;
            employee.Address = txtAddress.Text;
            employee.Name = txtName.Text;
            employee.PhoneNumber = txtPhoneNumber.Text;

            MessageBox.Show(employeeBLL.Update(employee).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            if (cmbSearch.Text == "Nome") {
                search.SearchName = txtSource.Text;
                dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByName(search).Data;
            } else if (cmbSearch.Text == "CPF") {
                search.SearchCPF = txtSource.Text;
                dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByCPF(search).Data;
            } else {
                search.SearchID = Convert.ToInt32(txtSource.Text);
                dgvEmployees.DataSource = employeeBLL.GetEmployeesByID(search.SearchID).Data;
            }
        }
    }       
}
