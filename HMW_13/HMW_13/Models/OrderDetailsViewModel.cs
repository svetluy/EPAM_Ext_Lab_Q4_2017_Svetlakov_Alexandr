using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMW_13.Models
{
    public class OrderDetailsViewModel
    {
        public OrderViewModel Order { get; set; }
        public DAL.OrderDetails OrderInfo { get; set; }
    }
}