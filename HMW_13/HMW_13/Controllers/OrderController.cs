using DAL;
using DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMW_13.Controllers
{
    public class OrderController : Controller
    {
        OrdersManagment ordersManagment = new OrdersManagment();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            ViewBag.Message = "Orders list";
            var ordersList = ordersManagment.GetOrders();
            var orderViewModelList = new List<Models.OrderViewModel>();

            foreach (var order in ordersList)
            {
                var orderDetail = ordersManagment.GetOrderInfo(order.OrderId);
                double sum = 0;
                foreach (var product in orderDetail.Products)
                {
                    sum += Math.Round(product.UnitPrice * product.Quantity * (1 - product.Discount), 2);
                }
                var contactName = ordersManagment.GetCustNameById(order.CustmerId);
                var model = new Models.OrderViewModel
                {
                    OrderId = order.OrderId,
                    Custmer = contactName,
                    OrderStatus = order.OrderStatus,
                    OrderDate = order.OrderDate,
                    OrderSum = sum
                };
                orderViewModelList.Add(model);
            }
            ViewBag.ModelsList = orderViewModelList;
            return View();
        }

        public ActionResult OrderDetails(int orderId)
        {
            var orderDetails = ordersManagment.GetOrderInfo(orderId);
            ViewBag.OrderId = Request.Params["OrderId"];
            ViewBag.Custmer = Request.Params["Custmer"];
            ViewBag.OrderStatus = Request.Params["OrderStatus"];
            ViewBag.OrderDate = Request.Params["OrderDate"];
            ViewBag.OrderSum = Request.Params["OrderSum"];
            ViewBag.ProductsList = orderDetails.Products;
            return View();
        }

        public ActionResult AddOrderDetails(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        public ActionResult AddOrderDetails(int orderId, FormCollection collection)
        {
            var orderDetails = ordersManagment.GetOrderInfo(orderId);
            orderDetails.Products.Add(new Product
            {
                ProductId = int.Parse(Request.Params["ProductId"]),
                UnitPrice = double.Parse(Request.Params["UnitPrice"]),
                Quantity = int.Parse(Request.Params["Quantity"]),
                Discount = double.Parse(Request.Params["Discount"])
            });
            ordersManagment.AddOrderDetail(orderDetails);
            return RedirectToAction("AddOrderDetails");
        }

        
        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var values = collection.AllKeys;
            var order = new Order
            {
                CustmerId = Request.Params[values[1]],
                EmployeeId = int.Parse(Request.Params[values[2]]),
                OrderDate = DateTime.Parse(Request.Params[values[3]]),
                RequiueredDate = DateTime.Parse(Request.Params[values[4]]),
                ShippedDate = DateTime.Parse(Request.Params[values[5]]),
                ShipVia = int.Parse(Request.Params[values[6]]),
                Freight = double.Parse(Request.Params[values[7]]),
                ShipName = Request.Params[values[8]],
                ShipAdress = Request.Params[values[9]],
                ShipCity = Request.Params[values[10]],
                ShipRegion = Request.Params[values[11]],
                ShipPostalCode = int.Parse(Request.Params[values[12]]),
                ShipCountry = Request.Params[values[13]]
            };
            return RedirectToAction("Create");
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
