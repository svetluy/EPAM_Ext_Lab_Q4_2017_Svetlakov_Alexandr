using System;
using DAL;
using NUnit.Framework;

namespace DALUnitTestProject
{
    [TestFixture]
    public class DALTest
    {
        OrdersManagment dal = new OrdersManagment();

        [Test]
        public void TestGetOrders()
        {
            var result = dal.GetOrders();
            foreach (object[] item in result)
            {
                foreach (var value in item)
                {
                    if (value.ToString() == string.Empty)
                    {
                        Console.WriteLine("Not set");
                    }
                    else
                    {
                        Console.WriteLine(value);
                    }
                }
                Console.WriteLine();
            }
        }

        [Test]
        [TestCase(10248)]
        public void TestGetOrderInfo(int value)
        {
            var result = dal.GetOrderInfo(value);
            foreach (object[] item in result)
            {
                foreach (var prop in item)
                {
                    if (value.ToString() == string.Empty)
                    {
                        Console.WriteLine("Not set");
                    }
                    else
                    {
                        Console.WriteLine(prop);
                    }
                }
                Console.WriteLine();
            }
        }

        [Test]
        [TestCase(11008, "2018-03-16T00:00:00")]
        public void SetComplete(int orderID, string date)
        {
            var actual = dal.SetOrderComplete(orderID, DateTime.Parse(date));

            if (actual)
            {
                Console.WriteLine("Date set");
            }
            else
            {
                Console.WriteLine("Date already set");
            }
        }

        [Test]
        [TestCase(11008, "2018-03-16T00:00:00")]
        public void SetInwork(int orderID, string date)
        {
            var actual = dal.SetOrderInWork(orderID, DateTime.Parse(date));
            if (actual)
            {
                Console.WriteLine("Date set");
            }
            else
            {
                Console.WriteLine("Date already set");
            }
        }


        [Test]
        [TestCase("OLDWO")]
        public void CallCustOrderHist(string custmerID)
        {
            var result = dal.CallCustOrderHist(custmerID);
            foreach (object[] item in result)
            {
                foreach (var value in item)
                {
                    Console.WriteLine(value);
                }

                Console.WriteLine();
            }
        }

        [Test]
        [TestCase(10248)]
        public void CallCustOrderDetail(int orderID)
        {
            var result = dal.CallCustOrderDetail(orderID);
            foreach (object[] item in result)
            {
                foreach (var value in item)
                {
                    Console.WriteLine(value);
                }

                Console.WriteLine();
            }
        }

        [Test]
        [TestCase("OLDWO",5,"1996-07-04 00:00:00.000", "1996-08-01 00:00:00.000","1996 - 07 - 16 00:00:00.000",3,32.38, "Vins et alcools Chevalier", "59 rue de lAbbaye", "Reims", "FR",51100,"France")]
        public void CreateOrderTest(
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
            var result = dal.CreateNewOrder(custmerID,employeeID, DateTime.Parse(orderDate), DateTime.Parse(requiueredDate), DateTime.Parse(shippedDate),shipVia,freight,shipName,shipAdress,shipCity,shipRegion,shipPostalCode,shipCountry);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
