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
    public partial class ProductCard : Form
    {
        private SupplierRepositoryBus supplierRepository = new SupplierRepositoryBus();
        private CategoryRepositoryBus categoryRepository = new CategoryRepositoryBus();
        private ProductRepositoryBus productRepository = new ProductRepositoryBus();
        public ProductCard()
        {
            InitializeComponent();
            FillSupplierComboBox();
            FillCategoryComboBox();
        }

        private void FillSupplierComboBox()
        {
            
            List<Supplier> supplierList = new List<Supplier>();
            supplierList = supplierRepository.GetAllSuppliers();
            foreach (var supplier in supplierList)
            {
                comboBoxSupplier.Items.Add(supplier.Name);
            }

        }
        private void FillCategoryComboBox()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = categoryRepository.GetAllCategories();
            foreach (var category in categoryList)
            {
                comboBoxCategory.Items.Add(category.Description);
            }
        }

        public void SetParameters(Boolean New, Product product)
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
                    Supplier supplier = new Supplier();
                    Category category = new Category();
                    supplier = supplierRepository.GetSupplierById(product.SupplierId);
                    category = categoryRepository.GetCategoryById(product.CategoryId);
                    textBoxId.Text = Convert.ToString(product.Id);
                    textBoxName.Text = product.Name;
                    textBoxUnitPrice.Text =Convert.ToString(product.UnitPrice);
                    comboBoxSupplier.SelectedItem = supplier.Name;
                    comboBoxCategory.SelectedItem = category.Description;
                    break;
                default:
                    break;
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
                    Product product = new Product();
                    product.Id = Convert.ToInt32(textBoxId.Text);
                    product.Name = textBoxName.Text;
                    product.SupplierId = supplierRepository.GetSupplierIdByName(comboBoxSupplier.SelectedItem.ToString());
                    product.UnitPrice = Convert.ToDecimal(textBoxUnitPrice.Text);
                    product.CategoryId = categoryRepository.GetCategoryIdByName(comboBoxCategory.SelectedItem.ToString());
                    productRepository.UpdateProduct(product);

                    AutoClosingMessageBox.Show("You have successfully updated your Product!", "Congratulations!", 1700);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to fill every field in order to continue.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    Product product = new Product();
                    product.Name = textBoxName.Text;
                    product.SupplierId = supplierRepository.GetSupplierIdByName(comboBoxSupplier.SelectedItem.ToString());
                    product.UnitPrice = Convert.ToDecimal(textBoxUnitPrice.Text);
                    product.CategoryId = categoryRepository.GetCategoryIdByName(comboBoxCategory.SelectedItem.ToString());
                    productRepository.InsertProduct(product);

                    AutoClosingMessageBox.Show("You have successfully added your Product!", "Congratulations!", 1700);
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

        private void ProductCard_Activated(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }
    }
}
