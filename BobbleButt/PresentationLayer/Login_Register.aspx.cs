using BobbleButt.DataAccessLayer;
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
            User u = QueryClass.GetUser(email, pword);
            if (u.ID!=0)
            {
                //User logged in
                Session.Add("user", u);
                Response.Redirect("Main.aspx");
            }
            else
            {
                ((Label)FindControl("errorMessage")).Visible = true;
            }
        }
        protected void btnRegister_Click(object sender, System.EventArgs e)
        {
            if(IsValid)
            {
                string email = ((TextBox)FindControl("regEmail1")).Text;
                string pword = ((TextBox)FindControl("regPassword1")).Text;
                bool isAdmin = ((CheckBox)FindControl("chkAdmin")).Checked;
                //If email already exists make error message visible
                if (GlobalData.userMap.ContainsKey(email))
                {
                     ((Label)FindControl("errorMessage2")).Visible = true;   
                }
                // Create new user with informtaion provided
                else
                {
                    User temp = new User();
                    temp.Email = email;
                    temp.Password = pword;
                    temp.IsAdmin = isAdmin;
                    Session.Add("tempUser", temp);
                    Response.Redirect("Registration.aspx");
                }

            }
        }
    }
}