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
    public partial class Customers : Form
    {
        private CustomerRepositoryBus customerRepository = new CustomerRepositoryBus();
        public Customers()
        {
            InitializeComponent();
            InsertDataIntoTable();
        }
        private void InsertDataIntoTable()
        {
            customersTable.Rows.Clear();
            List<Customer> customerList = new List<Customer>();
            customerList = customerRepository.GetAllCustomers();
            foreach (var customer in customerList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(customersTable);
                row.Cells[0].Value = customer.Id;
                row.Cells[1].Value = customer.Name;
                row.Cells[2].Value = customer.Phone;
                customersTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            CustomerCard customerCard = new CustomerCard();
            Customer customer = new Customer();
            customerCard.SetParameters(true, customer);
            customerCard.ShowDialog();
            InsertDataIntoTable();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (customersTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(customersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Customer customer = new Customer();
                customer = customerRepository.GetCustomerById(id);
                CustomerCard customerCard = new CustomerCard();
                customerCard.SetParameters(false, customer);
                customerCard.ShowDialog();
                InsertDataIntoTable();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (customersTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(customersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                    customerRepository.DeleteCustomer(id);
                }
                catch (Exception exe)
                {
                    MessageBox.Show("This Record is used and cannot be deleted!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InsertDataIntoTable();
            }
        }
    }
}
