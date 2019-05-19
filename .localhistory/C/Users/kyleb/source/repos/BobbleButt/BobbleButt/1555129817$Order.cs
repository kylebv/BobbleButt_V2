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
        public string Status { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Status = "Processing";
        }

        public Order(string userEmail, List<Product> products, string date, string status)
        {
            UserEmail = userEmail;
            Products = products;
            Date = date;
            Status = status;
        }
        public string Date { get; set; }
    }
}