using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class WarehouseTest
    {

        private WarehouseRepositoryBus warehouseRepositoryBus = new WarehouseRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertWarehouseInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Warehouse warehouse = new Warehouse();

                warehouse.Name = "Random name";
                warehouse.LocationId = 1024;

                warehouseRepositoryBus.InsertWarehouse(warehouse);

                foreach (Warehouse categ in warehouseRepositoryBus.GetAllWarehouses())
                {
                    if (categ.Name == warehouse.Name && categ.LocationId == warehouse.LocationId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateWarehouseInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Warehouse warehouse = new Warehouse();

                warehouse.Name = "Random name";
                warehouse.LocationId = 1024;

                warehouseRepositoryBus.InsertWarehouse(warehouse);

                foreach (Warehouse categ in warehouseRepositoryBus.GetAllWarehouses())
                {
                    if (categ.Name == warehouse.Name && categ.LocationId == warehouse.LocationId)
                    {
                        brojac++;
                        warehouse = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                warehouse.Name = "Updated name";
                warehouseRepositoryBus.UpdateWarehouse(warehouse);

                foreach (Warehouse categ in warehouseRepositoryBus.GetAllWarehouses())
                {
                    if (categ.Name == warehouse.Name && categ.LocationId == warehouse.LocationId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }

        /* -UPDATE- */

        [TestMethod]
        public void DeleteWarehouseInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Warehouse warehouse = new Warehouse();

                warehouse.Name = "Random name";
                warehouse.LocationId = 1024;

                warehouseRepositoryBus.InsertWarehouse(warehouse);

                foreach (Warehouse categ in warehouseRepositoryBus.GetAllWarehouses())
                {
                    if (categ.Name == warehouse.Name && categ.LocationId == warehouse.LocationId)
                    {
                        brojac++;
                        warehouse = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                warehouseRepositoryBus.DeleteWarehouse(warehouse.Id);
                foreach (Warehouse categ in warehouseRepositoryBus.GetAllWarehouses())
                {
                    if (categ.Name == warehouse.Name && categ.LocationId == warehouse.LocationId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
