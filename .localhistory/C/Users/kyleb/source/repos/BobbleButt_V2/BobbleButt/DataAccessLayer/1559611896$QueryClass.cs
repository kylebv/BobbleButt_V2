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
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID where p.isDeleted = 0";
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
                        productD.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                        productD.Quantity = 1;
                        productData.Add(productD);
                    }
                    connection.Close();
                }
            }
            return productData;
        }


        // get product data from the database searching by category
        public static List<Product> GetProductsByCategory(String s)
        {
            List<Product> productData = new List<Product>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID where pc.name like '" + s + "' and p.isDeleted = 0";
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
                        productD.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                        productD.Quantity = 1;
                        productData.Add(productD);
                    }
                    connection.Close();
                }
            }
            return productData;
        }

        // get product data from the database searching by title, description, or category
        public static List<Product> GetProductsBySearch(String s)
        {
            List<Product> productData = new List<Product>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID where (pc.name like '%" + s + "%' " +
                    "or p.name like '%" + s + "%' or p.description like '%" + "%') and p.isDeleted = 0";
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
                        productD.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                        productD.Quantity = 1;
                        productData.Add(productD);
                    }
                    connection.Close();
                }
            }
            return productData;
        }

        // get product data from the database searching by title, description, or category
        public static Product GetProduct(int id)
        {
            Product p = new Product();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p join productcategory pc on p.productcategoryid = pc.productcategoryid where productID = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    p.Name = reader["pname"].ToString();
                    p.Category = reader["pcname"].ToString();
                    p.Stock = (int)reader["stock"];
                    p.Description = reader["description"].ToString();
                    p.Price = Convert.ToInt64(reader["price"]);
                    p.Image = reader["image"].ToString();
                    p.ID = (int)reader["productID"];
                    p.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                    p.Quantity = 1;
                    connection.Close();
                }
            }
            return p;
        }

        // get the list of categories from the db
        public static List<String> GetCategories()
        {
            List<String> categories = new List<String>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT name FROM productcategory";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        categories.Add(reader["name"].ToString());
                    }
                    connection.Close();
                }
            }
            return categories;
        }

        // get orders list from the database
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.street as oStreet, o.Suburb as oSuburb," +
                    "o.state as oState, o.postcode as oPostcode, o.phone as oPhone" +
                    "FROM Order o " +
                    "JOIN User u ON o.userID = u.UserID" +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        Order o = new Order();
                        o.UserEmail = reader["username"].ToString();
                        o.FirstName = reader["firstName"].ToString();
                        o.LastName = reader["lastName"].ToString();
                        o.Phone = reader["oPhone"].ToString();
                        o.StreetAddress = reader["oStreet"].ToString();
                        o.Suburb = reader["oSuburb"].ToString();
                        o.Postcode = reader["oPostcode"].ToString();
                        o.PostOption = (int)reader["postID"];
                        o.ID = (int)reader["orderID"];
                        orders.Add(o);
                    }
                    connection.Close();
                }
            }
            return orders;
        }

        // gets a list of orders that are tied to a user email
        public static List<Order> GetOrdersByUser(String user)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.street as oStreet, o.Suburb as oSuburb," +
                    "o.state as oState, o.postcode as oPostcode, o.phone as oPhone" +
                    "FROM Order o " +
                    "JOIN User u ON o.userID = u.UserID" +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID " +
                    "WHERE u.email = '"+user+"'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        Order o = new Order();
                        o.UserEmail = reader["username"].ToString();
                        o.FirstName = reader["firstName"].ToString();
                        o.LastName = reader["lastName"].ToString();
                        o.Phone = reader["oPhone"].ToString();
                        o.StreetAddress = reader["oStreet"].ToString();
                        o.Suburb = reader["oSuburb"].ToString();
                        o.Postcode = reader["oPostcode"].ToString();
                        o.PostOption = (int)reader["postID"];
                        o.ID = (int)reader["orderID"];
                        orders.Add(o);
                    }
                    connection.Close();
                }
            }
            return orders;
        }

        // get order data from the database
        public static Order GetOrder(int id)
        {
            Order o = new Order();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.street as oStreet, o.Suburb as oSuburb," +
                    "o.state as oState, o.postcode as oPostcode, o.phone as oPhone" +
                    "FROM Order o " +
                    "JOIN User u ON o.userID = u.UserID" +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID where orderID = "+id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    o.UserEmail = reader["username"].ToString();
                    o.FirstName = reader["firstName"].ToString();
                    o.LastName = reader["lastName"].ToString();
                    o.Phone = reader["oPhone"].ToString();
                    o.StreetAddress = reader["oStreet"].ToString();
                    o.Suburb = reader["oSuburb"].ToString();
                    o.Postcode = reader["oPostcode"].ToString();
                    o.PostOption = (int)reader["postID"];
                    o.ID = (int)reader["orderID"];

                    //GETTHEPRODUCTS TOO
                }
                connection.Close();
            }
            return o;
        }
    }
}