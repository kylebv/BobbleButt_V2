using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user==null)
            {
                Response.Redirect("Login_Register.aspx");
            }
            firstName.Text = user.FirstName;
            lastName.Text = user.LastName;
            birthDate.Text = user.DOB;
            streetAddress.Text = user.Street;
            suburb.Text = user.Suburb;
            Postcode.Text = Convert.ToString(user.Postcode);
            phoneNumber.Text = "" + user.Phone;
        }
        protected void btnConfirm_Click(object sender, System.EventArgs e)
        {
            if (IsValid)
            {

                User user = (User)Session["user"];
                user.FirstName = ((TextBox)FindControl("firstName")).Text;
                user.LastName = ((TextBox)FindControl("lastName")).Text;
                user.Street = ((TextBox)FindControl("streetAddress")).Text;
                user.Suburb = ((TextBox)FindControl("suburb")).Text;
                user.Postcode = Convert.ToInt32(((TextBox)FindControl("postCode")).Text);
                user.DOB = ((TextBox)FindControl("birthDate")).Text;
                user.Phone = Convert.ToInt32(((TextBox)FindControl("firstName")).Text);
                GlobalData.userMap[user.Email] = user;
                Session["user"] = user;
                Response.Redirect("Main.aspx");

            }
            else
            {
                ((Label)FindControl("errorMessage")).Visible = true;
            }
        }
    }
}