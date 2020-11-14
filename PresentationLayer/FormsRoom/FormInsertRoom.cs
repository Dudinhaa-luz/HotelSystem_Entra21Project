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
    public partial class FormInsertRoom : Form {
        public FormInsertRoom() {
            InitializeComponent();
        }

        Room room = new Room();
        RoomBLL rommBLL = new RoomBLL();

        private void btnInsert_Click(object sender, EventArgs e) {
            room.NumberRoom = txtNumber.Text;
            room.Description = Convert.ToString(cbDescription.SelectedItem);
            rommBLL.Insert(room);
        }

        private void FormInsertRoom_Load(object sender, EventArgs e)
        {
            cbDescription.Items.Add(rommBLL.GetRoomTypeDescription().Data);
        }
    }
}
