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
            //this has to be done so that the page can have its data changed
            if (!IsPostBack)
            {
                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                birthDate.Text = Convert.ToDateTime(user.DOB).ToString("yyyy-MM-dd");
                streetAddress.Text = user.Street;
                suburb.Text = user.Suburb;
                Postcode.Text = Convert.ToString(user.Postcode);
                phoneNumber.Text = "" + user.Phone;
                valBirthDate.ValueToCompare = DateTime.Now.ToShortDateString();
            }
        }

        protected void btnConfirm_Click(object sender, System.EventArgs e)
        {
            //Update/Change user information on submit
            if (IsValid)
            {

                User user = (User)Session["user"];
                user.FirstName = firstName.Text;
                user.LastName = lastName.Text;
                user.Street = streetAddress.Text;
                user.Suburb = suburb.Text;
                user.Postcode = Postcode.Text;
                user.DOB = birthDate.Text;
                String s = firstName.Text;
                user.Phone = phoneNumber.Text;
                QueryClass.UpdateUser(user);
                Session["user"] = user;
                Response.Redirect("Main.aspx");

            }

            // Error message displayed if fields are not correctly filled
            else
            {
                errorMessage.Visible = true;
            }
        }
    }
}