using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public class Order
    {
        public string UserEmail { get; set; }
        public List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }

        public Order(string userEmail, List<Product> products, string date)
        {
            UserEmail = userEmail;
            Products = products;
            Date = date;
        }
        public string Date { get; set; }
    }
}