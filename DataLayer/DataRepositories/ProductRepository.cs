using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class ProductRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */
        public List<Product> GetAllProducts()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Product";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Product> listToReturn = new List<Product>();

                while (sqlDataReader.Read())
                {
                    Product product = new Product();
                    product.Id = sqlDataReader.GetInt32(0);
                    product.Name = sqlDataReader.GetString(1);
                    product.SupplierId = sqlDataReader.GetInt32(2);
                    product.UnitPrice = sqlDataReader.GetDecimal(3);
                    product.CategoryId = sqlDataReader.GetInt32(4);
                    listToReturn.Add(product);
                }
                return listToReturn;
            }
        }
        /* ---------------------------------------------- GET PRODUCT BY ID ---------------------------------------------- */
        public Product GetProductById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Product WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Product> listToReturn = new List<Product>();

                sqlDataReader.Read();
                Product product = new Product();
                product.Id = sqlDataReader.GetInt32(0);
                product.Name = sqlDataReader.GetString(1);
                product.SupplierId = sqlDataReader.GetInt32(2);
                product.UnitPrice = sqlDataReader.GetDecimal(3);
                product.CategoryId = sqlDataReader.GetInt32(4);
                return product;
            }
        }
        public Product GetProductByName(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Product WHERE Name='{name}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Product> listToReturn = new List<Product>();

                sqlDataReader.Read();
                Product product = new Product();
                product.Id = sqlDataReader.GetInt32(0);
                product.Name = sqlDataReader.GetString(1);
                product.SupplierId = sqlDataReader.GetInt32(2);
                product.UnitPrice = sqlDataReader.GetDecimal(3);
                product.CategoryId = sqlDataReader.GetInt32(4);
                return product;
            }
        }
        public int GetProductIdByName(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Product WHERE Name='{name}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Product> listToReturn = new List<Product>();

                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);
            }
        }

        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertProduct(Product pro)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Product(Name, SupplierId, UnitPrice, CategoryId) VALUES('{pro.Name}', '{pro.SupplierId}', '{pro.UnitPrice}', '{pro.CategoryId}')";

                return command.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateProduct(Product pro)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Product SET Name='{pro.Name}', SupplierId='{pro.SupplierId}', UnitPrice='{pro.UnitPrice}', CategoryId='{pro.CategoryId}' WHERE Id='{pro.Id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteProduct(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Product WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
