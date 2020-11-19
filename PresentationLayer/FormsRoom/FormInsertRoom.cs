using BussinesLogicalLayer;
using Common;
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
    public partial class FormInsertRoom : Form {
        public FormInsertRoom() {
            InitializeComponent();
        }

        Room room = new Room();
        RoomType roomType = new RoomType();
        RoomTypeBLL roomTypeBLL = new RoomTypeBLL();
        RoomBLL rommBLL = new RoomBLL();
        SearchObject searchObject = new SearchObject();

        private void btnInsert_Click(object sender, EventArgs e) {
            room.NumberRoom = txtNumber.Text;
            room.IDRoomType = Convert.ToInt32(txtIDRoomType.Text);
            room.Description = txtDescription.Text;
            Response r = rommBLL.Insert(room);
            MessageBox.Show(r.Message);
        }
        private void FormInsertRoom_Load(object sender, EventArgs e)
        {
            dgvTypesRoom.DataSource = rommBLL.GetAllRoomsAvailable().Data;
        }
        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (txtSource.Text == "")
            {
                dgvTypesRoom.DataSource = rommBLL.GetAllRoomsAvailable().Data;
                return;
            }
            else
            {
                searchObject.SearchDescription = txtSource.Text;
                dgvTypesRoom.DataSource = roomTypeBLL.GetAllRoomsTypeByDescription(searchObject).Data;
            }
        }

        private void dgvTypesRoom_SelectionChanged(object sender, EventArgs e)
        {
            this.txtIDRoomType.Text = Convert.ToString(this.dgvTypesRoom.CurrentRow.Cells["IDROOMS_TYPE"].Value);
            this.txtDescription.Text = Convert.ToString(this.dgvTypesRoom.CurrentRow.Cells["Description"].Value);
            this.roomType.ID = Convert.ToInt32(this.dgvTypesRoom.CurrentRow.Cells["ID"].Value);
        }
    }
}
