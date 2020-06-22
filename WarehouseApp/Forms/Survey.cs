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
    public partial class Survey : Form
    {
        private ProductRepositoryBus productRepositoryBus = new ProductRepositoryBus();
        private CategoryRepositoryBus categoryRepositoryBus = new CategoryRepositoryBus();
        private SupplierRepositoryBus supplierRepositoryBus = new SupplierRepositoryBus();
        private CustomerRepositoryBus customerRepositoryBus = new CustomerRepositoryBus();
        private LocationRepositoryBus locationRepositoryBus = new LocationRepositoryBus();
        private WarehouseRepositoryBus warehouseRepositoryBus = new WarehouseRepositoryBus();
        public Survey()
        {
            InitializeComponent();
            InsertDataIntoCategoryTable();
            InsertDataIntoCustomersTable();
            InsertDataIntoLocationTable();
            InsertDataIntoSuppliersTable();
            InsertDataIntoProductsTable();
            InsertDataIntoWareHouseTable();
        }
        private void ClearDataFromCategoryTable()
        {
            categoriesTable.Rows.Clear();
        }
        List<Category> categoryList = new List<Category>();
        List<Customer> customerList = new List<Customer>();
        List<Location> locationList = new List<Location>();
        List<Supplier> supplierList = new List<Supplier>();
        List<Product> productList = new List<Product>();

        private void InsertDataIntoCategoryTable()
        {
            ClearDataFromCategoryTable();
            
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
        private void InsertDataIntoCustomersTable()
        {
            customersTable.Rows.Clear();
            customerList = customerRepositoryBus.GetAllCustomers();
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
        private void InsertDataIntoLocationTable()
        {
            locationsTable.Rows.Clear();
            locationList = locationRepositoryBus.GetAllLocations();
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
        private void InsertDataIntoSuppliersTable()
        {
            suppliersTable.Rows.Clear();
            supplierList = supplierRepositoryBus.GetAllSuppliers();
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
        private void InsertDataIntoProductsTable()
        {
            productsTable.Rows.Clear();
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
        private void InsertDataIntoWareHouseTable()
        {
            warehouseTable.Rows.Clear();
            List<Warehouse> warehouseList = new List<Warehouse>();
            warehouseList = warehouseRepositoryBus.GetAllWarehouses();
            foreach (var warehouse in warehouseList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(warehouseTable);
                row.Cells[0].Value = warehouse.Id;
                row.Cells[1].Value = warehouse.Name;
                row.Cells[2].Value = locationRepositoryBus.GetLocationNameById(warehouse.LocationId);
                warehouseTable.Rows.Add(row);
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startUp = new StartUp();
            startUp.ShowDialog();
            this.Close();
        }

        private void buttonTakeSurvey_Click(object sender, EventArgs e)
        {
            panelCategory.Visible = true;
        }

        private void Survey_Load(object sender, EventArgs e)
        {

        }

        private void buttonCatNext_Click(object sender, EventArgs e)
        {

            if (categoryList.Count != categoriesTable.Rows.Count - 1)
            {
                for (int i = categoryList.Count; i < categoriesTable.Rows.Count - 1; i++)
                {
                   
                    Category category = new Category();
                    category.Description = categoriesTable.Rows[i].Cells["Description"].Value.ToString();
                    categoryRepositoryBus.InsertCategory(category);
                }
            }
            panelCustomer.Visible = true;
        }

        private void buttonCusNext_Click(object sender, EventArgs e)
        {
            if (customerList.Count != customersTable.Rows.Count - 1)
            {
                for (int i = customerList.Count; i < customersTable.Rows.Count - 1; i++)
                {
                    Customer customer = new Customer();
                    customer.Name = customersTable.Rows[i].Cells["NameCustomer"].Value.ToString();
                    customer.Phone = customersTable.Rows[i].Cells["PhoneCustomer"].Value.ToString();
                    customerRepositoryBus.InsertCustomer(customer);
                }
            }
            panelLocation.Visible = true;
        }

        private void buttonLocNext_Click(object sender, EventArgs e)
        {
            if (locationList.Count != locationsTable.Rows.Count - 1)
            {
                for (int i = locationList.Count; i < locationsTable.Rows.Count - 1; i++)
                {
                    Location location = new Location();
                    location.Name = locationsTable.Rows[i].Cells["NameLocation"].Value.ToString();
                    location.Adress = locationsTable.Rows[i].Cells["AdressLocation"].Value.ToString();
                    location.Country = locationsTable.Rows[i].Cells["CountryLocation"].Value.ToString();
                    locationRepositoryBus.InsertLocation(location);
                }
            }
            panelSupplier.Visible = true;
        }

        private void buttonSuppNext_Click(object sender, EventArgs e)
        {
            if (supplierList.Count != suppliersTable.Rows.Count - 1)
            {
                for (int i = supplierList.Count; i < suppliersTable.Rows.Count - 1; i++)
                {
                    Supplier supplier = new Supplier();
                    supplier.Name = suppliersTable.Rows[i].Cells["NameSupplier"].Value.ToString();
                    supplier.Phone = suppliersTable.Rows[i].Cells["PhoneSupplier"].Value.ToString();
                    supplierRepositoryBus.InsertSupplier(supplier);
                }
            }
            panelProduct.Visible = true;
        }

        private void buttonProdNext_Click(object sender, EventArgs e)
        {
            panelWareHouse.Visible = true;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startUp = new StartUp();
            startUp.ShowDialog();
            this.Close();
        }
    }
}
