using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Registration : System.Web.UI.Page
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            valBirthDate.ValueToCompare = DateTime.Now.ToString("dd/MM/yyyy");
            birthDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (Session["tempUser"]==null)
            {
                Response.Redirect("Login_Register.aspx");
            }
            

        }
        protected void btnRegister_Click(object sender, System.EventArgs e)
        {

            if (IsValid)
            {

                user = (User)Session["tempUser"];
                Session.Remove("tempUser");
                user.FirstName = ((TextBox)FindControl("firstName")).Text;
                user.LastName = ((TextBox)FindControl("lastName")).Text;
                user.Street = ((TextBox)FindControl("streetAddress")).Text;
                user.Suburb = ((TextBox)FindControl("suburb")).Text;
                user.Postcode = ((TextBox)FindControl("postCode")).Text;
                user.DOB = ((TextBox)FindControl("birthDate")).Text;
                user.Phone = ((TextBox)FindControl("firstName")).Text;
                GlobalData.userMap.Add(user.Email, user);
                Session.Add("user", user);
                Response.Redirect("Main.aspx");
                
            }

        }
    }
}