using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using BobbleButt.BusinessLayer;

namespace BobbleButt.DataAccessLayer
{
    public class QueryClass
    {
        private static String m_connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        // get product data from the database
        public static List<Product> GetProductData()
        {
            List<Product> productData = new List<Product>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID] FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(); 

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        Product productD = new Product();
                        productD.Name = reader["pname"].ToString();
                        productD.Category = reader["pcname"].ToString(); 
                        productD.Stock = (int)reader["stock"];
                        productD.Description = reader["description"].ToString();
                        productD.Price = Convert.ToInt64(reader["price"]);
                        productD.Image = reader["image"].ToString();
                        productD.ID = (int)reader["productID"];
                        productData.Add(productD);
                    }
                }
            }
            return productData;
        }

    }
}