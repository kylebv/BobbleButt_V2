using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public class User
    {
        public User()
        {
        }

        public User(string firstName, string lastName, string email, string dOB, string password, string street, string suburb, string postcode, string phone, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DOB = dOB;
            Password = password;
            Street = street;
            Suburb = suburb;
            Postcode = postcode;
            Phone = phone;
            IsAdmin = isAdmin;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

    }
}