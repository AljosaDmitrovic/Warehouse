using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class SupplierTest
    {

        private SupplierRepositoryBus supplierRepositoryBus = new SupplierRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertSupplierInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Supplier supplier = new Supplier();

                supplier.Name = "Random name";
                supplier.Phone = "Random phone";

                supplierRepositoryBus.InsertSupplier(supplier);

                foreach (Supplier categ in supplierRepositoryBus.GetAllSuppliers())
                {
                    if (categ.Name == supplier.Name && categ.Phone == supplier.Phone)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateSupplierInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Supplier supplier = new Supplier();

                supplier.Name = "Random name";
                supplier.Phone = "Random phone";

                supplierRepositoryBus.InsertSupplier(supplier);

                foreach (Supplier categ in supplierRepositoryBus.GetAllSuppliers())
                {
                    if (categ.Name == supplier.Name && categ.Phone == supplier.Phone)
                    {
                        brojac++;
                        supplier = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                supplier.Name = "Updated name";
                supplierRepositoryBus.UpdateSupplier(supplier);

                foreach (Supplier categ in supplierRepositoryBus.GetAllSuppliers())
                {
                    if (categ.Name == supplier.Name && categ.Phone == supplier.Phone)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }
        //Delete
        [TestMethod]
        public void DeleteSupplierInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Supplier supplier = new Supplier();

                supplier.Name = "Random name";
                supplier.Phone = "Random phone";

                supplierRepositoryBus.InsertSupplier(supplier);

                foreach (Supplier categ in supplierRepositoryBus.GetAllSuppliers())
                {
                    if (categ.Name == supplier.Name && categ.Phone == supplier.Phone)
                    {
                        brojac++;
                        supplier = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                supplierRepositoryBus.DeleteSupplier(supplier.Id);
                foreach (Supplier categ in supplierRepositoryBus.GetAllSuppliers())
                {
                    if (categ.Name == supplier.Name && categ.Phone == supplier.Phone)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
