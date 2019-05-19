using System;
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
            else
            {
                Response.Redirect("Checkout.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            order = (Order)Session["order"];
            GlobalData.Orders.Add(order);
            Session.Remove("order");
            Session.Remove("cart");
            Response.Redirect("Main.aspx?orderEmail=" + order.UserEmail);
        }

    }
}