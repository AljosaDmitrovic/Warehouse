using BusinessLayer;
using DataLayer.DataRepositories;
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
    public partial class Warehouses : Form
    {

        WarehouseRepositoryBus warehouseRepository = new WarehouseRepositoryBus();
        LocationRepositoryBus locationRepository = new LocationRepositoryBus();
        public Warehouses()
        {
            InitializeComponent();
            InsertDataIntoTable();

            this.warehouseRepository = new WarehouseRepositoryBus();


        }
        private void ClearDataFromTable()
        {
            warehouseTable.Rows.Clear();
        }
        private void InsertDataIntoTable()
        {
            ClearDataFromTable();
            List<Warehouse> warehouseList = new List<Warehouse>();
            warehouseList = warehouseRepository.GetAllWarehouses();
            foreach (var warehouse in warehouseList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(warehouseTable);
                row.Cells[0].Value = warehouse.Id;
                row.Cells[1].Value = warehouse.Name;
                row.Cells[2].Value = locationRepository.GetLocationNameById(warehouse.LocationId);
                warehouseTable.Rows.Add(row);
            }



        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            WarehouseCard warehouseCard = new WarehouseCard(warehouse);
            warehouseCard.SetParameters(true, warehouse);
            warehouseCard.ShowDialog();
            InsertDataIntoTable();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (warehouseTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(warehouseTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                warehouseRepository.DeleteWarehouse(id);
                }
                catch (Exception exe)
                {
                    MessageBox.Show("This Record is used and cannot be deleted!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InsertDataIntoTable();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (warehouseTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(warehouseTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Warehouse warehouse = new Warehouse();
                warehouse = warehouseRepository.GetWarehouseById(id);
                WarehouseCard warehouseCard = new WarehouseCard(warehouse);
                warehouseCard.SetParameters(false, warehouse);
                warehouseCard.ShowDialog();
                InsertDataIntoTable();
            }
        }
    }
}
