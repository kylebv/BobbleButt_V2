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
            
            if(Session["cart"]!=null)
            {
                cart = (List<Product>)Session["cart"];

            }
            if(Request.QueryString["delete"]!=null)
            {
                cart.RemoveAt(Convert.ToInt32(Request.QueryString["delete"]));
            }
            else if(Request.QueryString["item"] != null&& Request.QueryString["quantity"] != null)
            {
                cart[Convert.ToInt32(Request.QueryString["item"])].Quantity = Convert.ToInt32(Request.QueryString["quantity"]);
            }
        }
    }
}