using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public class Order
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string CardNumber { get; set; }
        public string PaypalID { get; set; }

        public Order(string userEmail, string firstName, string lastName, string phone, string streetAddress, string suburb, string postcode, string cardNumber, string paypalID, List<Product> products, string status, string date)
        {
            UserEmail = userEmail;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            StreetAddress = streetAddress;
            Suburb = suburb;
            Postcode = postcode;
            CardNumber = cardNumber;
            PaypalID = paypalID;
            Products = products;
            Status = status;
            Date = date;
        }

        public List<Product> Products { get; set; }
        public string Status { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Status = "Processing";
        }

        public string Date { get; set; }
    }
}