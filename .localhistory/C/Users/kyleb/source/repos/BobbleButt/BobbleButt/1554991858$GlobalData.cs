using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobbleButt
{
    public static class GlobalData
    {

        public static List<Product> productList
        { get; set; }
        public static Dictionary<string, User> userMap
        { get; set; }
        static GlobalData() { productList = new List<Product>();
            productList.Add(new Product("DC", "Batman Bobbly Head", 10, "Popular male Character from the DC universe who wears a bat costume fighting and solving crime", 30, "img/batman.png", 1));
            productList.Add(new Product("Marvel", "Doctor Strange Bobbly Head", 3, "Popular Character from the Marvel universe who wears a red cape fighting villians and protecting the world using magic as his weapon", 35, "img/doctorStrange.png", 1));
            productList.Add(new Product("DC", "Batwoman Bobbly Head", 10, "Popular Character female from the Marvel universe who wears a bat costume fighting and solving crime", 30, "img/batwoman.png", 1));
            productList.Add(new Product("Marvel", "Black Widow Bobbly Head", 15, "Popular Character from the DC universe who has no super powers but is an agent and spy", 35, "img/blackWidow.png", 1));
            userMap = new Dictionary<string, User>();
            userMap.Add("basicuser@bu.com",new User("Basic", "User", "basicuser@bu.com", "10/10/10", "password", "123 Fake St", "Springfield", 2251, 0400000000, false));
            userMap.Add("adminuser@bobblebutt.com", new User("Admin", "User", "adminuser@bobblebutt.com", "01/01/01", "password", "321 Fake St", "Springfield", 2251, 0499999999, true));
           
        }
    }
}