using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BobbleButt.DataAccessLayer
{
    public class AdminViewProduct
    {
        private String m_connectionString; 

        public AdminViewProduct()
        {
            // grab connection string from web.config
            m_connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString; 
        }
        // get product data from the database
        public List<BusinessLayer.TestProduct> GetProductData()
        {
            List<BusinessLayer.TestProduct> productData = new List<BusinessLayer.TestProduct>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT [Product.name],[ProductCategory.name],[stock],[description],[price],[image],[productID] FROM[Product].[dbo].[INFT3050A1] JOIN ProductCategory ON Product.productCategoryID=ProductCateogry.productCategoryID;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(); 

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        BusinessLayer.TestProduct productD = new BusinessLayer.TestProduct();
                        productD.Name = reader["Product.name"].ToString();
                        productD.Category = reader["ProductCategory.name"].ToString(); 
                        productD.Stock = (int)reader["stock"];
                        productD.Description = reader["description"].ToString();
                        productD.Price = (double)reader["price"];
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