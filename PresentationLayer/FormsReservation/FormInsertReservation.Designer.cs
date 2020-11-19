namespace PresentationLayer {
    partial class FormInsertReservations {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSearchRoom = new System.Windows.Forms.ComboBox();
            this.txtSourceRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.txtSourceClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.cmbSourceClient = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoom
            // 
            this.txtRoom.Enabled = false;
            this.txtRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.Location = new System.Drawing.Point(46, 329);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(272, 26);
            this.txtRoom.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(42, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Cliente";
            // 
            // txtClient
            // 
            this.txtClient.Enabled = false;
            this.txtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.Location = new System.Drawing.Point(46, 270);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(272, 26);
            this.txtClient.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 36;
            this.label2.Text = "Data Check-In";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Black;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(46, 399);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(272, 45);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "INSERIR";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(73, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 36);
            this.label1.TabIndex = 43;
            this.label1.Text = "Inserir Reserva";
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckInDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckInDate.Location = new System.Drawing.Point(208, 159);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(110, 26);
            this.dtpCheckInDate.TabIndex = 55;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCheckOutDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckOutDate.Location = new System.Drawing.Point(208, 208);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(110, 26);
            this.dtpCheckOutDate.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 21);
            this.label3.TabIndex = 56;
            this.label3.Text = "Data Check-Out";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(42, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 58;
            this.label4.Text = "Quarto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(38, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "Lembre de verificar se o quarto está disponível!";
            // 
            // cmbSearchRoom
            // 
            this.cmbSearchRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchRoom.FormattingEnabled = true;
            this.cmbSearchRoom.Items.AddRange(new object[] {
            "Numero Quarto",
            "ID"});
            this.cmbSearchRoom.Location = new System.Drawing.Point(873, 26);
            this.cmbSearchRoom.Name = "cmbSearchRoom";
            this.cmbSearchRoom.Size = new System.Drawing.Size(143, 28);
            this.cmbSearchRoom.TabIndex = 72;
            // 
            // txtSourceRoom
            // 
            this.txtSourceRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceRoom.Location = new System.Drawing.Point(517, 26);
            this.txtSourceRoom.Name = "txtSourceRoom";
            this.txtSourceRoom.Size = new System.Drawing.Size(350, 26);
            this.txtSourceRoom.TabIndex = 70;
            this.txtSourceRoom.TextChanged += new System.EventHandler(this.txtSourceRoom_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(369, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 21);
            this.label5.TabIndex = 71;
            this.label5.Text = "Inserir Quarto";
            // 
            // dgvRooms
            // 
            this.dgvRooms.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRooms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvRooms.ColumnHeadersHeight = 30;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRooms.EnableHeadersVisualStyles = false;
            this.dgvRooms.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvRooms.Location = new System.Drawing.Point(373, 69);
            this.dgvRooms.Name = "dgvRooms";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRooms.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvRooms.RowHeadersWidth = 51;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRooms.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvRooms.Size = new System.Drawing.Size(655, 190);
            this.dgvRooms.TabIndex = 67;
            this.dgvRooms.SelectionChanged += new System.EventHandler(this.dgvRooms_SelectionChanged);
            // 
            // txtSourceClient
            // 
            this.txtSourceClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceClient.Location = new System.Drawing.Point(526, 272);
            this.txtSourceClient.Name = "txtSourceClient";
            this.txtSourceClient.Size = new System.Drawing.Size(350, 26);
            this.txtSourceClient.TabIndex = 74;
            this.txtSourceClient.TextChanged += new System.EventHandler(this.txtSourceClient_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(378, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 75;
            this.label8.Text = "Inserir Cliente";
            // 
            // dgvClient
            // 
            this.dgvClient.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvClient.ColumnHeadersHeight = 30;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClient.EnableHeadersVisualStyles = false;
            this.dgvClient.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvClient.Location = new System.Drawing.Point(373, 316);
            this.dgvClient.Name = "dgvClient";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClient.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvClient.RowHeadersWidth = 51;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClient.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvClient.Size = new System.Drawing.Size(655, 190);
            this.dgvClient.TabIndex = 73;
            this.dgvClient.SelectionChanged += new System.EventHandler(this.dgvClient_SelectionChanged);
            // 
            // cmbSourceClient
            // 
            this.cmbSourceClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSourceClient.FormattingEnabled = true;
            this.cmbSourceClient.Items.AddRange(new object[] {
            "Nome",
            "CPF",
            "ID"});
            this.cmbSourceClient.Location = new System.Drawing.Point(882, 270);
            this.cmbSourceClient.Name = "cmbSourceClient";
            this.cmbSourceClient.Size = new System.Drawing.Size(134, 28);
            this.cmbSourceClient.TabIndex = 76;
            // 
            // FormInsertReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1040, 532);
            this.Controls.Add(this.cmbSourceClient);
            this.Controls.Add(this.txtSourceClient);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.cmbSearchRoom);
            this.Controls.Add(this.txtSourceRoom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInsertReservations";
            this.Text = "FormUpdateClient";
            this.Load += new System.EventHandler(this.FormInsertReservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSearchRoom;
        private System.Windows.Forms.TextBox txtSourceRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.TextBox txtSourceClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.ComboBox cmbSourceClient;
    }
}