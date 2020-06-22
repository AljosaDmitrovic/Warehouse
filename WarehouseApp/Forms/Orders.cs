using DataLayer.Models;
using BusinessLayer;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace WarehouseApp.Forms
{
    public partial class Orders : Form
    {
        private CustomerRepositoryBus customerRepositoryBus = new CustomerRepositoryBus();
        private OrderRepositoryBus orderRepositoryBus = new OrderRepositoryBus();
        private WarehouseRepositoryBus warehouseRepositoryBus = new WarehouseRepositoryBus();
        private bool finishedOrder;
        public Orders(bool finished)
        {
            finishedOrder = finished;
            InitializeComponent();
            InsertDataIntoTable();
            if (finished)
            {
                buttonDelete.Enabled = !finished;
                buttonNew.Enabled = !finished;
            }
        }
        private void InsertDataIntoTable()
        {
            string orderStatus = "";
            Customer customer = new Customer();
            Warehouse warehouse = new Warehouse();
            
            ordersTable.Rows.Clear();
            
            List<Order> orderList = new List<Order>();
            orderList = orderRepositoryBus.GetAllOrders();
            foreach (var order in orderList)
            {
                switch (finishedOrder)
                {
                    case true:
                        if (order.Status == 1)
                        {
                            continue;
                        }
                        orderStatus = "Posted";
                        break;
                    case false:
                        if (order.Status != 1)
                        {
                            continue;
                        }
                        orderStatus = "Open";
                        break;
                    default:
                        break;
                }

                customer = customerRepositoryBus.GetCustomerById(order.CustomerId);
                warehouse = warehouseRepositoryBus.GetWarehouseById(order.WarehouseId);

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(ordersTable);
                row.Cells[0].Value = order.Id;
                row.Cells[1].Value = order.Description;
                row.Cells[2].Value = customer.Name;
                row.Cells[3].Value = order.OrderDate;
                row.Cells[4].Value = order.TotalAmount;
                row.Cells[5].Value = orderStatus;
                row.Cells[6].Value = warehouse.Name;
                ordersTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, System.EventArgs e)
        {
            Order order = new Order();
            OrderCard orderCard = new OrderCard(order,finishedOrder);
            orderCard.SetParameters(true, order);
            orderCard.ShowDialog();
            InsertDataIntoTable();
        }

        private void buttonOpen_Click(object sender, System.EventArgs e)
        {
            if (ordersTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(ordersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Order order = new Order();
                order = orderRepositoryBus.GetOrderById(id);
                OrderCard orderCard = new OrderCard(order,finishedOrder);
                orderCard.SetParameters(false, order);
                if(finishedOrder)
                {
                        orderCard.Show();
                }
                else
                {
                    orderCard.ShowDialog();
                }
                InsertDataIntoTable();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ordersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                orderRepositoryBus.DeleteAllOrderLines(id);
                orderRepositoryBus.DeleteOrder(id);
                InsertDataIntoTable();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
