using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMW_13.Models
{
    public class CreateOrderModel
    {
        public int OrderId { get; set; }
        public string CustmerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiueredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAdress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public int? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}