using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Login_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, System.EventArgs e)
        {
            string email = ((TextBox)FindControl("logEmail")).Text;
            string pword = ((TextBox)FindControl("logPassword")).Text;
     
            if (GlobalData.userMap.ContainsKey(email))
            {
                if(GlobalData.userMap[email].Password.Equals(pword))
                {
                    Session.Add("user", GlobalData.userMap[email]);
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    ((Label)FindControl("errorMessage")).Visible = true;
                }
            }
            else
            {
                ((Label)FindControl("errorMessage")).Visible = true;
            }
        }
    }
}