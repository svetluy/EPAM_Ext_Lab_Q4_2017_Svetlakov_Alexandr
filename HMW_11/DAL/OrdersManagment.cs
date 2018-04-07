namespace DAL
{
    using DAL.DomainModels;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class OrdersManagment
    {
        private const string GetOrdersDBCommand = "select OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, " +
                                                    "ShippedDate, ShipVia,Freight, ShipName, ShipAddress,ShipCity," +
                                                    "ShipRegion, ShipPostalCode,ShipCountry from Northwind.Orders";

        private const string GetOrderInfoDBCommand = "select OrderID,OD.ProductID,OD.UnitPrice,Quantity,Discount,ProductName " +
                                                    "from Northwind.[Order Details] as OD inner join Northwind.Products as prod " +
                                                    "on OD.ProductID = prod.ProductID where OrderID = {0};";

        private const string CreateNewOrderDBInsertCommand = "insert into Northwind.Orders values ('{0}', {1},@OrderDate, @RequiueredDate," +
                                                                            " @ShippedDate, {2}, @Freight, '{3}', '{4}','{5}', '{6}', {7}, '{8}');";

        private const string CreateNewOrderDBSelectCommand = "select top 1 OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, " +
                                                            "ShippedDate, ShipVia,Freight, ShipName, ShipAddress,ShipCity,ShipRegion, " +
                                                            "ShipPostalCode,ShipCountry from Northwind.Orders order by OrderID desc";

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

        public List<Order> GetOrders(int? orderId = null)
        {
            var orders = new List<Order>();
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                if (!(orderId is null))
                {
                    command.CommandText = GetOrdersDBCommand + $" where OrderID = {orderId}";
                }
                else
                {
                    command.CommandText = GetOrdersDBCommand;
                }
                
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);

                    var order = new Order
                    {
                        OrderId = Convert.ToInt32(values[0]),
                        CustmerId = Convert.ToString(values[1]),
                        EmployeeId = values[2] as int?,
                        OrderDate = values[3] as DateTime?,
                        RequiueredDate = values[4] as DateTime?,
                        ShippedDate = values[5] as DateTime?,
                        ShipVia = values[6] as int?,
                        Freight = Convert.ToDouble(values[7]),
                        ShipName = Convert.ToString(values[8]),
                        ShipAdress = Convert.ToString(values[9]),
                        ShipCity = Convert.ToString(values[10]),
                        ShipRegion = Convert.ToString(values[11]),
                        ShipPostalCode = values[12] as int?,
                        ShipCountry = Convert.ToString(values[13])
                    };

                    if (order.ShippedDate is null)
                    {
                        order.OrderStatus = (OrderStatus)1;
                    }
                    else if (order.OrderDate is null)
                    {
                        order.OrderStatus = (OrderStatus)0;
                    }
                    else
                    {
                        order.OrderStatus = (OrderStatus)2;
                    }

                    orders.Add(order);
                }
            }

            return orders;
        }

        public OrderDetails GetOrderInfo(int orderID)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetOrderInfoDBCommand, orderID);

                connection.Open();
                IDataReader reader = command.ExecuteReader();
                var productsList = new List<Product>();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    var product = new Product
                    {
                        ProductId = Convert.ToInt32(values[1]),
                        UnitPrice = Convert.ToDouble(values[2]),
                        Quantity = Convert.ToInt32(values[3]),
                        Discount = Convert.ToDouble(values[4]),
                        ProductName = Convert.ToString(values[5])
                    };
                    productsList.Add(product);
                }
                OrderDetails order = new OrderDetails
                {
                    OrderId = orderID,
                    Products = productsList
                };
                return order;
            }
        }

        public string GetCustNameById(string custId)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.Parameters.Add(
                                        new SqlParameter()
                                        {
                                            ParameterName = "@CustomerID",
                                            DbType = DbType.String,
                                            Direction = ParameterDirection.Input,
                                            Value = custId
                                        });
                command.CommandText = "select ContactName from NorthWind.Customers where CustomerID = @CustomerID";
                connection.Open();
                var CustName = command.ExecuteScalar();
                return Convert.ToString(CustName);
            }
        }

        public void CreateNewOrder(Order order)
        {
            using (var connection = this.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@OrderDate",
                    DbType = DbType.DateTime,
                    Direction = ParameterDirection.Input,
                    Value = ((DateTime)order.OrderDate).ToString("o")
                });
                command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@RequiueredDate",
                            DbType = DbType.DateTime,
                            Direction = ParameterDirection.Input,
                            Value = ((DateTime)order.RequiueredDate).ToString("o")
                        });
                command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@ShippedDate",
                            DbType = DbType.DateTime,
                            Direction = ParameterDirection.Input,
                            Value = ((DateTime)order.ShippedDate).ToString("o")
                        });
                command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@Freight",
                            DbType = DbType.Double,
                            Direction = ParameterDirection.Input,
                            Value = order.Freight
                        });
                command.CommandText = string.Format(CreateNewOrderDBInsertCommand, order.CustmerId, order.EmployeeId, order.ShipVia, order.ShipName, order.ShipAdress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool SetOrderComplete(Order order, DateTime newDate)
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
                        Value = order.OrderId
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
                    order.ShippedDate = newDate;
                    order.OrderStatus = OrderStatus.Complete;
                    return true;
                }
                return false;
            }
        }

        public bool SetOrderInWork(Order order, DateTime newDate)
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
                        Value = order.OrderId
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
                    order.OrderDate = newDate;
                    order.OrderStatus = OrderStatus.InWork;
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

        public void AddOrderDetail(OrderDetails orderDetails)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@OrderID",
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    Value = orderDetails.OrderId
                });
                command.CommandText = "delete from Northwind.[Order Details] where OrderID = @OrderID";
                command.ExecuteNonQuery();

                foreach (var product in orderDetails.Products)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter()
                    {
                    ParameterName = "@OrderID",
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    Value = orderDetails.OrderId
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@ProductID",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        Value = product.ProductId
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@UnitPrice",
                        DbType = DbType.Decimal,
                        Direction = ParameterDirection.Input,
                        Value = product.UnitPrice
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Quantity",
                        DbType = DbType.Int16,
                        Direction = ParameterDirection.Input,
                        Value = product.Quantity
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Discount",
                        DbType = DbType.Double,
                        Direction = ParameterDirection.Input,
                        Value = product.Discount
                    }
                    });
                    command.CommandText = "insert into Northwind.[Order Details] values (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

