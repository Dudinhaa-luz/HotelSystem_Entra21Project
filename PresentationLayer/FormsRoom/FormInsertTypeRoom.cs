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
    public partial class FormInsertTypeRoom : Form {
        public FormInsertTypeRoom() {
            InitializeComponent();
        }

        RoomType roomType = new RoomType();
        RoomTypeBLL roomTypeBLL = new RoomTypeBLL();

        private void btnInsert_Click(object sender, EventArgs e) {
            roomType.Description = txtDescription.Text;
            roomType.Value = Convert.ToDouble(txtValue.Text);
            roomType.DailyValue = Convert.ToDouble(txtDailyValue.Text);
            roomType.GuestNumber = Convert.ToInt32(txtGuestNumber.Text);
            MessageBox.Show(roomTypeBLL.Insert(roomType).Message);
        }
    }
}
