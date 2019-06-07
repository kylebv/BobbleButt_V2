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
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected string mode;
        protected string product;
        protected List<Product> products;

      
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get value of mode and product from when button is clicked to determine which button is clicked            
            mode = Request.QueryString["mode"];
            product = Request.QueryString["product"];
            products = QueryClass.GetProductsIgnoreDelete();
            int productID = 0;
            try
            {
                productID = Convert.ToInt32(product);
            }
            catch { }
            if (mode != null && product != null)
            {
                if (mode.Equals("toggleDelete"))
                {
                    //Delete an item depending on product which acts as index pointer

                    //query for deleting
                    QueryClass.ToggleDeleteProduct(productID);
                    products = QueryClass.GetProductsIgnoreDelete();
                }

                //if (mode.Equals("UpdateItem"))
                //{
                //    //Open up update page sending the product value so the correct product can be determined
                //    Response.Redirect("Update.aspx?PassingValue=" + Server.UrlEncode(product));

                //}
            }
            
        }
        protected void viewDeleteBtn_Clicked(object sender, System.EventArgs e)
        {
        }
        protected void viewUpdateBtn_Clicked(object sender, System.EventArgs e)
        {   
        }
        protected void viewAddNewBtn_Clicked(object sender, System.EventArgs e)
        {
              Response.Redirect("ManageItems");   
        }

    }
}