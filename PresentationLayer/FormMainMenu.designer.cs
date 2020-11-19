using System.Net.Http.Headers;

namespace PresentationLayer
{
    partial class FormMainMenu
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
            this.pnlHigher = new System.Windows.Forms.Panel();
            this.btnRestore = new System.Windows.Forms.PictureBox();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnFilters = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnShoppings = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnSales = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnStorage = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnProducts = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnClient = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlShortcutMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHigher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlShortcutMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHigher
            // 
            this.pnlHigher.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlHigher.Controls.Add(this.btnRestore);
            this.pnlHigher.Controls.Add(this.btnMaximize);
            this.pnlHigher.Controls.Add(this.btnMinimize);
            this.pnlHigher.Controls.Add(this.btnClose);
            this.pnlHigher.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHigher.ForeColor = System.Drawing.Color.White;
            this.pnlHigher.Location = new System.Drawing.Point(0, 0);
            this.pnlHigher.Name = "pnlHigher";
            this.pnlHigher.Size = new System.Drawing.Size(1040, 38);
            this.pnlHigher.TabIndex = 0;
            this.pnlHigher.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHigher_MouseDown);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Image = global::PresentationLayer.Properties.Resources.res;
            this.btnRestore.Location = new System.Drawing.Point(972, 7);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(25, 25);
            this.btnRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestore.TabIndex = 3;
            this.btnRestore.TabStop = false;
            this.btnRestore.Visible = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = global::PresentationLayer.Properties.Resources.maxi;
            this.btnMaximize.Location = new System.Drawing.Point(972, 7);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(25, 25);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::PresentationLayer.Properties.Resources.minimazar;
            this.btnMinimize.Location = new System.Drawing.Point(941, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(25, 25);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.cerrar;
            this.btnClose.Location = new System.Drawing.Point(1003, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(220, 38);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(820, 602);
            this.pnlMiddle.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 750);
            this.panel4.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.btnFilter);
            this.panel7.Controls.Add(this.btnFilters);
            this.panel7.Controls.Add(this.panel17);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Controls.Add(this.panel16);
            this.panel7.Controls.Add(this.btnEmployees);
            this.panel7.Controls.Add(this.btnReservations);
            this.panel7.Controls.Add(this.panel15);
            this.panel7.Controls.Add(this.btnCheckout);
            this.panel7.Controls.Add(this.panel14);
            this.panel7.Controls.Add(this.btnCheckin);
            this.panel7.Controls.Add(this.panel13);
            this.panel7.Controls.Add(this.btnShoppings);
            this.panel7.Controls.Add(this.panel12);
            this.panel7.Controls.Add(this.btnSales);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.btnStorage);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.btnSuppliers);
            this.panel7.Controls.Add(this.btnRooms);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.btnProducts);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.btnClient);
            this.panel7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(220, 812);
            this.panel7.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PresentationLayer.Properties.Resources.LogoBranco;
            this.pictureBox3.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(220, 124);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(0, 563);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 45);
            this.panel2.TabIndex = 20;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Black;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Image = global::PresentationLayer.Properties.Resources.simbolo_de_ferramenta_preenchido_com_filtro;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(6, 563);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(208, 45);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "  Filtros";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnFilters
            // 
            this.btnFilters.BackColor = System.Drawing.Color.Black;
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilters.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.ForeColor = System.Drawing.Color.White;
            this.btnFilters.Image = global::PresentationLayer.Properties.Resources.simbolo_de_ferramenta_preenchido_com_filtro;
            this.btnFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilters.Location = new System.Drawing.Point(3, 570);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(214, 31);
            this.btnFilters.TabIndex = 19;
            this.btnFilters.Text = "Filtros";
            this.btnFilters.UseVisualStyleBackColor = false;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel17.Location = new System.Drawing.Point(0, 614);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(8, 45);
            this.panel17.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 38);
            this.panel1.TabIndex = 18;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel16.Location = new System.Drawing.Point(0, 519);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(5, 38);
            this.panel16.TabIndex = 18;
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.Black;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = global::PresentationLayer.Properties.Resources.Funcionário;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(6, 614);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(214, 45);
            this.btnEmployees.TabIndex = 17;
            this.btnEmployees.Text = "    Funcionários";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnReservations
            // 
            this.btnReservations.BackColor = System.Drawing.Color.Black;
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnReservations.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservations.ForeColor = System.Drawing.Color.White;
            this.btnReservations.Image = global::PresentationLayer.Properties.Resources.Reservas1;
            this.btnReservations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.Location = new System.Drawing.Point(6, 519);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(214, 38);
            this.btnReservations.TabIndex = 17;
            this.btnReservations.Text = "   Reservas";
            this.btnReservations.UseVisualStyleBackColor = false;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel15.Location = new System.Drawing.Point(0, 475);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(8, 38);
            this.panel15.TabIndex = 16;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.Black;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Image = global::PresentationLayer.Properties.Resources.Checkout;
            this.btnCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckout.Location = new System.Drawing.Point(6, 475);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(214, 38);
            this.btnCheckout.TabIndex = 15;
            this.btnCheckout.Text = "     Check-Out";
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel14.Location = new System.Drawing.Point(0, 431);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(8, 38);
            this.panel14.TabIndex = 14;
            // 
            // btnCheckin
            // 
            this.btnCheckin.BackColor = System.Drawing.Color.Black;
            this.btnCheckin.FlatAppearance.BorderSize = 0;
            this.btnCheckin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCheckin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckin.ForeColor = System.Drawing.Color.White;
            this.btnCheckin.Image = global::PresentationLayer.Properties.Resources.CheckinCerto;
            this.btnCheckin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckin.Location = new System.Drawing.Point(6, 431);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(214, 38);
            this.btnCheckin.TabIndex = 13;
            this.btnCheckin.Text = "   Check-In";
            this.btnCheckin.UseVisualStyleBackColor = false;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel13.Location = new System.Drawing.Point(0, 387);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(8, 38);
            this.panel13.TabIndex = 12;
            // 
            // btnShoppings
            // 
            this.btnShoppings.BackColor = System.Drawing.Color.Black;
            this.btnShoppings.FlatAppearance.BorderSize = 0;
            this.btnShoppings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnShoppings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnShoppings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShoppings.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoppings.ForeColor = System.Drawing.Color.White;
            this.btnShoppings.Image = global::PresentationLayer.Properties.Resources.carrinho_de_compras;
            this.btnShoppings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShoppings.Location = new System.Drawing.Point(6, 387);
            this.btnShoppings.Name = "btnShoppings";
            this.btnShoppings.Size = new System.Drawing.Size(214, 38);
            this.btnShoppings.TabIndex = 11;
            this.btnShoppings.Text = "  Compras";
            this.btnShoppings.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel12.Location = new System.Drawing.Point(0, 343);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(8, 38);
            this.panel12.TabIndex = 10;
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.Black;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSales.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.White;
            this.btnSales.Image = global::PresentationLayer.Properties.Resources.Vendas1;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(6, 343);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(214, 38);
            this.btnSales.TabIndex = 9;
            this.btnSales.Text = "Vendas";
            this.btnSales.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel11.Location = new System.Drawing.Point(0, 299);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(8, 38);
            this.panel11.TabIndex = 8;
            // 
            // btnStorage
            // 
            this.btnStorage.BackColor = System.Drawing.Color.Black;
            this.btnStorage.FlatAppearance.BorderSize = 0;
            this.btnStorage.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStorage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorage.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorage.ForeColor = System.Drawing.Color.White;
            this.btnStorage.Image = global::PresentationLayer.Properties.Resources.Estoque1;
            this.btnStorage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStorage.Location = new System.Drawing.Point(6, 299);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Size = new System.Drawing.Size(214, 38);
            this.btnStorage.TabIndex = 7;
            this.btnStorage.Text = " Estoque";
            this.btnStorage.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel10.Location = new System.Drawing.Point(0, 255);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(8, 38);
            this.panel10.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel9.Location = new System.Drawing.Point(0, 211);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(8, 38);
            this.panel9.TabIndex = 6;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.Color.Black;
            this.btnSuppliers.FlatAppearance.BorderSize = 0;
            this.btnSuppliers.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSuppliers.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.Image = global::PresentationLayer.Properties.Resources.fornecedor3;
            this.btnSuppliers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuppliers.Location = new System.Drawing.Point(6, 255);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(214, 38);
            this.btnSuppliers.TabIndex = 5;
            this.btnSuppliers.Text = "    Fornecedores";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.Color.Black;
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRooms.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRooms.ForeColor = System.Drawing.Color.White;
            this.btnRooms.Image = global::PresentationLayer.Properties.Resources.quartos;
            this.btnRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.Location = new System.Drawing.Point(6, 211);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(214, 38);
            this.btnRooms.TabIndex = 5;
            this.btnRooms.Text = " Quartos";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel6.Location = new System.Drawing.Point(0, 168);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 38);
            this.panel6.TabIndex = 4;
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.Black;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProducts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Image = global::PresentationLayer.Properties.Resources.Produtos;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(6, 168);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(214, 38);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "  Produtos";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel8.Location = new System.Drawing.Point(0, 124);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(8, 38);
            this.panel8.TabIndex = 2;
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.Black;
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.White;
            this.btnClient.Image = global::PresentationLayer.Properties.Resources.cliente1;
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(6, 124);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(214, 38);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "Clientes";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::PresentationLayer.Properties.Resources.clientes;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(6, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clientes";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel5.Location = new System.Drawing.Point(3, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 32);
            this.panel5.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::PresentationLayer.Properties.Resources.clientes;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(6, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 32);
            this.button3.TabIndex = 1;
            this.button3.Text = "Clientes";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.LogoMakerCa_1603575397702;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(217, 173);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnlShortcutMenu
            // 
            this.pnlShortcutMenu.BackColor = System.Drawing.Color.Black;
            this.pnlShortcutMenu.Controls.Add(this.panel4);
            this.pnlShortcutMenu.Controls.Add(this.button1);
            this.pnlShortcutMenu.Controls.Add(this.btnClients);
            this.pnlShortcutMenu.Controls.Add(this.pictureBox1);
            this.pnlShortcutMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShortcutMenu.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlShortcutMenu.Location = new System.Drawing.Point(0, 38);
            this.pnlShortcutMenu.Name = "pnlShortcutMenu";
            this.pnlShortcutMenu.Size = new System.Drawing.Size(220, 602);
            this.pnlShortcutMenu.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::PresentationLayer.Properties.Resources.clientes;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(6, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clientes";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = global::PresentationLayer.Properties.Resources.clientes;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(6, 188);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(214, 32);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.LogoMakerCa_1603575397702;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlShortcutMenu);
            this.Controls.Add(this.pnlHigher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMainMenu";
            this.Text = "Form1";
            this.pnlHigher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlShortcutMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHigher;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnMaximize;
        private System.Windows.Forms.PictureBox btnRestore;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnShoppings;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnStorage;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlShortcutMenu;
    }
}

