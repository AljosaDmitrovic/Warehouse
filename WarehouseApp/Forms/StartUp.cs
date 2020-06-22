using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
            panelLeft.Height = 0;
        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {
            if (imageNumber == 6)
            {
                imageNumber = 1;
            }
            slider.ImageLocation = string.Format(@"..\..\Resources\Images\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }
        public void AddToPanel(Form frm)
        {
            panel.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.AutoScroll = true;
            panel.Controls.Add(frm);
            frm.Show();
        }
        //TODO create logic for every button
        private void orders_btn_Click(object sender, EventArgs e)
        {
            Orders ordersForm = new Orders(false);
            AddToPanel(ordersForm);
            panelLeft.Height = orders_btn.Height;
            panelLeft.Top = orders_btn.Top;
        }

        private void warehouse_btn_Click(object sender, EventArgs e)
        {
            Warehouses warehousesForm = new Warehouses();
            AddToPanel(warehousesForm);
            panelLeft.Height = warehouse_btn.Height;
            panelLeft.Top = warehouse_btn.Top;
        }

        private void products_btn_Click(object sender, EventArgs e)
        {
            Products productsForm = new Products();
            AddToPanel(productsForm);
            panelLeft.Height = products_btn.Height;
            panelLeft.Top = products_btn.Top;
        }



        private void locations_btn_Click(object sender, EventArgs e)
        {
            Locations locationForm = new Locations();
            AddToPanel(locationForm);
            panelLeft.Height = locations_btn.Height;
            panelLeft.Top = locations_btn.Top;
        }

        private void categories_btn_Click(object sender, EventArgs e)
        {
            Categories categoryForm = new Categories();
            AddToPanel(categoryForm);
            panelLeft.Height = categories_btn.Height;
            panelLeft.Top = categories_btn.Top;
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            Customers customerForm = new Customers();
            AddToPanel(customerForm);
            panelLeft.Height = customers_btn.Height;
            panelLeft.Top = customers_btn.Top;
        }

        private void suppliers_btn_Click(object sender, EventArgs e)
        {
            Suppliers supplierForm = new Suppliers();
            AddToPanel(supplierForm);
            panelLeft.Height = suppliers_btn.Height;
            panelLeft.Top = suppliers_btn.Top;
        }

        private void finishedOrders_btn_Click_1(object sender, EventArgs e)
        {
            Orders ordersForm = new Orders(true);
            AddToPanel(ordersForm);
            panelLeft.Height = finishedOrders_btn.Height;
            panelLeft.Top = finishedOrders_btn.Top;
        }


    }
}
