using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class SupplierRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */
        public List<Supplier> GetAllSuppliers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Supplier";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Supplier> listToReturn = new List<Supplier>();

                while (sqlDataReader.Read())
                {
                    Supplier suplier = new Supplier();
                    suplier.Id = sqlDataReader.GetInt32(0);
                    suplier.Name = sqlDataReader.GetString(1);
                    suplier.Phone = sqlDataReader.GetString(2);
                    listToReturn.Add(suplier);
                }
                return listToReturn;
            }
        }

        public Supplier GetSupplierById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Supplier WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Supplier supplier = new Supplier();
                supplier.Id = sqlDataReader.GetInt32(0);
                supplier.Name = sqlDataReader.GetString(1);
                supplier.Phone = sqlDataReader.GetString(2);


                return supplier;
            }
        }
        public string GetSupplierNameById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Supplier WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetString(1);
            }
        }
        public int GetSupplierIdByName(String supName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Supplier WHERE Name='{supName}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);
            }
        }
        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertSupplier(Supplier sup)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Supplier(Name, Phone) VALUES('{sup.Name}', '{sup.Phone}')";

                return command.ExecuteNonQuery();
            }
        }


        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateSupplier(Supplier sup)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Supplier SET Name='{sup.Name}', Phone='{sup.Phone}' WHERE Id='{sup.Id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteSupplier(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Supplier WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }


    }
}
