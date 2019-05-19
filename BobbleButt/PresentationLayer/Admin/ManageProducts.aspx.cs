using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected string mode;
        protected string product;

      
        protected void Page_Load(object sender, EventArgs e)
        {
                //Get value of mode and product from when button is clicked to determine which button is clicked            
                mode = Request.QueryString["mode"];
                product = Request.QueryString["product"];
                if (mode != null)
                {
                    if (mode.Equals("DeleteItem"))
                    {
                        //Delete an item depending on product which acts as index pointer
                        GlobalData.productList.RemoveAt(Convert.ToInt32(product));
                    }

                    if (mode.Equals("UpdateItem"))
                    {
                        //Open up update page sending the product value so the correct product can be determined
                        Response.Redirect("Update.aspx?PassingValue=" + Server.UrlEncode(product));

                    }
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
              Response.Redirect("ManageItems.aspx");   
        }

    }
}