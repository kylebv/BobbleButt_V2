using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt.PresentationLayer
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Update label based on different errors
            if (Request.QueryString["handler"] == "404")
            {
                lblErrorMessage.Text = "The page that you searched for could not be found. Please Navigate back to an appropriate page.";
            }
            else if (Request.QueryString["handler"] == "503")
            {
                lblErrorMessage.Text = "Bobblehead service is unavaliable";
            }
            else
            {
                lblErrorMessage.Text = "An unknown error occured";
            }

        }
       
    }
}