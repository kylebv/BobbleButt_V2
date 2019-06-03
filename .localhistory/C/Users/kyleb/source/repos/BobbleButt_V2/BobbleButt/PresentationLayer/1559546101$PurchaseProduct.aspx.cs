using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class PurchaseProduct : System.Web.UI.Page
    {
        string product;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Receive variable value from another page which is Products where products equals index of list products
            product = Request.QueryString["PassingValue"];
            //Change the information purchase product to equal the product at a certain index using 'product' variable
            productViewName.Text = GlobalData.productList[Convert.ToInt32(product)].Name;
            productViewPrice.Text = "Price: $"+Convert.ToString(GlobalData.productList[Convert.ToInt32(product)].Price);
            productViewDescription.Text = GlobalData.productList[Convert.ToInt32(product)].Description;
            productViewImage.ImageUrl = GlobalData.productList[Convert.ToInt32(product)].Image;
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            //Checks to see if product which will be the number to get an item from a list is not null
            if (product != null)
            {
                int productIndex = Convert.ToInt32(product);
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
            Response.Redirect("PurchaseProduct.aspx?PassingValue=" + product);

        }
    }
}