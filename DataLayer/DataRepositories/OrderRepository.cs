using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.DataRepositories
{
    public class OrderRepository
    {
        /* ---------------------------------------------- GET ALL ---------------------------------------------- */
        public List<Order> GetAllOrders()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Orders";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Order> listToReturn = new List<Order>();

                while (sqlDataReader.Read())
                {
                    Order order = new Order();
                    order.Id = sqlDataReader.GetInt32(0);
                    order.Description = sqlDataReader.GetString(1);
                    order.CustomerId = sqlDataReader.GetInt32(2);
                    order.OrderDate = sqlDataReader.GetDateTime(3);
                    order.TotalAmount = sqlDataReader.GetDecimal(4);
                    order.Status = sqlDataReader.GetInt32(5);
                    order.WarehouseId = sqlDataReader.GetInt32(6);
                    listToReturn.Add(order);
                }
                return listToReturn;
            }
        }
        public Order GetOrderById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM Orders WHERE Id = '{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                    Order order = new Order();
                    order.Id = sqlDataReader.GetInt32(0);
                    order.Description = sqlDataReader.GetString(1);
                    order.CustomerId = sqlDataReader.GetInt32(2);
                    order.OrderDate = sqlDataReader.GetDateTime(3);
                    order.TotalAmount = sqlDataReader.GetDecimal(4);
                    order.Status = sqlDataReader.GetInt32(5);
                    order.WarehouseId = sqlDataReader.GetInt32(6);
                return order;
            }
        }

        
        public List<OrderLine> GetAllOrderLines()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM OrderLine";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<OrderLine> listToReturn = new List<OrderLine>();

                while (sqlDataReader.Read())
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = sqlDataReader.GetInt32(0);
                    orderLine.ProductId = sqlDataReader.GetInt32(1);
                    orderLine.UnitPrice = sqlDataReader.GetDecimal(2);
                    orderLine.Quantity = sqlDataReader.GetInt32(3);
                    orderLine.Discount = sqlDataReader.GetDecimal(4);
                    listToReturn.Add(orderLine);
                }
                return listToReturn;
            }
        }
        public List<OrderLine> GetAllOrderLinesById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM OrderLine WHERE OrderId = '{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<OrderLine> listToReturn = new List<OrderLine>();

                while (sqlDataReader.Read())
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = sqlDataReader.GetInt32(0);
                    orderLine.ProductId = sqlDataReader.GetInt32(1);
                    orderLine.UnitPrice = sqlDataReader.GetDecimal(2);
                    orderLine.Quantity = sqlDataReader.GetInt32(3);
                    orderLine.Discount = sqlDataReader.GetDecimal(4);
                    listToReturn.Add(orderLine);
                }
                return listToReturn;
            }
        }
        public List<OrderLine> GetAllOrderLinesProductById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT * FROM OrderLine WHERE ProductId = '{id}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<OrderLine> listToReturn = new List<OrderLine>();

                while (sqlDataReader.Read())
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.OrderId = sqlDataReader.GetInt32(0);
                    orderLine.ProductId = sqlDataReader.GetInt32(1);
                    orderLine.UnitPrice = sqlDataReader.GetDecimal(2);
                    orderLine.Quantity = sqlDataReader.GetInt32(3);
                    orderLine.Discount = sqlDataReader.GetDecimal(4);
                    listToReturn.Add(orderLine);
                }
                return listToReturn;
            }
        }
        public Order GetLastOrder()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"SELECT TOP 1 * FROM Orders ORDER BY Id DESC";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                Order order = new Order();
                order.Id = sqlDataReader.GetInt32(0);
                order.Description = sqlDataReader.GetString(1);
                order.CustomerId = sqlDataReader.GetInt32(2);
                order.OrderDate = sqlDataReader.GetDateTime(3);
                order.TotalAmount = sqlDataReader.GetDecimal(4);
                order.Status = sqlDataReader.GetInt32(5);
                order.WarehouseId = sqlDataReader.GetInt32(6);
                return order;
            }
        }
        //SELECT TOP 1 * FROM Table ORDER BY ID DESC

        /* ---------------------------------------------- INSERT ---------------------------------------------- */

        public int InsertOrder(Order ord)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.Orders(Description, CustomerId, OrderDate, TotalAmount, Status, WarehouseId) VALUES('{ord.Description}', '{ord.CustomerId}','{ord.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{ord.TotalAmount}', '{ord.Status}', '{ord.WarehouseId}')";

                return command.ExecuteNonQuery();
            }
        }
        public int InsertOrderLine(OrderLine ordLine)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = $"INSERT INTO dbo.OrderLine(OrderId, ProductId, UnitPrice, Quantity, Discount) VALUES('{ordLine.OrderId}', '{ordLine.ProductId}','{ordLine.UnitPrice}', '{ordLine.Quantity}', '{ordLine.Discount}')";

                return command.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- UPDATE ---------------------------------------------- */

        public int UpdateOrder(Order ord)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"UPDATE dbo.Orders SET Description='{ord.Description}', CustomerId='{ord.CustomerId}' , OrderDate='{ord.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', TotalAmount='{ord.TotalAmount}', Status='{ord.Status}', WarehouseId='{ord.WarehouseId}' WHERE Id='{ord.Id}'";
                
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* ---------------------------------------------- DELETE ---------------------------------------------- */
        public int DeleteOrder(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.Orders WHERE id='{id}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteAllOrderLines(int Orderid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString.DatabaseConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"DELETE FROM dbo.OrderLine WHERE OrderId='{Orderid}'";

                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
