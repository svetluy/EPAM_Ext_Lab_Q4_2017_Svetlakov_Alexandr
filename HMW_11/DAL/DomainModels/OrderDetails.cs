using DAL.DomainModels;
using System.Collections.Generic;

namespace DAL
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            string result =  $"{OrderId} ";
            foreach (var product in Products)
            {
                result += $"\n{product}";
            }
            return result;
        }
    }        
}