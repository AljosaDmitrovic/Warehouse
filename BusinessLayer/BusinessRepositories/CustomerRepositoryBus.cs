using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.DataRepositories;
using DataLayer.Models;

namespace BusinessLayer
{
    public class CustomerRepositoryBus
    {
        private CustomerRepository customerRepository;

        public CustomerRepositoryBus()
        {
            this.customerRepository = new CustomerRepository();
        }

        public List<Customer> GetAllCustomers()
        {
            return this.customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return this.customerRepository.GetCustomerById(id);
        }
        public int GetCustomerIdByName(string name)
        {
            return this.customerRepository.GetCustomerIdByName(name);
        }
        public bool InsertCustomer(Customer cus)
        {
            int result = 0;
            if (cus != null)
            {
                result = this.customerRepository.InsertCustomer(cus);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer cus)
        {
            int result = 0;
            if (cus != null)
            {
                result = this.customerRepository.UpdateCustomer(cus);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            int result = this.customerRepository.DeleteCustomer(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

