namespace WarehouseApp.Forms
{
    partial class OrderCard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.comboBoxWarehause = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.labelOrderName = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.orderLinesTable = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.wareHouse_AppDataSet = new WarehouseApp.WareHouse_AppDataSet();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qunatity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelOrderLines = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new WarehouseApp.WareHouse_AppDataSetTableAdapters.ProductTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderLinesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouse_AppDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.buttonPost);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 37);
            this.panel1.TabIndex = 3;
            // 
            // buttonPost
            // 
            this.buttonPost.BackColor = System.Drawing.Color.DarkTurquoise;
            this.buttonPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPost.FlatAppearance.BorderSize = 0;
            this.buttonPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPost.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPost.ForeColor = System.Drawing.Color.White;
            this.buttonPost.Location = new System.Drawing.Point(99, 5);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(80, 30);
            this.buttonPost.TabIndex = 7;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = false;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.DarkTurquoise;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(3, 5);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxOrderId);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Controls.Add(this.dateTimePicker);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelCustomer);
            this.panel2.Controls.Add(this.comboBoxWarehause);
            this.panel2.Controls.Add(this.comboBoxCustomer);
            this.panel2.Controls.Add(this.labelOrderName);
            this.panel2.Controls.Add(this.textBoxStatus);
            this.panel2.Controls.Add(this.textBoxTotalAmount);
            this.panel2.Controls.Add(this.labelStatus);
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelDescription);
            this.panel2.Location = new System.Drawing.Point(9, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 158);
            this.panel2.TabIndex = 4;
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Location = new System.Drawing.Point(572, 2);
            this.textBoxOrderId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(8, 20);
            this.textBoxOrderId.TabIndex = 14;
            this.textBoxOrderId.Visible = false;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(20, 129);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(35, 17);
            this.labelDate.TabIndex = 13;
            this.labelDate.Text = "Date";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(111, 126);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(257, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Warehause";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCustomer.ForeColor = System.Drawing.Color.White;
            this.labelCustomer.Location = new System.Drawing.Point(257, 59);
            this.labelCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(64, 17);
            this.labelCustomer.TabIndex = 10;
            this.labelCustomer.Text = "Customer";
            // 
            // comboBoxWarehause
            // 
            this.comboBoxWarehause.FormattingEnabled = true;
            this.comboBoxWarehause.Location = new System.Drawing.Point(352, 93);
            this.comboBoxWarehause.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxWarehause.Name = "comboBoxWarehause";
            this.comboBoxWarehause.Size = new System.Drawing.Size(110, 21);
            this.comboBoxWarehause.TabIndex = 9;
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(352, 59);
            this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(110, 21);
            this.comboBoxCustomer.TabIndex = 8;
            // 
            // labelOrderName
            // 
            this.labelOrderName.AutoSize = true;
            this.labelOrderName.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOrderName.ForeColor = System.Drawing.Color.White;
            this.labelOrderName.Location = new System.Drawing.Point(18, 16);
            this.labelOrderName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrderName.Name = "labelOrderName";
            this.labelOrderName.Size = new System.Drawing.Size(68, 25);
            this.labelOrderName.TabIndex = 7;
            this.labelOrderName.Text = "Order ";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Location = new System.Drawing.Point(111, 93);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(110, 20);
            this.textBoxStatus.TabIndex = 4;
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Enabled = false;
            this.textBoxTotalAmount.Location = new System.Drawing.Point(500, 126);
            this.textBoxTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(57, 20);
            this.textBoxTotalAmount.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(20, 93);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 17);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(111, 59);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(110, 20);
            this.textBoxDescription.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(484, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Amount";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDescription.ForeColor = System.Drawing.Color.White;
            this.labelDescription.Location = new System.Drawing.Point(20, 59);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(74, 17);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.orderLinesTable);
            this.panel3.Controls.Add(this.labelOrderLines);
            this.panel3.Location = new System.Drawing.Point(9, 211);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 146);
            this.panel3.TabIndex = 5;
            // 
            // orderLinesTable
            // 
            this.orderLinesTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.orderLinesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.orderLinesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderLinesTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.orderLinesTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.orderLinesTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderLinesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.orderLinesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.orderLinesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.ProductId,
            this.UnitPrice,
            this.Qunatity,
            this.Discount});
            this.orderLinesTable.EnableHeadersVisualStyles = false;
            this.orderLinesTable.Location = new System.Drawing.Point(2, 30);
            this.orderLinesTable.Margin = new System.Windows.Forms.Padding(2);
            this.orderLinesTable.MultiSelect = false;
            this.orderLinesTable.Name = "orderLinesTable";
            this.orderLinesTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.orderLinesTable.RowHeadersVisible = false;
            this.orderLinesTable.RowHeadersWidth = 10;
            this.orderLinesTable.RowTemplate.Height = 24;
            this.orderLinesTable.ShowEditingIcon = false;
            this.orderLinesTable.Size = new System.Drawing.Size(578, 114);
            this.orderLinesTable.TabIndex = 9;
            this.orderLinesTable.SelectionChanged += new System.EventHandler(this.orderLinesTable_SelectionChanged);
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.MinimumWidth = 6;
            this.OrderId.Name = "OrderId";
            this.OrderId.Visible = false;
            // 
            // ProductId
            // 
            this.ProductId.DataSource = this.productBindingSource1;
            this.ProductId.DisplayMember = "Name";
            this.ProductId.HeaderText = "Product";
            this.ProductId.MinimumWidth = 6;
            this.ProductId.Name = "ProductId";
            this.ProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductId.ValueMember = "Name";
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "Product";
            this.productBindingSource1.DataSource = this.wareHouse_AppDataSet;
            // 
            // wareHouse_AppDataSet
            // 
            this.wareHouse_AppDataSet.DataSetName = "WareHouse_AppDataSet";
            this.wareHouse_AppDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Qunatity
            // 
            this.Qunatity.HeaderText = "Qunatity";
            this.Qunatity.MinimumWidth = 6;
            this.Qunatity.Name = "Qunatity";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount %";
            this.Discount.MinimumWidth = 6;
            this.Discount.Name = "Discount";
            // 
            // labelOrderLines
            // 
            this.labelOrderLines.AutoSize = true;
            this.labelOrderLines.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOrderLines.ForeColor = System.Drawing.Color.White;
            this.labelOrderLines.Location = new System.Drawing.Point(9, 8);
            this.labelOrderLines.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrderLines.Name = "labelOrderLines";
            this.labelOrderLines.Size = new System.Drawing.Size(90, 20);
            this.labelOrderLines.TabIndex = 8;
            this.labelOrderLines.Text = "Order Lines";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.wareHouse_AppDataSet;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // OrderCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrderCard";
            this.Text = "Order";
            this.Activated += new System.EventHandler(this.OrderCard_Activated);
            this.Load += new System.EventHandler(this.OrderCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderLinesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wareHouse_AppDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.ComboBox comboBoxWarehause;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelOrderLines;
        private System.Windows.Forms.DataGridView orderLinesTable;
        private WareHouse_AppDataSet wareHouse_AppDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private WareHouse_AppDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.Label labelOrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qunatity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.TextBox textBoxOrderId;
    }
}