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
    public partial class Suppliers : Form
    {
        private SupplierRepositoryBus supplierRepository = new SupplierRepositoryBus();
        public Suppliers()
        {
            InitializeComponent();
            InsertDataIntoTable();
        }
        private void InsertDataIntoTable()
        {
            suppliersTable.Rows.Clear();
            
            List<Supplier> supplierList = new List<Supplier>();
            supplierList = supplierRepository.GetAllSuppliers();
            foreach (var supplier in supplierList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(suppliersTable);
                row.Cells[0].Value = supplier.Id;
                row.Cells[1].Value = supplier.Name;
                row.Cells[2].Value = supplier.Phone;
                suppliersTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            SupplierCard supplierCard = new SupplierCard();
            Supplier supplier = new Supplier();
            supplierCard.SetParameters(true, supplier);
            supplierCard.ShowDialog();
            InsertDataIntoTable();

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (suppliersTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(suppliersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Supplier supplier = new Supplier();
                supplier = supplierRepository.GetSupplierById(id);
                SupplierCard supplierCard = new SupplierCard();
                supplierCard.SetParameters(false, supplier);
                supplierCard.ShowDialog();
                InsertDataIntoTable();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (suppliersTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(suppliersTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                    supplierRepository.DeleteSupplier(id);
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
