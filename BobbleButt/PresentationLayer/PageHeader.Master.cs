﻿using BobbleButt.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class PageHeader : System.Web.UI.MasterPage
    {
        protected List<Product> cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents.Count == 0)
            {
                Session.Add("new session pls", "hooray");
                Response.Redirect("Main.aspx?sessionTimeout=true");
            }
            //Session.Add("cart", GlobalData.productList);
            cart = (List<Product>)Session["cart"];
            //Session.Add("user", GlobalData.userMap["adminuser@bobblebutt.com"]);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx?search=" + searchBar.Text);
        }
    }
}