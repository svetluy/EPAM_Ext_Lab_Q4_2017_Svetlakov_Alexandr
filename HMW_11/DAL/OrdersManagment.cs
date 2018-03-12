namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    
    public class OrdersManagment
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

        public List<object> GetOrders()
        {
            const int ColumnsCount = 15;
            var orders = new List<object>();
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Northwind.Orders";

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                OrderStatus orderStatus;
                var values = new object[ColumnsCount + 1];
                while (reader.Read())
                {
                    reader.GetValues(values);

                    if (values[5].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)1;
                        values[ColumnsCount] = orderStatus;
                    }
                    else if (values[3].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)0;
                        values[ColumnsCount] = orderStatus;
                    }
                    else
                    {
                        orderStatus = (OrderStatus)2;
                        values[ColumnsCount] = orderStatus;
                    }

                    orders.Add(values);
                }
            }

            return orders;
        }


        public object[] GetOrderInfo(int orderID)
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
                }
                return values;
            }
        }

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

        public void ChangeOrderStatus(int orderID, DateTime newDate)
        {
            const int ColumnsCount = 2;
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT OrderDate,ShippedDate FROM Northwind.Orders where OrderID = {orderID}";

                connection.Open();
                IDataReader reader = command.ExecuteReader();
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
                    }
                    else if (values[1].ToString() == string.Empty)
                    {
                        command = connection.CreateCommand();
                        command.CommandText = $"update Northwind.Orders set ShippedDate = ({newDate.ToString("o")}) where OrderID = {orderID};";
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        public object[] CallCustOrderHist(string custmerID)
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
                }
                return values;
            }
        }


        public object[] CallCustOrderDetail(int orderID)
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
                }
                return values;
            }
        }
    }
}

