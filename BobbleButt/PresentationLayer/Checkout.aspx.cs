﻿using BobbleButt.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected List<Product> cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            cart = new List<Product>();
            string item = Request.QueryString["item"];
                string quantity = Request.QueryString["quantity"];


            if (Session["cart"]!=null)
            {
                cart = (List<Product>)Session["cart"];

            }
            if(Request.QueryString["delete"]!=null)
            {
                //Deleting a product from the checkout
                cart.RemoveAt(Convert.ToInt32(Request.QueryString["delete"]));
            }
            else if(Request.QueryString["item"] != null&& Request.QueryString["quantity"] != null)
            {
                if (cart[Convert.ToInt32(item)].Stock >= Convert.ToInt32(quantity) && Convert.ToInt32(quantity) > 0)
                {
                    cart[Convert.ToInt32(Request.QueryString["item"])].Quantity = Convert.ToInt32(Request.QueryString["quantity"]);
                }
                //If quantity is changed to 0 in checkout remove the product
                else if (Convert.ToInt32(quantity) == 0)
                {
                    cart.RemoveAt(Convert.ToInt32(item));
                }
            }
        }
    }
}