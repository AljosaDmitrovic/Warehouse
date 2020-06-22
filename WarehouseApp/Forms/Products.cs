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
    public partial class Products : Form
    {
        private ProductRepositoryBus productRepositoryBus = new ProductRepositoryBus();
        private SupplierRepositoryBus supplierRepositoryBus = new SupplierRepositoryBus();
        private CategoryRepositoryBus categoryRepositoryBus = new CategoryRepositoryBus();
        public Products()
        {
            InitializeComponent();
            InsertDataIntoTable();
        }
        private void InsertDataIntoTable()
        {
            productsTable.Rows.Clear();
            List<Product> productList = new List<Product>();
            productList = productRepositoryBus.GetAllProducts();
            foreach (var product in productList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(productsTable);
                row.Cells[0].Value = product.Id;
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = supplierRepositoryBus.GetSupplierNameById(product.SupplierId);
                row.Cells[3].Value = product.UnitPrice;
                row.Cells[4].Value = categoryRepositoryBus.GetCategoryNameById(product.CategoryId);
                productsTable.Rows.Add(row);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            ProductCard productCard = new ProductCard();
            Product product = new Product();
            productCard.SetParameters(true, product);
            productCard.ShowDialog();
            InsertDataIntoTable();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (productsTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(productsTable.SelectedRows[0].Cells["Id"].Value.ToString());
                Product product = new Product();
                product = productRepositoryBus.GetProductById(id);
                ProductCard productCard = new ProductCard();
                productCard.SetParameters(false, product);
                productCard.ShowDialog();
                InsertDataIntoTable();
                //TODO Refresh View
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (productsTable.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(productsTable.SelectedRows[0].Cells["Id"].Value.ToString());
                try
                {
                    productRepositoryBus.DeleteProduct(id);
                }
                catch (Exception exe)
                {
                    MessageBox.Show("This Record is used and cannot be deleted!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InsertDataIntoTable();
            }
        }

        private void productsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
