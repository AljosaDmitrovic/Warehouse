using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class ProductTest
    {

        private ProductRepositoryBus productRepositoryBus = new ProductRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertProductInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Product product = new Product();

                product.Name = "Random name";
                product.SupplierId = 1040; 
                product.UnitPrice= 100;
                product.CategoryId = 1025;

                productRepositoryBus.InsertProduct(product);

                foreach (Product categ in productRepositoryBus.GetAllProducts())
                {
                    if (categ.Name == product.Name && categ.SupplierId == product.SupplierId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateProductInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Product product = new Product();

                product.Name = "Random name";
                product.SupplierId = 1040;
                product.UnitPrice = 100;
                product.CategoryId = 1025;

                productRepositoryBus.InsertProduct(product);

                foreach (Product categ in productRepositoryBus.GetAllProducts())
                {
                    if (categ.Name == product.Name && categ.SupplierId == product.SupplierId && categ.UnitPrice == product.UnitPrice && categ.CategoryId == product.CategoryId)
                    {
                        brojac++;
                        product = categ;
                    }
                }
                Assert.AreEqual(1, brojac);


                product.Name = "Updated name";
                product.SupplierId = 1040;
                product.UnitPrice = 200;
                product.CategoryId = 1025;
                productRepositoryBus.UpdateProduct(product);

                foreach (Product categ in productRepositoryBus.GetAllProducts())
                {
                    if (categ.Name == product.Name && categ.SupplierId == product.SupplierId && categ.UnitPrice == product.UnitPrice && categ.CategoryId == product.CategoryId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }

        /* -UPDATE- */

        [TestMethod]
        public void DeleteProductInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Product product = new Product();

                product.Name = "Random name";
                product.SupplierId = 1040;
                product.UnitPrice = 100;
                product.CategoryId = 1025;

                productRepositoryBus.InsertProduct(product);

                foreach (Product categ in productRepositoryBus.GetAllProducts())
                {
                    if (categ.Name == product.Name && categ.SupplierId == product.SupplierId && categ.UnitPrice == product.UnitPrice && categ.CategoryId == product.CategoryId)
                    {
                        brojac++;
                        product = categ;
                    }
                }
                Assert.AreEqual(1, brojac);


                productRepositoryBus.DeleteProduct(product.Id);
                foreach (Product categ in productRepositoryBus.GetAllProducts())
                {
                    if (categ.Name == product.Name && categ.SupplierId == product.SupplierId && categ.UnitPrice == product.UnitPrice && categ.CategoryId== product.CategoryId)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
