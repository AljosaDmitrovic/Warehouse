using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DataRepositories
{
    public class StockRepository
    {

        /* ---------------------------------------------- GET ALL ---------------------------------------------- */

        public List<Stock> GetAllStocks()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Stock";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Stock> listToReturn = new List<Stock>();

                while (sqlDataReader.Read())
                {
                    Stock stock = new Stock();
                    stock.WarehouseId = sqlDataReader.GetInt32(0);
                    stock.ProductId = sqlDataReader.GetInt32(1);
                    stock.Quantity = sqlDataReader.GetInt32(2);
                    listToReturn.Add(stock);
                }
                return listToReturn;
            }
        }

        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertStock(Stock sto)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Stock(WarehouseId, ProductId, Quantity) VALUES('{sto.WarehouseId}', '{sto.ProductId}', '{sto.Quantity}')";

                return command.ExecuteNonQuery();
            }
        }
        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateStock(Stock sto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Stock SET Quantity='{sto.Quantity}' WHERE ProductID='{sto.ProductId}' AND WarehouseID='{sto.WarehouseId}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteStock(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Stock WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
