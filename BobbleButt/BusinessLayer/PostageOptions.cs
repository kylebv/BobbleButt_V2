using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public class PostageOptions
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public PostageOptions(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public PostageOptions()
        {
        }
    }
}