using DataLayer.Models;
using BusinessLayer;
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
    public partial class WarehouseCard : Form
    {
        private LocationRepositoryBus locationRepositoryBus = new LocationRepositoryBus();
        private WarehouseRepositoryBus warehouseRepositoryBus = new WarehouseRepositoryBus();
        private OrderRepositoryBus orderRepositoryBus = new OrderRepositoryBus();
        private ProductRepositoryBus productRepositoryBus = new ProductRepositoryBus();
        public WarehouseCard(Warehouse warehouse)
        {
            InitializeComponent();
            FillLocationsComboBox();
            FillAvailabeQunatityTable(warehouse);
        }

        private void FillLocationsComboBox()
        {
            
            List<Location> locationList = new List<Location>();
            locationList = locationRepositoryBus.GetAllLocations();
            foreach (var location in locationList)
            {
                comboBoxLocation.Items.Add(location.Name);
            }
                
        }
        private void FillAvailabeQunatityTable(Warehouse warehouse)
        {
            qunatityTable.Rows.Clear();
            int sum = 0;
            List<OrderLine> orderLineList = new List<OrderLine>();
            Order order = new Order();
            List<Product> products = new List<Product>();
            products = productRepositoryBus.GetAllProducts();
            foreach (var product in products)
            {

                orderLineList = orderRepositoryBus.GetAllOrderLinesProductById(product.Id);
                foreach (var orderLine in orderLineList)
                {
                    order = orderRepositoryBus.GetOrderById(orderLine.OrderId);
                    if(order.Status != 0 || order.WarehouseId != warehouse.Id)
                    {
                        continue;
                    }
                    sum += orderLine.Quantity;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(qunatityTable);
                row.Cells[0].Value = product.Name;
                row.Cells[1].Value = sum;
                qunatityTable.Rows.Add(row);
                sum = 0;
            }
        }
        public void SetParameters(Boolean New,Warehouse warehouse)
        {
            switch (New)
            {
                case true:
                    labelInsert.Visible = true;
                    buttonInsert.Visible = true;
                    break;
                case false:
                    labelUpdate.Visible = true;
                    buttonUpdate.Visible = true;
                    Location location = new Location();
                    location = locationRepositoryBus.GetLocationById(warehouse.LocationId);
                    textBoxId.Text = Convert.ToString(warehouse.Id);
                    textBoxName.Text = warehouse.Name;
                    comboBoxLocation.SelectedItem = location.Name;
                    break;
                default:
                    break;
            }
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    Warehouse warehouse = new Warehouse();
                    warehouse.Name = textBoxName.Text;
                    warehouse.LocationId = locationRepositoryBus.GetLocationIdByName(comboBoxLocation.SelectedItem.ToString());
                    warehouseRepositoryBus.InsertWarehouse(warehouse);
                    AutoClosingMessageBox.Show("You have successfully added your Warehouse!", "Congratulations!", 1700);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               

            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Warehouse warehouse = new Warehouse();
                    warehouse.Id = Convert.ToInt32(textBoxId.Text);
                    warehouse.Name = textBoxName.Text;
                    warehouse.LocationId = locationRepositoryBus.GetLocationIdByName(comboBoxLocation.SelectedItem.ToString());
                    warehouseRepositoryBus.UpdateWarehouse(warehouse);

                    AutoClosingMessageBox.Show("You have successfully updated your Warehouse!", "Congratulations!", 1700);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        /* KLASA AUTO-CLOSING MSGBOX */
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void labelOrderLines_Click(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }



        /*---IS ALL LETTERS---*/
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        /*---IS ALL DIGITS---*/
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /*---IS ALL LETTERS OR DIGITS---*/

        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        /*---ONLY LETTERS, DIGITS, UNDERSCORES---*/
        public static bool IsAllLettersOrDigitsOrUnderscores(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c) && c != '_')
                    return false;
            }
            return true;
        }

        private void WarehouseCard_Activated(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }
    }
}
