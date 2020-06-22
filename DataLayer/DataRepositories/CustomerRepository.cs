using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class CustomerRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */
        public List<Customer> GetAllCustomers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Customer";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Customer> listToReturn = new List<Customer>();

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = sqlDataReader.GetInt32(0);
                    customer.Name = sqlDataReader.GetString(1);
                    customer.Phone = sqlDataReader.GetString(2);
                    listToReturn.Add(customer);
                }
                return listToReturn;
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Customer WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Customer customer = new Customer();
                customer.Id = sqlDataReader.GetInt32(0);
                customer.Name = sqlDataReader.GetString(1);
                customer.Phone = sqlDataReader.GetString(2);
                

                return customer;
            }
        }
        public int GetCustomerIdByName(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Customer WHERE Name='{name}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);
            }
        }
        

        /* ---------------------------------------------- INSERT ---------------------------------------------- */
        public int InsertCustomer(Customer cus)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Customer(Name, Phone) VALUES('{cus.Name}', '{cus.Phone}')";

                return command.ExecuteNonQuery();
            }
        }


        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateCustomer(Customer cus)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Customer SET Name='{cus.Name}', Phone='{cus.Phone}' WHERE Id='{cus.Id}'";
                
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteCustomer(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Customer WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
