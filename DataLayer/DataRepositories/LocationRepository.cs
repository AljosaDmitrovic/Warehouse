using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class LocationRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */
        public List<Location> GetAllLocations()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Location";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Location> listToReturn = new List<Location>();

                while (sqlDataReader.Read())
                {
                    Location location = new Location();
                    location.Id = sqlDataReader.GetInt32(0);
                    location.Name = sqlDataReader.GetString(1);
                    location.Adress = sqlDataReader.GetString(2);
                    location.Country = sqlDataReader.GetString(3);
                    listToReturn.Add(location);
                }
                return listToReturn;
            }
        }
        /* ---------------------------------------------- GET BY NAME ---------------------------------------------- */
        public Location GetLocationByName(String locName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Location WHERE Name='{locName}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Location location = new Location();
                location.Id = sqlDataReader.GetInt32(0);
                location.Name = sqlDataReader.GetString(1);
                location.Adress = sqlDataReader.GetString(2);
                location.Country = sqlDataReader.GetString(3);

                return location;
            }
        }
        /* ---------------------------------------------- GET ID BY NAME ---------------------------------------------- */
        public int GetLocationIdByName(String locName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Location WHERE Name='{locName}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetInt32(0);
            }
        }
        /* ---------------------------------------------- GET BY ID ---------------------------------------------- */
        public Location GetLocationById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Location WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Location location = new Location();
                location.Id = sqlDataReader.GetInt32(0);
                location.Name = sqlDataReader.GetString(1);
                location.Adress = sqlDataReader.GetString(2);
                location.Country = sqlDataReader.GetString(3);

                return location;
            }
        }
        /* ---------------------------------------------- GET NAME BY ID ---------------------------------------------- */
        public String GetLocationNameById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Location WHERE Id='{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                return sqlDataReader.GetString(1);

            }
        }
        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertLocation(Location loc)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Location(Name, Adress, Country) VALUES('{loc.Name}', '{loc.Adress}', '{loc.Country}')";

                return command.ExecuteNonQuery();
            }
        }



        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateLocation(Location loc)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Location SET Name='{loc.Name}', Adress='{loc.Adress}', Country='{loc.Country}' WHERE Id='{loc.Id}'";
                
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteLocation(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Location WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
