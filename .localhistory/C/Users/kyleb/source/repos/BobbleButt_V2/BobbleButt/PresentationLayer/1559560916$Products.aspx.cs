using BobbleButt.BusinessLayer;
using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Products : System.Web.UI.Page
    {
        protected string mode;
        protected string product;
        protected List<Product> products;
        protected void Page_Load(object sender, EventArgs e)
        {
            mode = Request.QueryString["mode"];
            product = Request.QueryString["product"];
            String category = Request.QueryString["category"];
            String search = Request.QueryString["search"];
            products = QueryClass.GetProductData();

            //directs to the page that displays a single product
            if (mode != null)
            {
                if (mode.Equals("PurchaseProductPage"))
                {
                    Response.Redirect("PurchaseProduct.aspx?PassingValue=" + Server.UrlEncode(product));
                }
            }

            //adds an item into the cart based on th addItem value
            if (Request.QueryString["addItem"] != null)
            {
                int productIndex = Convert.ToInt32(Request.QueryString["addItem"]);
                List<Product> cart = new List<Product>();
                bool isCartNew = false;

                //gets the cart or sets a new one
                if (Session["cart"] == null)
                {
                    isCartNew = true;
                }
                else { cart = (List<Product>)Session["cart"]; }

                Product p = products[productIndex];

                if (isCartNew)
                {
                    cart.Add(p);
                    Session.Add("cart", cart);
                }
                else
                {
                    int positionIndex = -1;
                    //find said product in the cart
                    for (int i = 0; i < cart.Count; i++)
                    {
                        if (cart[i].Name.Equals(p.Name))
                        {
                            positionIndex = i;
                        }
                    }
                    if (positionIndex == -1)
                    {
                        cart.Add(p);
                    }
                    //if found, only adds item if there is enought stock
                    else if(p.Stock>cart[positionIndex].Quantity)
                    {
                        cart[positionIndex].Quantity += 1;
                    }
                    Session["cart"] = cart;
                }
            }

            //finds products by category
            if(category!=null)
            {
                products = QueryClass.GetProductsByCategory(category);
            }

            //finds products by search
            if (search != null)
            {
                products = QueryClass.GetProductsBySearch(search);
            }
        }

    }
        
}