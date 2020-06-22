namespace WarehouseApp.Forms
{
    partial class StartUp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUp));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel = new System.Windows.Forms.Panel();
            this.slider = new System.Windows.Forms.PictureBox();
            this.suppliers_btn = new System.Windows.Forms.Button();
            this.customers_btn = new System.Windows.Forms.Button();
            this.categories_btn = new System.Windows.Forms.Button();
            this.locations_btn = new System.Windows.Forms.Button();
            this.products_btn = new System.Windows.Forms.Button();
            this.warehouse_btn = new System.Windows.Forms.Button();
            this.finishedOrders_btn = new System.Windows.Forms.Button();
            this.orders_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.slider);
            this.panel.Location = new System.Drawing.Point(174, 10);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(688, 359);
            this.panel.TabIndex = 1;
            // 
            // slider
            // 
            this.slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slider.Image = global::WarehouseApp.Properties.Resources.AdobeStock_249275256_1000x500;
            this.slider.Location = new System.Drawing.Point(0, 0);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(688, 359);
            this.slider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.slider.TabIndex = 0;
            this.slider.TabStop = false;
            // 
            // suppliers_btn
            // 
            this.suppliers_btn.BackColor = System.Drawing.Color.Transparent;
            this.suppliers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.suppliers_btn.FlatAppearance.BorderSize = 0;
            this.suppliers_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.suppliers_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.suppliers_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.suppliers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suppliers_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.suppliers_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.suppliers_btn.Location = new System.Drawing.Point(9, 283);
            this.suppliers_btn.Margin = new System.Windows.Forms.Padding(2);
            this.suppliers_btn.Name = "suppliers_btn";
            this.suppliers_btn.Size = new System.Drawing.Size(161, 41);
            this.suppliers_btn.TabIndex = 38;
            this.suppliers_btn.Text = "Suppliers";
            this.suppliers_btn.UseVisualStyleBackColor = false;
            this.suppliers_btn.Click += new System.EventHandler(this.suppliers_btn_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.BackColor = System.Drawing.Color.Transparent;
            this.customers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customers_btn.FlatAppearance.BorderSize = 0;
            this.customers_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.customers_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.customers_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customers_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customers_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.customers_btn.Location = new System.Drawing.Point(9, 237);
            this.customers_btn.Margin = new System.Windows.Forms.Padding(2);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(161, 41);
            this.customers_btn.TabIndex = 37;
            this.customers_btn.Text = "Customers";
            this.customers_btn.UseVisualStyleBackColor = false;
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // categories_btn
            // 
            this.categories_btn.BackColor = System.Drawing.Color.Transparent;
            this.categories_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categories_btn.FlatAppearance.BorderSize = 0;
            this.categories_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.categories_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.categories_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.categories_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categories_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.categories_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.categories_btn.Location = new System.Drawing.Point(9, 192);
            this.categories_btn.Margin = new System.Windows.Forms.Padding(2);
            this.categories_btn.Name = "categories_btn";
            this.categories_btn.Size = new System.Drawing.Size(161, 41);
            this.categories_btn.TabIndex = 36;
            this.categories_btn.Text = "Categories";
            this.categories_btn.UseVisualStyleBackColor = false;
            this.categories_btn.Click += new System.EventHandler(this.categories_btn_Click);
            // 
            // locations_btn
            // 
            this.locations_btn.BackColor = System.Drawing.Color.Transparent;
            this.locations_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.locations_btn.FlatAppearance.BorderSize = 0;
            this.locations_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.locations_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.locations_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.locations_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locations_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.locations_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.locations_btn.Location = new System.Drawing.Point(9, 146);
            this.locations_btn.Margin = new System.Windows.Forms.Padding(2);
            this.locations_btn.Name = "locations_btn";
            this.locations_btn.Size = new System.Drawing.Size(161, 41);
            this.locations_btn.TabIndex = 35;
            this.locations_btn.Text = "Locations";
            this.locations_btn.UseVisualStyleBackColor = false;
            this.locations_btn.Click += new System.EventHandler(this.locations_btn_Click);
            // 
            // products_btn
            // 
            this.products_btn.BackColor = System.Drawing.Color.Transparent;
            this.products_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.products_btn.FlatAppearance.BorderSize = 0;
            this.products_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.products_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.products_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.products_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.products_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.products_btn.Location = new System.Drawing.Point(9, 101);
            this.products_btn.Margin = new System.Windows.Forms.Padding(2);
            this.products_btn.Name = "products_btn";
            this.products_btn.Size = new System.Drawing.Size(161, 41);
            this.products_btn.TabIndex = 34;
            this.products_btn.Text = "Products";
            this.products_btn.UseVisualStyleBackColor = false;
            this.products_btn.Click += new System.EventHandler(this.products_btn_Click);
            // 
            // warehouse_btn
            // 
            this.warehouse_btn.BackColor = System.Drawing.Color.Transparent;
            this.warehouse_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.warehouse_btn.FlatAppearance.BorderSize = 0;
            this.warehouse_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.warehouse_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.warehouse_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.warehouse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouse_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warehouse_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.warehouse_btn.Location = new System.Drawing.Point(9, 55);
            this.warehouse_btn.Margin = new System.Windows.Forms.Padding(2);
            this.warehouse_btn.Name = "warehouse_btn";
            this.warehouse_btn.Size = new System.Drawing.Size(161, 41);
            this.warehouse_btn.TabIndex = 33;
            this.warehouse_btn.Text = "Warehouses";
            this.warehouse_btn.UseVisualStyleBackColor = false;
            this.warehouse_btn.Click += new System.EventHandler(this.warehouse_btn_Click);
            // 
            // finishedOrders_btn
            // 
            this.finishedOrders_btn.BackColor = System.Drawing.Color.Transparent;
            this.finishedOrders_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishedOrders_btn.FlatAppearance.BorderSize = 0;
            this.finishedOrders_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.finishedOrders_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.finishedOrders_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.finishedOrders_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishedOrders_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.finishedOrders_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.finishedOrders_btn.Location = new System.Drawing.Point(9, 328);
            this.finishedOrders_btn.Margin = new System.Windows.Forms.Padding(2);
            this.finishedOrders_btn.Name = "finishedOrders_btn";
            this.finishedOrders_btn.Size = new System.Drawing.Size(161, 41);
            this.finishedOrders_btn.TabIndex = 32;
            this.finishedOrders_btn.Text = "Finished Orders";
            this.finishedOrders_btn.UseVisualStyleBackColor = false;
            this.finishedOrders_btn.Click += new System.EventHandler(this.finishedOrders_btn_Click_1);
            // 
            // orders_btn
            // 
            this.orders_btn.BackColor = System.Drawing.Color.Transparent;
            this.orders_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orders_btn.FlatAppearance.BorderSize = 0;
            this.orders_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.orders_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.orders_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.orders_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orders_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.orders_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.orders_btn.Location = new System.Drawing.Point(9, 10);
            this.orders_btn.Margin = new System.Windows.Forms.Padding(2);
            this.orders_btn.Name = "orders_btn";
            this.orders_btn.Size = new System.Drawing.Size(161, 41);
            this.orders_btn.TabIndex = 31;
            this.orders_btn.Text = "Orders";
            this.orders_btn.UseVisualStyleBackColor = false;
            this.orders_btn.Click += new System.EventHandler(this.orders_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(171, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 396);
            this.panel1.TabIndex = 39;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panelLeft.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.panelLeft.Location = new System.Drawing.Point(9, 10);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 41);
            this.panelLeft.TabIndex = 40;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(860, 379);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.finishedOrders_btn);
            this.Controls.Add(this.suppliers_btn);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.customers_btn);
            this.Controls.Add(this.orders_btn);
            this.Controls.Add(this.categories_btn);
            this.Controls.Add(this.locations_btn);
            this.Controls.Add(this.warehouse_btn);
            this.Controls.Add(this.products_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartUp";
            this.Text = "Warehouse App";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button suppliers_btn;
        private System.Windows.Forms.Button customers_btn;
        private System.Windows.Forms.Button categories_btn;
        private System.Windows.Forms.Button locations_btn;
        private System.Windows.Forms.Button products_btn;
        public System.Windows.Forms.Button warehouse_btn;
        private System.Windows.Forms.Button finishedOrders_btn;
        private System.Windows.Forms.Button orders_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox slider;
        private System.Windows.Forms.Timer timer1;
    }
}