using BussinesLogicalLayer;
using Common.Infrastructure;
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
    public partial class FormDeleteEmployee : Form {
        public FormDeleteEmployee() {
            InitializeComponent();
        }

        EmployeeBLL employeeBLL = new EmployeeBLL();
        Employee employee = new Employee;
        SearchObject searchObject = new SearchObject();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(employeeBLL.Delete(employee).Message);
            dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByActive().Data;
        }

        private void FormDeleteEmployee_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 1;
            dgvEmployees.DataSource = employeeBLL.GetAllEmployeesByActive().Data;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
