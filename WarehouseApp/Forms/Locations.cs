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
    public partial class Locations : Form
    {
    private LocationRepositoryBus locationRepository = new LocationRepositoryBus();
        public Locations()
        {
            InitializeComponent();
            InsertDataIntoTable();
        }
        private void InsertDataIntoTable()
        {
            locationsTable.Rows.Clear();
            List<Location> locationList = new List<Location>();
            locationList = locationRepository.GetAllLocations();
            foreach (var location in locationList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(locationsTable);
                row.Cells[0].Value = location.Id;
                row.Cells[1].Value = location.Name;
                row.Cells[2].Value = location.Adress;
                row.Cells[3].Value = location.Country;
                locationsTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            LocationCard locationCard = new LocationCard();
            Location location = new Location();
            locationCard.SetParameters(true, location);
            locationCard.ShowDialog();
            InsertDataIntoTable();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (locationsTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(locationsTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Location location = new Location();
                location = locationRepository.GetLocationById(id);
                LocationCard locationCard = new LocationCard();
                locationCard.SetParameters(false, location);
                locationCard.ShowDialog();
                InsertDataIntoTable();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (locationsTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(locationsTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                    locationRepository.DeleteLocation(id);
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
