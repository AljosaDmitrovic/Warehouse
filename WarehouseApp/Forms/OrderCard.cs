using BusinessLayer;
using DataLayer.Models;
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
    public partial class OrderCard : Form
    {
        private OrderRepositoryBus orderRepositoryBus = new OrderRepositoryBus();
        private ProductRepositoryBus productRepositoryBus = new ProductRepositoryBus();
        private CustomerRepositoryBus customerRepositoryBus = new CustomerRepositoryBus();
        private WarehouseRepositoryBus warehouseRepositoryBus = new WarehouseRepositoryBus();
        public OrderCard(Order order,bool finished)
        {
            InitializeComponent();
            FillCustomerComboBox();
            FillWarehouseComboBox();
            InsertDataIntoTable(order);
            if(finished)
            {
                this.Enabled = false;
                labelDescription.BackColor = Color.Gray;
                labelStatus.BackColor = Color.Gray;
                labelDate.BackColor = Color.Gray;
                labelCustomer.BackColor = Color.Gray;
                label3.BackColor = Color.Gray;
                label5.BackColor = Color.Gray;
                labelOrderName.BackColor = Color.Gray;
                labelOrderLines.BackColor = Color.Gray;
            }
        }
        private void FillCustomerComboBox()
        {
            List<Customer> customerList = new List<Customer>();
            customerList = customerRepositoryBus.GetAllCustomers();
            foreach (var customer in customerList)
            {
                comboBoxCustomer.Items.Add(customer.Name);
            }
        }
        private void FillWarehouseComboBox()
        {
            List<Warehouse> warehouseList = new List<Warehouse>();
            warehouseList =  warehouseRepositoryBus.GetAllWarehouses();
            foreach (var warehouse in warehouseList)
            {
                comboBoxWarehause.Items.Add(warehouse.Name);
            }
        }
        public void SetParameters(bool New,Order order)
        {
            if(New)
            {
                textBoxStatus.Text = "Open";
            }
            else
            {
                string orderStatus;
                Customer customer = new Customer();
                Warehouse warehouse = new Warehouse();
                customer = customerRepositoryBus.GetCustomerById(order.CustomerId);
                warehouse = warehouseRepositoryBus.GetWarehouseById(order.WarehouseId);
                labelOrderName.Text += " "+ order.Id;
                textBoxOrderId.Text = order.Id.ToString();
                textBoxDescription.Text = order.Description;
                textBoxTotalAmount.Text = Convert.ToString(order.TotalAmount);
                if (order.Status == 1)
                {
                    orderStatus = "Open";
                }
                else
                {
                    orderStatus = "Posted";
                }
                textBoxStatus.Text = orderStatus;
                comboBoxCustomer.SelectedItem = customer.Name;
                comboBoxWarehause.SelectedItem = warehouse.Name;

            }
        }
        private void InsertDataIntoTable(Order order)
        {
            orderLinesTable.Rows.Clear();
            List<OrderLine> orderLine = new List<OrderLine>();
            Product product = new Product();
            orderLine = orderRepositoryBus.GetAllOrderLinesById(order.Id);
            foreach (var ordLine in orderLine)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(orderLinesTable);
                row.Cells[0].Value = ordLine.OrderId;
                product = productRepositoryBus.GetProductById(ordLine.ProductId);
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = ordLine.UnitPrice;
                row.Cells[3].Value = ordLine.Quantity;
                row.Cells[4].Value = ordLine.Discount;
                orderLinesTable.Rows.Add(row);
            }
        }

        private void OrderCard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wareHouse_AppDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.wareHouse_AppDataSet.Product);
        }

        private void orderLinesTable_SelectionChanged(object sender, EventArgs e)
        {
            if (orderLinesTable.SelectedCells.Count > 0)
            {
                int selectedrowindex = orderLinesTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = orderLinesTable.Rows[selectedrowindex];
                string productName = Convert.ToString(selectedRow.Cells["ProductId"].Value);
                if (productName != "")
                {
                    Product product = new Product();
                    product = productRepositoryBus.GetProductByName(productName);
                    selectedRow.Cells["UnitPrice"].Value = product.UnitPrice;
                    if (selectedRow.Cells["Qunatity"].Value == null)
                    {
                        selectedRow.Cells["Qunatity"].Value = 1;
                    }
                }
            }
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in orderLinesTable.Rows)
            {
                decimal lineAmount = 0;
                if (row.Cells["Qunatity"].Value != null && row.Cells["UnitPrice"].Value != null)
                {
                    lineAmount += Convert.ToDecimal(row.Cells["Qunatity"].Value.ToString()) * Convert.ToDecimal(row.Cells["UnitPrice"].Value.ToString());
                }
                if (row.Cells["Discount"].Value != null)
                {
                    lineAmount = lineAmount - (lineAmount * (Convert.ToDecimal(row.Cells["Discount"].Value.ToString()) / 100));
                }
                totalAmount += lineAmount;
            }
            textBoxTotalAmount.Text = totalAmount.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                order.Description = textBoxDescription.Text;
                order.Status = 1;
                order.CustomerId = customerRepositoryBus.GetCustomerIdByName(comboBoxCustomer.SelectedItem.ToString());
                order.WarehouseId = warehouseRepositoryBus.GetWarehouseIdByName(comboBoxWarehause.SelectedItem.ToString());
                order.OrderDate = dateTimePicker.Value;
                if (textBoxTotalAmount.Text != "")
                {
                    order.TotalAmount = Convert.ToDecimal(textBoxTotalAmount.Text);
                }
                if (textBoxOrderId.Text != "")
                {
                    order.Id = Convert.ToInt32(textBoxOrderId.Text);
                    orderRepositoryBus.UpdateOrder(order);
                }
                else
                {
                    orderRepositoryBus.InsertOrder(order);
                    order = orderRepositoryBus.GetLastOrder();
                }
                orderRepositoryBus.DeleteAllOrderLines(order.Id);
                foreach (DataGridViewRow row in orderLinesTable.Rows)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = order.Id;
                    if (row.Cells["ProductId"].Value == null)
                    {
                        continue;
                    }
                    orderLine.ProductId = productRepositoryBus.GetProductIdByName(row.Cells["ProductId"].Value.ToString());
                    orderLine.Quantity = Convert.ToInt32(row.Cells["Qunatity"].Value);
                    orderLine.UnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                    orderLine.Discount = Convert.ToDecimal(row.Cells["Discount"].Value);

                    orderRepositoryBus.InsertOrderLine(orderLine);
                }
                AutoClosingMessageBox.Show("Your Order is saved!", "Congratulations!", 1700);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something is wrong, please check your order", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                order.Description = textBoxDescription.Text;
                order.Status = 0;
                order.CustomerId = customerRepositoryBus.GetCustomerIdByName(comboBoxCustomer.SelectedItem.ToString());
                order.WarehouseId = warehouseRepositoryBus.GetWarehouseIdByName(comboBoxWarehause.SelectedItem.ToString());
                order.OrderDate = dateTimePicker.Value;
                if (textBoxTotalAmount.Text != "")
                {
                    order.TotalAmount = Convert.ToDecimal(textBoxTotalAmount.Text);
                }
                if (textBoxOrderId.Text != "")
                {
                    order.Id = Convert.ToInt32(textBoxOrderId.Text);
                    orderRepositoryBus.UpdateOrder(order);
                }
                else
                {
                    orderRepositoryBus.InsertOrder(order);
                    order = orderRepositoryBus.GetLastOrder();
                }
                orderRepositoryBus.DeleteAllOrderLines(order.Id);
                foreach (DataGridViewRow row in orderLinesTable.Rows)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = order.Id;
                    if (row.Cells["ProductId"].Value == null)
                    {
                        continue;
                    }
                    orderLine.ProductId = productRepositoryBus.GetProductIdByName(row.Cells["ProductId"].Value.ToString());
                    orderLine.Quantity = Convert.ToInt32(row.Cells["Qunatity"].Value);
                    orderLine.UnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                    orderLine.Discount = Convert.ToDecimal(row.Cells["Discount"].Value);

                    orderRepositoryBus.InsertOrderLine(orderLine);
                }
                AutoClosingMessageBox.Show("You have successfully posted your Order!", "Congratulations!", 1700);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something is wrong, please check your order", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void OrderCard_Activated(object sender, EventArgs e)
        {
            textBoxDescription.Focus();
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

}
