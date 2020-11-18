using BussinesLogicalLayer;
using Common;
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
        RoomBLL rommBLL = new RoomBLL();

        private void btnInsert_Click(object sender, EventArgs e) {
            room.NumberRoom = txtNumber.Text;
            room.IDRoomType = (int)cbDescription.SelectedValue;
             Response r = rommBLL.Insert(room);
            MessageBox.Show(r.Message);
        }

        private void FormInsertRoom_Load(object sender, EventArgs e)
        {
            cbDescription.DataSource = rommBLL.GetRoomTypeDescription().Data;
            cbDescription.DisplayMember = "Description";
            cbDescription.ValueMember = "ID";
        }
    }
}
