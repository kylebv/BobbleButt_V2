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
        protected List<Product> cart, cart2;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Add("cart", GlobalData.productList);
            //cart = (List<Product>)Session["cart"];
            //Session.Add("user", GlobalData.userList[1]);
        }
    }
}