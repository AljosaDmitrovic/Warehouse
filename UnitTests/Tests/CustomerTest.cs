using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Models;
using BusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class CustomerTest
    {

        private CustomerRepositoryBus customerRepositoryBus = new CustomerRepositoryBus();


        /************************************************** SUPPLIER **************************************************/
        /* -INSERT- */
        [TestMethod]
        public void InsertCustomerInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Customer customer = new Customer();

                customer.Name = "Random name";
                customer.Phone = "Random phone";

                customerRepositoryBus.InsertCustomer(customer);

                foreach (Customer categ in customerRepositoryBus.GetAllCustomers())
                {
                    if (categ.Name == customer.Name && categ.Phone == customer.Phone)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }


        /* -UPDATE- */
        [TestMethod]
        public void UpdateCustomerInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Customer customer = new Customer();

                customer.Name = "Random name";
                customer.Phone = "Random phone";

                customerRepositoryBus.InsertCustomer(customer);

                foreach (Customer categ in customerRepositoryBus.GetAllCustomers())
                {
                    if (categ.Name == customer.Name && categ.Phone == customer.Phone)
                    {
                        brojac++;
                        customer = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                customer.Name = "Updated name";
                customerRepositoryBus.UpdateCustomer(customer);

                foreach (Customer categ in customerRepositoryBus.GetAllCustomers())
                {
                    if (categ.Name == customer.Name && categ.Phone == customer.Phone)
                    {
                        brojac++;
                    }
                }
                Assert.AreEqual(2, brojac);
            }
        }

        /* -UPDATE- */

        [TestMethod]
        public void DeleteCustomerInDatabase()
        {
            using (TransactionScope scope = new TransactionScope()) //auto roll back
            {
                int brojac = 0;
                Customer customer = new Customer();

                customer.Name = "Random name";
                customer.Phone = "Random phone";

                customerRepositoryBus.InsertCustomer(customer);

                foreach (Customer categ in customerRepositoryBus.GetAllCustomers())
                {
                    if (categ.Name == customer.Name && categ.Phone == customer.Phone)
                    {
                        brojac++;
                        customer = categ;
                    }
                }
                Assert.AreEqual(1, brojac);
                customerRepositoryBus.DeleteCustomer(customer.Id);
                foreach (Customer categ in customerRepositoryBus.GetAllCustomers())
                {
                    if (categ.Name == customer.Name && categ.Phone == customer.Phone)
                    {
                        brojac++;
                        categ.Id = customer.Id;
                    }
                }
                Assert.AreEqual(1, brojac);
            }
        }
    }
}
