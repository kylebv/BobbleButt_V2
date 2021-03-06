﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Checkout_Confirm : System.Web.UI.Page
    {
        protected Order order;
        protected List<Product> cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["order"] != null && Session["cart"] != null)
            {
                order = (Order)Session["order"];
                cart = (List<Product>)Session["cart"];
            }
            // If cart/order is empty redirect to checkout
            else
            {
                Response.Redirect("Checkout.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            order = (Order)Session["order"];
            GlobalData.Orders.Add(order);
            List<Product> temp = new List<Product>();
            foreach(Product p in order.Products)
            {
                foreach(Product p2 in GlobalData.productList)
                {
                    //Reduce stock based on quanity purchase
                    if(p2.Name.Equals(p.Name))
                    {
                        p2.Stock -= p.Quantity;
                    }
                }
            }
            foreach(Product p in GlobalData.productList)
            {
                if (p.Stock > 0)
                {
                    temp.Add(GlobalData.productList[GlobalData.productList.IndexOf(p)]);
                }
            }
            GlobalData.productList = temp;
            //Remove items from cart and redirect to success purchase home/main page
            Session.Remove("order");
            Session.Remove("cart");
            Response.Redirect("Main.aspx?orderEmail=" + order.UserEmail);
        }

    }
}