using BobbleButt.BusinessLayer;
using BobbleButt.DataAccessLayer;
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
        protected int id;
        protected Product p=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Receive variable value from another page which is Products where products equals index of list products
            String productID = Request.QueryString["PassingValue"];
            int id = 0;
            try
            {
                id = Convert.ToInt32(productID);
            }
            catch { }
            p = QueryClass.GetProduct(id);

            //Change the information purchase product to equal the product at a certain index using 'product' variable
            productViewName.Text = p.Name;
            productViewPrice.Text = "Price: $"+p.Price.ToString("F");
            productViewDescription.Text = p.Description;
            productViewImage.ImageUrl = p.Image;
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {               
            List<Product> cart = new List<Product>();
            bool isCartNew = false;

            //gets the cart or sets a new one
            if (Session["cart"] == null)
            {
                isCartNew = true;
            }
            else { cart = (List<Product>)Session["cart"]; }

            if (isCartNew)
            {
                cart.Add(p);
                Session.Add("cart", cart);
            }
            else
            {
                int positionIndex = -1;
                //find said product in the cart
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
                //if found, only adds item if there is enought stock
                else if (p.Stock > cart[positionIndex].Quantity)
                {
                    cart[positionIndex].Quantity += 1;
                }
                Session["cart"] = cart;
            }
        }              
    }
}