using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public class Product:ICloneable
    {
        public Product()
        {
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Product(string category, string name, int stock, string description, double price, string image, int quantity)
        {
            Name = name;
            Description = description;
            Image = image;
            Quantity = quantity;
            Price = price;
            Category = category;
            Stock = stock;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Category {get; set;}
        public int Stock { get; set; }
    }
}