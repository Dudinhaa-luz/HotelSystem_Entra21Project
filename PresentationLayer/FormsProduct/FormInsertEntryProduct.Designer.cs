namespace PresentationLayer
{
    partial class FormInsertEntryProduct
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
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvProductsEntry = new System.Windows.Forms.DataGridView();
            this.btnFinish = new System.Windows.Forms.Button();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNameEmployee = new System.Windows.Forms.TextBox();
            this.txtIDEmployee = new System.Windows.Forms.TextBox();
            this.txtNameSupplier = new System.Windows.Forms.TextBox();
            this.txtIDSupplier = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(76, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 36);
            this.label1.TabIndex = 18;
            this.label1.Text = "Entrada de Produto";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Black;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInsert.Location = new System.Drawing.Point(735, 226);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(296, 45);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "INSERIR";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Data de entrada";
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEntryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryDate.Location = new System.Drawing.Point(163, 98);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(110, 26);
            this.dtpEntryDate.TabIndex = 37;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(15, 290);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(500, 389);
            this.dgvProducts.TabIndex = 38;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(730, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 36);
            this.label4.TabIndex = 39;
            this.label4.Text = "Detalhes da Entrada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(824, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 21);
            this.label5.TabIndex = 42;
            this.label5.Text = "R$";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(881, 135);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(91, 26);
            this.txtPrice.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(768, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 40;
            this.label6.Text = "Preço";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(881, 173);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(91, 26);
            this.txtQuantity.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(768, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 21);
            this.label8.TabIndex = 43;
            this.label8.Text = "Quantidade";
            // 
            // dgvProductsEntry
            // 
            this.dgvProductsEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsEntry.Location = new System.Drawing.Point(613, 290);
            this.dgvProductsEntry.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductsEntry.Name = "dgvProductsEntry";
            this.dgvProductsEntry.RowHeadersWidth = 51;
            this.dgvProductsEntry.RowTemplate.Height = 24;
            this.dgvProductsEntry.Size = new System.Drawing.Size(500, 389);
            this.dgvProductsEntry.TabIndex = 45;
            this.dgvProductsEntry.SelectionChanged += new System.EventHandler(this.dgvProductsEntry_SelectionChanged);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.Black;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFinish.Location = new System.Drawing.Point(866, 687);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(296, 45);
            this.btnFinish.TabIndex = 47;
            this.btnFinish.Text = "FINALIZAR";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Nome",
            "ID"});
            this.cmbSearch.Location = new System.Drawing.Point(329, 235);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(186, 28);
            this.cmbSearch.TabIndex = 50;
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(158, 237);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(166, 26);
            this.txtSource.TabIndex = 48;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 49;
            this.label3.Text = "Pesquisar Produto";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(881, 95);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(155, 26);
            this.txtDescription.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(768, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 21);
            this.label7.TabIndex = 51;
            this.label7.Text = "Descrição";
            // 
            // txtNameEmployee
            // 
            this.txtNameEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameEmployee.Location = new System.Drawing.Point(216, 176);
            this.txtNameEmployee.Name = "txtNameEmployee";
            this.txtNameEmployee.Size = new System.Drawing.Size(284, 26);
            this.txtNameEmployee.TabIndex = 53;
            // 
            // txtIDEmployee
            // 
            this.txtIDEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDEmployee.Location = new System.Drawing.Point(149, 176);
            this.txtIDEmployee.Name = "txtIDEmployee";
            this.txtIDEmployee.Size = new System.Drawing.Size(61, 26);
            this.txtIDEmployee.TabIndex = 54;
            // 
            // txtNameSupplier
            // 
            this.txtNameSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSupplier.Location = new System.Drawing.Point(216, 135);
            this.txtNameSupplier.Name = "txtNameSupplier";
            this.txtNameSupplier.Size = new System.Drawing.Size(285, 26);
            this.txtNameSupplier.TabIndex = 55;
            // 
            // txtIDSupplier
            // 
            this.txtIDSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDSupplier.Location = new System.Drawing.Point(149, 135);
            this.txtIDSupplier.Name = "txtIDSupplier";
            this.txtIDSupplier.Size = new System.Drawing.Size(61, 26);
            this.txtIDSupplier.TabIndex = 56;
            this.txtIDSupplier.TextChanged += new System.EventHandler(this.txtIDSupplier_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 21);
            this.label9.TabIndex = 57;
            this.label9.Text = "Funcionário";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 21);
            this.label10.TabIndex = 58;
            this.label10.Text = "Fornecedor";
            // 
            // FormInsertEntryProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIDSupplier);
            this.Controls.Add(this.txtNameSupplier);
            this.Controls.Add(this.txtIDEmployee);
            this.Controls.Add(this.txtNameEmployee);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.dgvProductsEntry);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.dtpEntryDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInsertEntryProduct";
            this.Text = "2";
            this.Load += new System.EventHandler(this.FormInsertEntryProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvProductsEntry;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNameEmployee;
        private System.Windows.Forms.TextBox txtIDEmployee;
        private System.Windows.Forms.TextBox txtNameSupplier;
        private System.Windows.Forms.TextBox txtIDSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}