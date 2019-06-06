﻿using System;
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
                string sql = "SELECT [Product.name] as productName,[ProductCategory.name] as categoryName,[stock],[description],[price],[image],[productID] FROM[Product].[dbo].[INFT3050A1] JOIN ProductCategory ON Product.productCategoryID=ProductCateogry.productCategoryID;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(); 

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        Product productD = new Product();
                        productD.Name = reader["productName"].ToString();
                        productD.Category = reader["categoryName"].ToString(); 
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