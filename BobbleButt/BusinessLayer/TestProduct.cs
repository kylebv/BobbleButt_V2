using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BobbleButt.BusinessLayer
{
    public class TestProduct
    {
        //Represents Product data the admin can view
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int ID { get; set; }

        //Data access
        //static DataAccessLayer.AdminViewProduct m_db;

        
        public TestProduct()
        {
           // m_db = new DataAccessLayer.AdminViewProduct();
        }
        //public static List<TestProduct> GetProducts()
        //{
        //    return m_db.GetProductData();
        //}

    }
}