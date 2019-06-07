using BobbleButt.DataAccessLayer;
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
            //Place current user session information into textboxes 
            User user = (User)Session["user"];
            if (user==null)
            {
                Response.Redirect("Login_Register.aspx");
            }
            firstName.Text = user.FirstName;
            lastName.Text = user.LastName;
            birthDate.Text = user.DOB.ToString();
            streetAddress.Text = user.Street;
            suburb.Text = user.Suburb;
            Postcode.Text = Convert.ToString(user.Postcode);
            phoneNumber.Text = "" + user.Phone;
            valBirthDate.ValueToCompare = DateTime.Now.ToString();
        }

        protected void btnConfirm_Click(object sender, System.EventArgs e)
        {
            //Update/Change user information on submit
            if (IsValid)
            {

                User user = (User)Session["user"];
                user.FirstName = ((TextBox)FindControl("firstName")).Text;
                user.LastName = ((TextBox)FindControl("lastName")).Text;
                user.Street = ((TextBox)FindControl("streetAddress")).Text;
                user.Suburb = ((TextBox)FindControl("suburb")).Text;
                user.Postcode = ((TextBox)FindControl("postCode")).Text;
                user.DOB = ((TextBox)FindControl("birthDate")).Text;
                user.Phone = ((TextBox)FindControl("firstName")).Text;
                QueryClass.UpdateUser(user);
                Session["user"] = user;
                Response.Redirect("Main.aspx");

            }

            // Error message displayed if fields are not correctly filled
            else
            {
                ((Label)FindControl("errorMessage")).Visible = true;
            }
        }
    }
}