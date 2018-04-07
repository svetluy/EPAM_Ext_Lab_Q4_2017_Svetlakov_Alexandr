using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMW_13.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string Custmer { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public double OrderSum { get; set; }

    }
}