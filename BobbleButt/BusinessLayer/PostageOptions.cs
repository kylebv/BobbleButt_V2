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
        public int ID { get; set; }
        public String Description { get; set; }
        public int ETA { get; set; }
        public bool IsDeleted { get; set; }

        public PostageOptions(string name, double price, int iD, string description, int eTA, bool isDeleted)
        {
            Name = name;
            Price = price;
            ID = iD;
            Description = description;
            ETA = eTA;
            IsDeleted = isDeleted;
        }

        public PostageOptions()
        {
        }
    }
}