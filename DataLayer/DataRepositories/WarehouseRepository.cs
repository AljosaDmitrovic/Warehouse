using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class WarehouseRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */

        public List<Warehouse> GetAllWarehouses()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Warehouse";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Warehouse> listToReturn = new List<Warehouse>();

                while (sqlDataReader.Read())
                {
                    Warehouse warehouse = new Warehouse();
                    warehouse.Id = sqlDataReader.GetInt32(0);
                    warehouse.Name = sqlDataReader.GetString(1);
                    warehouse.LocationId = sqlDataReader.GetInt32(2);
                    listToReturn.Add(warehouse);
                }
                return listToReturn;
            }
        }
        /* ---------------------------------------------- GET BY ID ---------------------------------------------- */
        public Warehouse GetWarehouseById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Warehouse WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Warehouse> listToReturn = new List<Warehouse>();

                sqlDataReader.Read();
                    Warehouse warehouse = new Warehouse();
                    warehouse.Id = sqlDataReader.GetInt32(0);
                    warehouse.Name = sqlDataReader.GetString(1);
                    warehouse.LocationId = sqlDataReader.GetInt32(2);

                return warehouse;
            }
        }
        public int GetWarehouseIdByName(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Warehouse WHERE Name='{name}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Warehouse> listToReturn = new List<Warehouse>();

                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);

            }
        }
        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertWarehouse(Warehouse war)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Warehouse(Name, LocationId) VALUES('{war.Name}', '{war.LocationId}')";

                return command.ExecuteNonQuery();
            }
        }
        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateWarehouse(Warehouse war)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Warehouse SET Name='{war.Name}', LocationId='{war.LocationId}' WHERE Id='{war.Id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteWarehouse(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Warehouse WHERE id='{id}'"; 

                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
