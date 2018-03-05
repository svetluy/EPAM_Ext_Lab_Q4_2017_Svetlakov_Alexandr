namespace HMW_11_TestMethods
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrdersManagment
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

        public enum OrderStatus
        {
            New,
            InWork,
            Complete
        }

        [TestMethod]
        public void GetOrders()
        {
            const int ColumnsCount = 15;
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Northwind.Orders";

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                OrderStatus orderStatus;
                var values = new object[ColumnsCount];
               
                while (reader.Read())
                {
                    reader.GetValues(values);

                    foreach (var value in values)
                    {
                        Console.WriteLine(value);
                    }

                    if (values[5].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)1;
                        Console.WriteLine($"Order satus : {orderStatus}");
                    }
                    else if (values[3].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)0;
                        Console.WriteLine($"Order satus : {orderStatus}");
                    }
                    else
                    {
                        orderStatus = (OrderStatus)2;
                        Console.WriteLine($"Order satus : {orderStatus}");
                    }

                    Console.WriteLine("\n");
                }
            }
        }

        [TestMethod]
        public void GetOrderInfo(int orderID)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                const int ColumnsCount = 10;
                var command = connection.CreateCommand();
                command.CommandText = $@"select
                                         OD.*,ProductName
                                         from Northwind.[Order Details] as OD 
                                         inner join Northwind.Products as prod 
                                         on OD.ProductID = prod.ProductID  
                                         where OrderID = {orderID}; ";

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                var values = new object[ColumnsCount];

                while (reader.Read())
                {
                    reader.GetValues(values);
                    foreach (var value in values)
                    {
                        Console.Write($"  {value}");
                    }

                    Console.WriteLine();
                }
            }
        }

        [TestMethod]
        public void CreateNewOrder(
                                   string custmerID,
                                   int employeeID,
                                   string orderDate, 
                                   string requiueredDate, 
                                   string shippedDate,
                                   int shipVia, 
                                   double freight, 
                                   string shipName,
                                   string shipAdress,
                                   string shipCity, 
                                   string shipRegion, 
                                   int shipPostalCode, 
                                   string shipCountry)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"insert into Northwind.Orders values ('{custmerID}', {employeeID},{orderDate}, {requiueredDate}," +
                                                                            $" {shippedDate}, {shipVia}, {freight}, '{shipName}', '{shipAdress}'," +
                                                                               $"'{shipCity}', '{shipRegion}', {shipPostalCode}, '{shipCountry}');";

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void ChangeOrderStatus(int orderID, DateTime newDate)
        {
            const int ColumnsCount = 2;
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT OrderDate,ShippedDate FROM Northwind.Orders where OrderID = {orderID}";

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                OrderStatus orderStatus;
                var values = new object[ColumnsCount];

                while (reader.Read())
                {
                    reader.GetValues(values);

                    if (values[0].ToString() == string.Empty)
                    {
                        command = connection.CreateCommand();
                        command.CommandText = $"update Northwind.Orders set OrderDate = ({newDate.ToString("o")}) where OrderID = {orderID};";
                        connection.Open();
                        command.ExecuteNonQuery();

                        orderStatus = (OrderStatus)1;
                        Console.WriteLine($"Order satus : {orderStatus}");
                    }
                    else if (values[1].ToString() == string.Empty)
                    {
                        command = connection.CreateCommand();
                        command.CommandText = $"update Northwind.Orders set ShippedDate = ({newDate.ToString("o")}) where OrderID = {orderID};";
                        connection.Open();
                        command.ExecuteNonQuery();

                        orderStatus = (OrderStatus)2;
                        Console.WriteLine($"Order satus : {orderStatus}");
                    }

                    Console.WriteLine("\n");
                }
            }
        }

        [TestMethod]
        public void CallCustOrderHist(string custmerID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                const int ColumnsCount = 2;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "[Northwind].[CustOrderHist]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerID", custmerID);

                IDataReader reader = command.ExecuteReader();
                var values = new object[ColumnsCount];
                while (reader.Read())
                {
                    reader.GetValues(values);

                    foreach (var value in values)
                    {
                        Console.WriteLine(value);
                    }

                    Console.WriteLine("\n");
                }
            }
        }

        [TestMethod]
        public void CallCustOrderDetail(int orderID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                const int ColumnsCount = 2;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "[Northwind].[CustOrdersDetail]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderID", orderID);

                IDataReader reader = command.ExecuteReader();
                var values = new object[ColumnsCount];
                while (reader.Read())
                {
                    reader.GetValues(values);

                    foreach (var value in values)
                    {
                        Console.WriteLine(value);
                    }

                    Console.WriteLine("\n");
                }
            }
        }
    }
}
