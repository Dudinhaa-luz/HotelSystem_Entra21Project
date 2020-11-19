namespace PresentationLayer
{
    partial class FormInsertRoom
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTypesRoom = new System.Windows.Forms.DataGridView();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtIDRoomType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypesRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(409, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 36);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cadastro de Quarto";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Black;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInsert.Location = new System.Drawing.Point(428, 475);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(296, 45);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "CADASTRAR";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(447, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Número";
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(529, 88);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(80, 26);
            this.txtNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(361, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Pesquisar Descrição";
            // 
            // dgvTypesRoom
            // 
            this.dgvTypesRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypesRoom.Location = new System.Drawing.Point(381, 198);
            this.dgvTypesRoom.Name = "dgvTypesRoom";
            this.dgvTypesRoom.Size = new System.Drawing.Size(395, 255);
            this.dgvTypesRoom.TabIndex = 23;
            this.dgvTypesRoom.SelectionChanged += new System.EventHandler(this.dgvTypesRoom_SelectionChanged);
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(529, 120);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(184, 26);
            this.txtSource.TabIndex = 24;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // txtIDRoomType
            // 
            this.txtIDRoomType.Enabled = false;
            this.txtIDRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDRoomType.Location = new System.Drawing.Point(529, 150);
            this.txtIDRoomType.Name = "txtIDRoomType";
            this.txtIDRoomType.Size = new System.Drawing.Size(38, 26);
            this.txtIDRoomType.TabIndex = 25;
            this.txtIDRoomType.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(573, 150);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(38, 26);
            this.txtDescription.TabIndex = 26;
            this.txtDescription.Visible = false;
            // 
            // FormInsertRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1040, 532);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtIDRoomType);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.dgvTypesRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInsertRoom";
            this.Text = "2";
            this.Load += new System.EventHandler(this.FormInsertRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypesRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTypesRoom;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtIDRoomType;
        private System.Windows.Forms.TextBox txtDescription;
    }
}