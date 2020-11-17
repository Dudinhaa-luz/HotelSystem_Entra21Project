namespace PresentationLayer
{
    partial class FormReservation {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReservation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInsertClient = new System.Windows.Forms.Button();
            this.btnInsertRoom = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.pnlInitialEmployee = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnInsertClient);
            this.panel1.Controls.Add(this.btnInsertRoom);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(464, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 36);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(244, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 36);
            this.panel2.TabIndex = 6;
            // 
            // btnInsertClient
            // 
            this.btnInsertClient.BackColor = System.Drawing.Color.Black;
            this.btnInsertClient.FlatAppearance.BorderSize = 0;
            this.btnInsertClient.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsertClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertClient.ForeColor = System.Drawing.Color.White;
            this.btnInsertClient.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertClient.Image")));
            this.btnInsertClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertClient.Location = new System.Drawing.Point(467, 3);
            this.btnInsertClient.Name = "btnInsertClient";
            this.btnInsertClient.Size = new System.Drawing.Size(214, 36);
            this.btnInsertClient.TabIndex = 5;
            this.btnInsertClient.Text = "VINCULAR CLIENTE";
            this.btnInsertClient.UseVisualStyleBackColor = false;
            this.btnInsertClient.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsertRoom
            // 
            this.btnInsertRoom.BackColor = System.Drawing.Color.Black;
            this.btnInsertRoom.FlatAppearance.BorderSize = 0;
            this.btnInsertRoom.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsertRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertRoom.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertRoom.ForeColor = System.Drawing.Color.White;
            this.btnInsertRoom.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertRoom.Image")));
            this.btnInsertRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertRoom.Location = new System.Drawing.Point(247, 3);
            this.btnInsertRoom.Name = "btnInsertRoom";
            this.btnInsertRoom.Size = new System.Drawing.Size(214, 36);
            this.btnInsertRoom.TabIndex = 5;
            this.btnInsertRoom.Text = "VINCULAR QUARTO";
            this.btnInsertRoom.UseVisualStyleBackColor = false;
            this.btnInsertRoom.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel8.Location = new System.Drawing.Point(24, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 36);
            this.panel8.TabIndex = 4;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Black;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Image = global::PresentationLayer.Properties.Resources.Reservas1;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(27, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(214, 36);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "INSERIR RESERVA";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pnlInitialEmployee
            // 
            this.pnlInitialEmployee.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlInitialEmployee.Location = new System.Drawing.Point(12, 48);
            this.pnlInitialEmployee.Name = "pnlInitialEmployee";
            this.pnlInitialEmployee.Size = new System.Drawing.Size(1056, 532);
            this.pnlInitialEmployee.TabIndex = 1;
            // 
            // FormReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1040, 592);
            this.Controls.Add(this.pnlInitialEmployee);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReservation";
            this.Text = "FormInitialScreem";
            this.Load += new System.EventHandler(this.FormInitialScreem_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInsertClient;
        private System.Windows.Forms.Button btnInsertRoom;
        private System.Windows.Forms.Panel pnlInitialEmployee;
    }
}