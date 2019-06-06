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
                        productD.Price = Convert.ToDouble(reader["price"]);
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

        // get product data from the database
        public static List<Product> GetProductsIgnoreDelete()
        {
            List<Product> productData = new List<Product>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID";
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
                        productD.Price = Convert.ToDouble(reader["price"]);
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
        // update a product's data in the db
        public static void UpdateProduct(Product p)
        {
            List<Product> productData = new List<Product>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "UPDATE Product " +
                    "SET name = '"+p.Name+"', description = '"+p.Description+"', price = "+p.Price+", image = '"+p.Image+"', stock = "+p.Stock+"," +
                    "productCategoryID = (select productCategoryID FROM productcategory where name = '"+p.Category+"') " +
                    "WHERE productID = "+p.ID;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    connection.Close();
                }
            }
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
                        productD.Price = Convert.ToDouble(reader["price"]);
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
                        productD.Price = Convert.ToDouble(reader["price"]);
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
                    p.Price = Convert.ToDouble(reader["price"]);
                    p.Image = reader["image"].ToString();
                    p.ID = (int)reader["productID"];
                    p.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                    p.Quantity = 1;
                    connection.Close();
                }
            }
            return p;
        }

        // set a product to deleted
        public static void ToggleDeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT isDeleted FROM Product WHERE productID = " + id;
                int deleted = -1;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    deleted = Convert.ToInt32(reader["isDeleted"]);
                    connection.Close();
                }
                if(deleted==0)
                {
                    deleted = 1;
                }
                else if (deleted==1)
                {
                    deleted = 0;
                }

                sql = "UPDATE Product SET isDeleted = "+deleted+" WHERE productID = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
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
            List<int> orderNumbers = new List<int>();
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.streetAddress as oStreet, o.Suburb as oSuburb," +
                    "o.postcode as oPostcode, o.phone as oPhone " +
                    "FROM [Order] o " +
                    "JOIN [User] u ON o.userID = u.UserID " +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        orderNumbers.Add((int)reader["orderID"]);
                    }
                    connection.Close();
                    foreach (int i in orderNumbers)
                    {
                        orders.Add(QueryClass.GetOrder(i));
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
            List<int> orderNumbers = new List<int>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.streetAddress as oStreet, o.Suburb as oSuburb," +
                    "o.postcode as oPostcode, o.phone as oPhone " +
                    "FROM [Order] o " +
                    "JOIN [User] u ON o.userID = u.UserID " +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID " +
                    "WHERE u.email = '" + user + "'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        orderNumbers.Add((int)reader["orderID"]);
                    }
                    connection.Close();
                    foreach(int i in orderNumbers)
                    {
                        orders.Add(QueryClass.GetOrder(i));
                    }
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
                string sql = "SELECT orderID, email, firstName, lastName, po.postageOptionsID as postID, status, o.streetAddress as oStreet, o.Suburb as oSuburb," +
                    "o.postcode as oPostcode, o.phone as oPhone, o.date as oDate, o.status as oStatus " +
                    "FROM [Order] o " +
                    "JOIN [User] u ON o.userID = u.UserID " +
                    "JOIN PostageOptions po ON po.postageOptionsID = o.postageOptionsID where orderID = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    o.UserEmail = reader["email"].ToString();
                    o.FirstName = reader["firstName"].ToString();
                    o.LastName = reader["lastName"].ToString();
                    o.Phone = reader["oPhone"].ToString();
                    o.StreetAddress = reader["oStreet"].ToString();
                    o.Suburb = reader["oSuburb"].ToString();
                    o.Postcode = reader["oPostcode"].ToString();
                    o.Date = reader["oDate"].ToString();
                    o.Status = reader["oStatus"].ToString();
                    o.PostOption = (int)reader["postID"];
                    o.ID = (int)reader["orderID"];
                    reader.Close();
                    //GETTHEPRODUCTS TOO
                }

                List<Product> pList = new List<Product>();
                //get the list of all products in the order
                sql = "SELECT orderID, op.productID as opproductID, op.quantity as opQuantity, p.name as pname, pc.name as pcname,[stock],p.description as pDescription,[price],[image] " +
                    "FROM OrderProduct op JOIN Product p on p.productID = op.productID JOIN ProductCategory pc ON pc.productCategoryID = p.productCategoryID " +
                    "WHERE orderID = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {


                    SqlDataReader reader = command.ExecuteReader();

                    //Reads the products associated with the order and adds them into a list
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Quantity = (int)reader["opQuantity"];
                        p.Name = reader["pname"].ToString();
                        p.Category = reader["pcname"].ToString();
                        p.Description = reader["pDescription"].ToString();
                        p.Image = reader["image"].ToString();
                        p.Price = Convert.ToDouble(reader["price"].ToString());
                        p.ID = (int)reader["opproductID"];
                        pList.Add(p);
                    }
                }
                connection.Close();
                o.Products = pList;
            }
            return o;
        }

        // toggle whether the order is sent or processing
        public static void OrderToggleSent(int id)
        {
            String newStatus = "";

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT status " +
                    "FROM [Order] o " +
                    "where orderID = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //get the current status
                    reader.Read();
                    newStatus = reader["status"].ToString();
                    reader.Close();
                    
                }

                if(newStatus.Equals("Sent"))
                {
                    newStatus = "Processing";
                }
                else if(newStatus.Equals("Processing"))
                {
                    newStatus = "Sent";
                }


                sql = "UPDATE [Order] " +
                    "SET status = '" + newStatus + "' " +
                    "WHERE orderID = " + id;

                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();                    
                }
                connection.Close();
            }
        }
    }
}