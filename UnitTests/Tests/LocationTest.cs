using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class LocationTest
    {

        private LocationRepositoryBus locationRepositoryBus = new LocationRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertLocationInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Location location = new Location();

                location.Name = "Random name";
                location.Adress = "Random Adress";
                location.Country = "Random Country";

                locationRepositoryBus.InsertLocation(location);

                foreach (Location categ in locationRepositoryBus.GetAllLocations())
                {
                    if (categ.Name == location.Name && categ.Adress == location.Adress && categ.Country == location.Country)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateLocationInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Location location = new Location();

                location.Name = "Random name";
                location.Adress = "Random phone";
                location.Country = "Random Country";

                locationRepositoryBus.InsertLocation(location);

                foreach (Location categ in locationRepositoryBus.GetAllLocations())
                {
                    if (categ.Name == location.Name && categ.Adress == location.Adress && categ.Country == location.Country)
                    {
                        brojac++;
                        location = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                location.Name = "Updated name";
                locationRepositoryBus.UpdateLocation(location);

                foreach (Location categ in locationRepositoryBus.GetAllLocations())
                {
                    if (categ.Name == location.Name && categ.Adress == location.Adress && categ.Country == location.Country)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }

        /* -UPDATE- */

        [TestMethod]
        public void DeleteLocationInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Location location = new Location();

                location.Name = "Random name";
                location.Adress = "Random phone";
                location.Country = "Random Country";

                locationRepositoryBus.InsertLocation(location);

                foreach (Location categ in locationRepositoryBus.GetAllLocations())
                {
                    if (categ.Name == location.Name && categ.Adress == location.Adress && categ.Country == location.Country)
                    {
                        brojac++;
                        location = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                locationRepositoryBus.DeleteLocation(location.Id);
                foreach (Location categ in locationRepositoryBus.GetAllLocations())
                {
                    if (categ.Name == location.Name && categ.Adress == location.Adress && categ.Country == location.Country)
                    {
                        brojac++;
                        categ.Id = location.Id;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
