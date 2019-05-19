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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            List<Product> cart;
            bool isCartNew = false;
            if (Session["cart"]==null)
            {
                isCartNew = true;
                cart = new List<Product>();
            }
            else { cart = (List<Product>)Session["cart"]; }
            int itemIndex = Convert.ToInt32(((Button)sender).ID);
            Product p = GlobalData.productList[itemIndex];
            p.Quantity = 1;
            if (isCartNew)
            {
                cart.Add(p);
                Session.Add("cart",cart);
            }
            else
            {
                int positionIndex = -1;
                for(int i=0;i<cart.Count;i++)
                {
                    if(cart[i].Name.Equals(p.Name))
                    {
                        positionIndex = i;
                    }
                }
                if(positionIndex==-1)
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