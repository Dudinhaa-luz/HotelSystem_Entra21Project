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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUpdateTypeRoom = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnUpdateTypeRoom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnInsertTypeRoom);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Location = new System.Drawing.Point(519, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 32);
            this.panel4.TabIndex = 7;
            // 
            // btnUpdateTypeRoom
            // 
            this.btnUpdateTypeRoom.BackColor = System.Drawing.Color.Black;
            this.btnUpdateTypeRoom.FlatAppearance.BorderSize = 0;
            this.btnUpdateTypeRoom.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnUpdateTypeRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTypeRoom.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTypeRoom.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTypeRoom.Image = global::PresentationLayer.Properties.Resources.quartos;
            this.btnUpdateTypeRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateTypeRoom.Location = new System.Drawing.Point(519, 7);
            this.btnUpdateTypeRoom.Name = "btnUpdateTypeRoom";
            this.btnUpdateTypeRoom.Size = new System.Drawing.Size(240, 32);
            this.btnUpdateTypeRoom.TabIndex = 8;
            this.btnUpdateTypeRoom.Text = "       ATUALIZAR TIPO DE QUARTO";
            this.btnUpdateTypeRoom.UseVisualStyleBackColor = false;
            this.btnUpdateTypeRoom.Click += new System.EventHandler(this.btnUpdateTypeRoom_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(255, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 32);
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
            this.btnInsertTypeRoom.Location = new System.Drawing.Point(258, 7);
            this.btnInsertTypeRoom.Name = "btnInsertTypeRoom";
            this.btnInsertTypeRoom.Size = new System.Drawing.Size(240, 32);
            this.btnInsertTypeRoom.TabIndex = 7;
            this.btnInsertTypeRoom.Text = "        CADASTRAR TIPO DE QUARTO";
            this.btnInsertTypeRoom.UseVisualStyleBackColor = false;
            this.btnInsertTypeRoom.Click += new System.EventHandler(this.btnInsertTypeRoom_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel8.Location = new System.Drawing.Point(24, 7);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 32);
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
            this.btnInsert.Location = new System.Drawing.Point(27, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(214, 32);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "CADASTRAR";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pnlInitialRoom
            // 
            this.pnlInitialRoom.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlInitialRoom.Location = new System.Drawing.Point(12, 48);
            this.pnlInitialRoom.Name = "pnlInitialRoom";
            this.pnlInitialRoom.Size = new System.Drawing.Size(1056, 532);
            this.pnlInitialRoom.TabIndex = 1;
            // 
            // FormRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1040, 592);
            this.Controls.Add(this.pnlInitialRoom);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnUpdateTypeRoom;
    }
}