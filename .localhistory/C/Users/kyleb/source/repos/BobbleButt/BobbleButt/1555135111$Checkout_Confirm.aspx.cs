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
            order = GlobalData.Orders[0];
            cart = GlobalData.productList;
        }
    }
}