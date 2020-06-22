using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DataRepositories
{
    public class CategoryRepository
    {


        /* ---------------------------------------------- GET ALL ---------------------------------------------- */

        public List<Category> GetAllCategories()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM dbo.Category";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Category> listToReturn = new List<Category>();

                while (sqlDataReader.Read())
                {
                    Category category = new Category();
                    category.Id = sqlDataReader.GetInt32(0);
                    category.Description = sqlDataReader.GetString(1);
                    listToReturn.Add(category);
                }
                return listToReturn;
            }
        }

        /* ---------------------------------------------- GET BY ID ---------------------------------------------- */
        public Category GetCategoryById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Category WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Category category = new Category();
                category.Id = sqlDataReader.GetInt32(0);
                category.Description = sqlDataReader.GetString(1);

                return category;
            }
        }

        public string GetCategoryNameById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Category WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetString(1);
            }
        }
        public int GetCategoryIdByName(String catName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Category WHERE Description='{catName}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);
            }
        }


        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertCategory(Category cat)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Category(Description) VALUES('{cat.Description}')";

                return command.ExecuteNonQuery();
            }
        }


        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateCategory(Category cat)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Category SET Description='{cat.Description}' WHERE Id='{cat.Id}'";
                
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteCategory(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Category WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
