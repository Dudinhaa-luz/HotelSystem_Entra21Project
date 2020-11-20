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
using BussinesLogicalLayer;

namespace PresentationLayer {
    public partial class FormUpdateTypeRoom : Form {
        public FormUpdateTypeRoom() {
            InitializeComponent();
        }

        RoomTypeBLL roomTypeBLL = new RoomTypeBLL();
        RoomType roomType = new RoomType();
        SearchObject search = new SearchObject();

        private void FormUpdateTypeRoom_Load(object sender, EventArgs e) {

            cmbSearch.SelectedIndex = 1;
            dgvRoomsType.DataSource = roomTypeBLL.GetAllRoomsType().Data;

        }

        private void dgvClients_SelectionChanged_1(object sender, EventArgs e) {
            this.txtDescription.Text = Convert.ToString(this.dgvRoomsType.CurrentRow.Cells["Description"].Value);
            this.txtValue.Text = Convert.ToString(this.dgvRoomsType.CurrentRow.Cells["Value"].Value);
            this.txtDailyValue.Text = Convert.ToString(this.dgvRoomsType.CurrentRow.Cells["DailyValue"].Value);
            this.txtGuestsNumber.Text = Convert.ToString(this.dgvRoomsType.CurrentRow.Cells["GuestNumber"].Value);
            this.roomType.ID = Convert.ToInt32(this.dgvRoomsType.CurrentRow.Cells["ID"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {

            roomType.Description = txtDescription.Text;
            roomType.Value = Convert.ToDouble(txtValue.Text);
            roomType.DailyValue = Convert.ToDouble(txtDailyValue.Text);
            roomType.GuestNumber = Convert.ToInt32(txtGuestsNumber.Text);
            if (ckbActive.Checked)
            {
                roomType.Active = true;
            }
            else
            {
                roomType.Active = false;
            }

            MessageBox.Show(roomTypeBLL.Update(roomType).Message);
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            
            if (cmbSearch.Text == "Descrição")
            {
                search.SearchDescription = txtSource.Text;
                dgvRoomsType.DataSource = roomTypeBLL.GetAllRoomsTypeByDescription(search).Data;
            }
            else
            {
                if (txtSource.Text == "")
                {
                 dgvRoomsType.DataSource = roomTypeBLL.GetAllRoomsType().Data;
                    return;
                }
                else
                {
                    search.SearchID = Convert.ToInt32(txtSource.Text);
                    dgvRoomsType.DataSource = roomTypeBLL.GetById(search.SearchID).Data;
                }
                
            }
        }

    }
}
