using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class CategoryTest
    {

        private CategoryRepositoryBus categoryRepositoryBus = new CategoryRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertCategoryInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Category category = new Category();

                category.Description = "Random description";
                

                categoryRepositoryBus.InsertCategory(category);

                foreach (Category categ in categoryRepositoryBus.GetAllCategories())
                {
                    if (categ.Description == category.Description)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateCategoryInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Category category = new Category();

                category.Description = "Random description";
                

                categoryRepositoryBus.InsertCategory(category);

                foreach (Category categ in categoryRepositoryBus.GetAllCategories())
                {
                    if (categ.Description == category.Description)
                    {
                        brojac++;
                        category = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                category.Description = "Updated description";
                categoryRepositoryBus.UpdateCategory(category);

                foreach (Category categ in categoryRepositoryBus.GetAllCategories())
                {
                    if (categ.Description == category.Description)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }

        /* -UPDATE- */

        [TestMethod]
        public void DeleteCategoryInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Category category = new Category();

                category.Description = "Random description";
                

                categoryRepositoryBus.InsertCategory(category);

                foreach (Category categ in categoryRepositoryBus.GetAllCategories())
                {
                    if (categ.Description == category.Description)
                    {
                        brojac++;
                        category = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                categoryRepositoryBus.DeleteCategory(category.Id);
                foreach (Category categ in categoryRepositoryBus.GetAllCategories())
                {
                    if (categ.Description == category.Description)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
