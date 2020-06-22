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
    public partial class Categories : Form
    {
        private CategoryRepositoryBus categoryRepositoryBus = new CategoryRepositoryBus();
        public Categories()
        {
            InitializeComponent();
            InsertDataIntoTable();
        }
        private void ClearDataFromTable()
        {
            categoriesTable.Rows.Clear();
        }
        private void InsertDataIntoTable()
        {
            ClearDataFromTable();
            
            List<Category> categoryList = new List<Category>();
            categoryList = categoryRepositoryBus.GetAllCategories();
            foreach (var category in categoryList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(categoriesTable);
                row.Cells[0].Value = category.Id;
                row.Cells[1].Value = category.Description;
                categoriesTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            CategoryCard categoryCard = new CategoryCard();
            Category category = new Category();
            categoryCard.SetParameters(true, category);
            categoryCard.ShowDialog();
            InsertDataIntoTable();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (categoriesTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(categoriesTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Category category = new Category();
                category = categoryRepositoryBus.GetCategoryById(id);
                CategoryCard categoryCard = new CategoryCard();
                categoryCard.SetParameters(false, category);
                categoryCard.ShowDialog();
                InsertDataIntoTable();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (categoriesTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(categoriesTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                    categoryRepositoryBus.DeleteCategory(id);
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
