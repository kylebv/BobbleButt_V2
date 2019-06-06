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
                    "SET name = @name, description = @description, price = @price, image = @image, stock = @stock," +
                    "productCategoryID = (select productCategoryID FROM productcategory where name = @category) " +
                    "WHERE productID = " + p.ID;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", p.Name);
                    command.Parameters.AddWithValue("@description", p.Description);
                    command.Parameters.AddWithValue("@price", p.Price);
                    command.Parameters.AddWithValue("@image", p.Image);
                    command.Parameters.AddWithValue("@stock", p.Stock);
                    command.Parameters.AddWithValue("@category", p.Category);
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
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID where pc.name like '%'+@s+'%' and p.isDeleted = 0";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", s);
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
                string sql = "SELECT p.name as pname, pc.name as pcname,[stock],p.description,[price],[image],[productID], isDeleted FROM Product p JOIN ProductCategory pc ON p.productCategoryID=pc.productCategoryID where (pc.name like '%'+@s+'%'  " +
                    "or p.name like '%'+@s+'%' or p.description like '%'+@s+'%' ) and p.isDeleted = 0";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", s);
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
                if (deleted == 0)
                {
                    deleted = 1;
                }
                else if (deleted == 1)
                {
                    deleted = 0;
                }

                sql = "UPDATE Product SET isDeleted = " + deleted + " WHERE productID = " + id;
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
                    "WHERE u.email = @s";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", user);
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
                    o.PostOption.ID = (int)reader["postID"];
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
                    reader.Close();
                }

                //get the list of all products in the order
                o.PostOption = GetPostageOption(o.PostOption.ID);
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

                if (newStatus.Equals("Sent"))
                {
                    newStatus = "Processing";
                }
                else if (newStatus.Equals("Processing"))
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


        //checks user exists when logging in
        public static User GetUser(String email, String password)
        {
            User u = new User();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select userID, firstName, lastName, email, DOB, password, street, suburb, postcode, phone, isAdmin, isSuspended, isDeleted from [User] where email = @email AND password = @password";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    if (reader.HasRows)
                    {
                        reader.Read();
                        u.FirstName = reader["firstName"].ToString();
                        u.LastName = reader["lastName"].ToString();
                        u.Email = email;
                        u.Password = password;
                        u.DOB = reader["DOB"].ToString();
                        u.Street = reader["street"].ToString();
                        u.Suburb = reader["suburb"].ToString();
                        u.Postcode = reader["postcode"].ToString();
                        u.Phone = reader["phone"].ToString();
                        u.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                        u.IsSuspended = Convert.ToBoolean(reader["isSuspended"]);
                        u.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                        u.ID = (int)reader["userID"];
                    }
                    connection.Close();
                }
            }
            return u;
        }

        //retrieves user details
        public static User GetUser(String email)
        {
            User u = new User();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select userID, firstName, lastName, email, DOB, password, street, suburb, postcode, phone, isAdmin, isSuspended, isDeleted from [User] where email = @s";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", email);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    u.FirstName = reader["firstName"].ToString();
                    u.LastName = reader["lastName"].ToString();
                    u.Email = email;
                    u.Password = reader["password"].ToString();
                    u.DOB = reader["DOB"].ToString();
                    u.Street = reader["street"].ToString();
                    u.Suburb = reader["suburb"].ToString();
                    u.Postcode = reader["postcode"].ToString();
                    u.Phone = reader["phone"].ToString();
                    u.IsAdmin = Convert.ToBoolean(reader["isAdmin"]);
                    u.IsSuspended = Convert.ToBoolean(reader["isSuspended"]);
                    u.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                    u.ID = (int)reader["userID"];
                    connection.Close();
                }
            }
            return u;
        }

        //retrieves all user details
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            List<String> userEmails = new List<string>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select email from [User]";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        userEmails.Add(reader["email"].ToString());
                    }
                    reader.Close();
                }
            }
            foreach (String s in userEmails)
            {
                users.Add(GetUser(s));
            }
            return users;
        }

        //inserts a new user
        public static void AddUser(User u)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "INSERT INTO [User] (firstName, lastName, email, password, DOB, street, suburb, postcode, phone, isAdmin, isSuspended, isDeleted) " +
                    "VALUES (@firstname, @lastname, @email, @password, " +
                    "@dob, @street, @suburb, @postcode, @phone," +
                    " @isadmin, @issuspended,0 )";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@firstname", u.FirstName);
                    command.Parameters.AddWithValue("@lastname", u.LastName);
                    command.Parameters.AddWithValue("@email", u.Email);
                    command.Parameters.AddWithValue("@password", u.Password);
                    command.Parameters.AddWithValue("@dob", DateTime.Parse(u.DOB));
                    command.Parameters.AddWithValue("@street", u.Street);
                    command.Parameters.AddWithValue("@suburb", u.Suburb);
                    command.Parameters.AddWithValue("@postcode", u.Postcode);
                    command.Parameters.AddWithValue("@phone", u.Phone);
                    command.Parameters.AddWithValue("@isadmin", Convert.ToInt32(u.IsAdmin));
                    command.Parameters.AddWithValue("@issuspended", Convert.ToInt32(u.IsSuspended));
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

        //inserts a new user
        public static void AddProduct(Product p)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "INSERT INTO  Product (name, stock, description, price, image, isDeleted, productCategoryID) " +
                    "VALUES (@name, @stock, @description, @price, @image, @isdeleted, " +
                    "(select productCategoryID FROM productcategory where name = @category))";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", p.Name);
                    command.Parameters.AddWithValue("@stock", p.Stock);
                    command.Parameters.AddWithValue("@description", p.Description);
                    command.Parameters.AddWithValue("@price", p.Price);
                    command.Parameters.AddWithValue("@image", p.Image);
                    command.Parameters.AddWithValue("@isDeleted", p.IsDeleted);
                    command.Parameters.AddWithValue("@category", p.Category);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

        // set a user to deleted/undeleted
        public static void ToggleDeleteUser(String email)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT isDeleted FROM [User] WHERE email = @s";
                int deleted = -1;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", email);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    deleted = Convert.ToInt32(reader["isDeleted"]);
                    connection.Close();
                }
                if (deleted == 0)
                {
                    deleted = 1;
                }
                else if (deleted == 1)
                {
                    deleted = 0;
                }

                sql = "UPDATE [User] SET isDeleted = " + deleted + " WHERE email = '" + email + "'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        // set a user to suspended/unsuspended
        public static void ToggleSuspendUser(String email)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "SELECT isSuspended FROM [User] WHERE email = @s";
                int deleted = -1;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", email);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    reader.Read();
                    deleted = Convert.ToInt32(reader["isSuspended"]);
                    connection.Close();
                }
                if (deleted == 0)
                {
                    deleted = 1;
                }
                else if (deleted == 1)
                {
                    deleted = 0;
                }

                sql = "UPDATE [User] SET isSuspended = " + deleted + " WHERE email = '" + email + "'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        //retrieve list of postage types
        public static List<PostageOptions> GetPostageOptions()
        {
            List<PostageOptions> options = new List<PostageOptions>();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select postageOptionsID, name, price, estimatedDays, description " +
                    "FROM PostageOptions";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    //Reading data from the database and adding it to a list
                    while (reader.Read())
                    {
                        PostageOptions o = new PostageOptions();
                        o.ID = (int)reader["postageOptionsID"];
                        o.Name = reader["name"].ToString();
                        o.Price = Convert.ToDouble(reader["price"]);
                        o.ETA = (int)reader["estimatedDays"];
                        o.Description = reader["description"].ToString();
                        options.Add(o);
                    }
                    reader.Close();
                }
            }
            return options;
        }

        //retrieve list of postage types
        public static PostageOptions GetPostageOptionByName(String s)
        {
            PostageOptions o = new PostageOptions();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select postageOptionsID, name, price, estimatedDays, description, isDeleted " +
                    "FROM PostageOptions WHERE name = @s";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", s);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    o.ID = (int)reader["postageOptionsID"];
                    o.Name = reader["name"].ToString();
                    o.Price = Convert.ToDouble(reader["price"]);
                    o.ETA = (int)reader["estimatedDays"];
                    o.Description = reader["description"].ToString();
                    o.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                    reader.Close();
                }
            }
            return o;
        }
        //retrieve list of postage types
        public static PostageOptions GetPostageOption(int i)
        {
            PostageOptions o = new PostageOptions();

            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "select postageOptionsID, name, price, estimatedDays, description, isDeleted " +
                    "FROM PostageOptions WHERE postageOptionsID = @s";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@s", i);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    o.ID = (int)reader["postageOptionsID"];
                    o.Name = reader["name"].ToString();
                    o.Price = Convert.ToDouble(reader["price"]);
                    o.ETA = (int)reader["estimatedDays"];
                    o.Description = reader["description"].ToString();
                    o.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                    reader.Close();
                }
            }
            return o;
        }

        //update an existing postage type
        public static void UpdatePostageOption(PostageOptions o)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // Get all data about product with product category name
                string sql = "UPDATE PostageOptions" +
                    "SET name = @name, price = @price, estimatedDays = @estimatedDays, description = @description " +
                    "WHERE postageOptionsID = @poi";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@poi", o.ID);
                    command.Parameters.AddWithValue("@name", o.Name);
                    command.Parameters.AddWithValue("@price", o.Price);
                    command.Parameters.AddWithValue("@estimatedDays", o.ETA);
                    command.Parameters.AddWithValue("@description", o.Description);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

        //create a new postage type
        public static void AddPostageOption(PostageOptions o)
        {
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                string sql = "INSERT INTO PostageOptions (name, price, estimatedDays, description, isDeleted) " +
                    "VALUES (@name, @price, @estimatedDays, @description, 0)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", o.Name);
                    command.Parameters.AddWithValue("@price", o.Price);
                    command.Parameters.AddWithValue("@estimatedDays", o.ETA);
                    command.Parameters.AddWithValue("@description", o.Description);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }
    }
}