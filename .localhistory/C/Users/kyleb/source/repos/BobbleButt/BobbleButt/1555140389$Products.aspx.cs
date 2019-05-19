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
        protected void Page_Load(object sender, EventArgs e)
        {
            mode = Request.QueryString["mode"];
            product = Request.QueryString["product"];

            if (mode != null)
            {
                if (mode.Equals("PurchaseProductPage"))
                {
                    Response.Redirect("PurchaseProduct.aspx?PassingValue=" + Server.UrlEncode(product));
                }
            }
            if (Request.QueryString["addItem"] != null)
            {
                int productIndex = Convert.ToInt32(Request.QueryString["addItem"]);
                List<Product> cart = new List<Product>();
                bool isCartNew = false;
                if (Session["cart"] == null)
                {
                    isCartNew = true;
                }
                else { cart = (List<Product>)Session["cart"]; }
                Product p = GlobalData.productList[productIndex];
                p.Quantity = 1;
                if (isCartNew)
                {
                    cart.Add(p);
                    Session.Add("cart", cart);
                }
                else
                {
                    int positionIndex = -1;
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
                    else
                    {
                        cart[positionIndex].Quantity += 1;
                    }
                    Session["cart"] = cart;
                }
            }

        }

    }
        
}