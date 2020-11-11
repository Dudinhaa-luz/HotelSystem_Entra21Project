namespace PresentationLayer
{
    partial class FormRoom
    {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInsertTypeRoom = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.pnlInitialRoom = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnInsertTypeRoom);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(340, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 39);
            this.panel2.TabIndex = 6;
            // 
            // btnInsertTypeRoom
            // 
            this.btnInsertTypeRoom.BackColor = System.Drawing.Color.Black;
            this.btnInsertTypeRoom.FlatAppearance.BorderSize = 0;
            this.btnInsertTypeRoom.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsertTypeRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertTypeRoom.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertTypeRoom.ForeColor = System.Drawing.Color.White;
            this.btnInsertTypeRoom.Image = global::PresentationLayer.Properties.Resources.quartos;
            this.btnInsertTypeRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertTypeRoom.Location = new System.Drawing.Point(344, 9);
            this.btnInsertTypeRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertTypeRoom.Name = "btnInsertTypeRoom";
            this.btnInsertTypeRoom.Size = new System.Drawing.Size(320, 39);
            this.btnInsertTypeRoom.TabIndex = 7;
            this.btnInsertTypeRoom.Text = "      CADASTRAR TIPO DE QUARTO";
            this.btnInsertTypeRoom.UseVisualStyleBackColor = false;
            this.btnInsertTypeRoom.Click += new System.EventHandler(this.btnInsertTypeRoom_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel8.Location = new System.Drawing.Point(32, 9);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(7, 39);
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
            this.btnInsert.Image = global::PresentationLayer.Properties.Resources.quartos;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(36, 9);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(285, 39);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "CADASTRAR";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pnlInitialRoom
            // 
            this.pnlInitialRoom.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlInitialRoom.Location = new System.Drawing.Point(16, 59);
            this.pnlInitialRoom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInitialRoom.Name = "pnlInitialRoom";
            this.pnlInitialRoom.Size = new System.Drawing.Size(1408, 655);
            this.pnlInitialRoom.TabIndex = 1;
            // 
            // FormRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1440, 729);
            this.Controls.Add(this.pnlInitialRoom);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRoom";
            this.Text = "FormInitialScreem";
            this.Load += new System.EventHandler(this.FormInitialScreem_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Panel pnlInitialRoom;
        private System.Windows.Forms.Button btnInsertTypeRoom;
        private System.Windows.Forms.Panel panel2;
    }
}