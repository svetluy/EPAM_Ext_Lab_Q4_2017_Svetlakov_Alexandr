using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMW_13.Models
{
    public class AddOrderDetailsViewModel
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}