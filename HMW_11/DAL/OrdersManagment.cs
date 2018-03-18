namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class OrdersManagment
    {
        private const string GetOrdersDBCommand = "select OrderID, " +
                                                    "CustomerID, " +
                                                    "EmployeeID, " +
                                                    "OrderDate, " +
                                                    "RequiredDate, " +
                                                    "ShippedDate, " +
                                                    "ShipVia,Freight, " +
                                                    "ShipName, " +
                                                    "ShipAddress," +
                                                    "ShipCity," +
                                                    "ShipRegion, " +
                                                    "ShipPostalCode," +
                                                    "ShipCountry " +
                                                    "from Northwind.Orders;";

        private const string GetOrderInfoDBCommand = "select OrderID," +
                                                    "OD.ProductID," +
                                                    "OD.UnitPrice," +
                                                    "Quantity," +
                                                    "Discount," +
                                                    "ProductName " +
                                                    "from Northwind.[Order Details] as OD " +
                                                    "inner join Northwind.Products as prod " +
                                                    "on OD.ProductID = prod.ProductID " +
                                                    "where OrderID = {0};";

        private const string CreateNewOrderDBInsertCommand = "insert into Northwind.Orders values ('{0}', {1},@OrderDate, @RequiueredDate," +
                                                                            " @ShippedDate, {2}, @Freight, '{3}', '{4}'," +
                                                                               "'{5}', '{6}', {7}, '{8}');";

        private const string CreateNewOrderDBSelectCommand = "select top 1 OrderID, " +
                                                            "CustomerID, " +
                                                            "EmployeeID, " +
                                                            "OrderDate, " +
                                                            "RequiredDate, " +
                                                            "ShippedDate, " +
                                                            "ShipVia,Freight, " +
                                                            "ShipName, " +
                                                            "ShipAddress," +
                                                            "ShipCity," +
                                                            "ShipRegion, " +
                                                            "ShipPostalCode," +
                                                            "ShipCountry " +
                                                            "from Northwind.Orders " +
                                                            "order by OrderID desc";

        private const string SetOrderCompleteDBSelectCommand = "SELECT ShippedDate FROM Northwind.Orders where OrderID = @OrderID";

        private const string SetOrderCompleteDBUpdateCommand = "update Northwind.Orders set ShippedDate = @Date where OrderID = @OrderID;";

        private const string SetOrderInWorkDBSelectCommand = "SELECT OrderDate FROM Northwind.Orders where OrderID = @OrderID";

        private const string SetOrderInWorkDBUpdateCommand = "update Northwind.Orders set OrderDate = @Date where OrderID = @OrderID";

        private DbConnection CreateConnection()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["NorthwindConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public List<object> GetOrders()
        {
            var orders = new List<object>();
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = GetOrdersDBCommand;

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                OrderStatus orderStatus;
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);

                    if (values[5].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)1;
                        values[reader.FieldCount - 1] = orderStatus;
                    }
                    else if (values[3].ToString() == string.Empty)
                    {
                        orderStatus = (OrderStatus)0;
                        values[reader.FieldCount - 1] = orderStatus;
                    }
                    else
                    {
                        orderStatus = (OrderStatus)2;
                        values[reader.FieldCount - 1] = orderStatus;
                    }

                    orders.Add(values);
                }
            }

            return orders;
        }

        public List<object> GetOrderInfo(int orderID)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetOrderInfoDBCommand,orderID);

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                var orders = new List<object>();

                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    orders.Add(values);
                }
                return orders;
            }
        }

        public object[] CreateNewOrder(
                                   string custmerID,
                                   int employeeID,
                                   DateTime orderDate,
                                   DateTime requiueredDate,
                                   DateTime shippedDate,
                                   int shipVia,
                                   double freight,
                                   string shipName,
                                   string shipAdress,
                                   string shipCity,
                                   string shipRegion,
                                   int shipPostalCode,
                                   string shipCountry)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.Parameters.Add(
                        new SqlParameter()
                    {
                        ParameterName = "@OrderDate",
                        DbType = DbType.DateTime,
                        Direction = ParameterDirection.Input,
                        Value = orderDate.ToString("o")
                    });
                command.Parameters.Add(
                        new SqlParameter()
                        {
                            ParameterName = "@RequiueredDate",
                            DbType = DbType.DateTime,
                            Direction = ParameterDirection.Input,
                            Value = requiueredDate.ToString("o")
                        });
                command.Parameters.Add(
                        new SqlParameter()
                        {
                            ParameterName = "@ShippedDate",
                            DbType = DbType.DateTime,
                            Direction = ParameterDirection.Input,
                            Value = requiueredDate.ToString("o")
                        });
                command.Parameters.Add(
                        new SqlParameter()
                        {
                            ParameterName = "@Freight",
                            DbType = DbType.Double,
                            Direction = ParameterDirection.Input,
                            Value = freight
                        });
                command.CommandText = string.Format(CreateNewOrderDBInsertCommand,custmerID,employeeID,shipVia,shipName,shipAdress,shipCity,shipRegion,shipPostalCode,shipCountry);

                connection.Open();
                command.ExecuteNonQuery();

                command.CommandText = CreateNewOrderDBSelectCommand;
                IDataReader reader = command.ExecuteReader();
                var values = new object[reader.FieldCount];
                while (reader.Read())
                {
                    reader.GetValues(values);
                }
                return values;
            }
        }


        public bool SetOrderComplete(int orderID, DateTime newDate)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@OrderID",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        Value = orderID
                    });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Date",
                    DbType = DbType.DateTime,
                    Direction = ParameterDirection.Input,
                    Value = newDate.ToString("o")
                });
                command.CommandText = SetOrderCompleteDBSelectCommand;

                connection.Open();
                var dbDate = command.ExecuteScalar();

                if (dbDate is DBNull)
                {
                    command.CommandText = SetOrderCompleteDBUpdateCommand;
                    command.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
        }

        public bool SetOrderInWork(int orderID, DateTime newDate)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@OrderID",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        Value = orderID
                    });

                command.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@Date",
                        DbType = DbType.DateTime,
                        Direction = ParameterDirection.Input,
                        Value = newDate.ToString("o")
                    });
                command.CommandText = SetOrderInWorkDBSelectCommand;

                connection.Open();
                var dbDate = command.ExecuteScalar();

                if (dbDate is DBNull)
                {
                    command.CommandText = SetOrderInWorkDBUpdateCommand;
                    command.ExecuteNonQuery();
                    return true;
                }

                return false;
            }
        }

        public List<object> CallCustOrderHist(string customerID)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "[Northwind].[CustOrderHist]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@CustomerID",
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        Value = customerID
                    });
                
                IDataReader reader = command.ExecuteReader();
                var custHist = new List<object>();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    custHist.Add(values);
                }
                return custHist;
            }
        }

        public List<object> CallCustOrderDetail(int orderID)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "[Northwind].[CustOrdersDetail]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@OrderID",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        Value = orderID
                    });
                IDataReader reader = command.ExecuteReader();
                var orderDetail = new List<object>();
                
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    orderDetail.Add(values);
                }
                return orderDetail;
            }
        }
    }
}

