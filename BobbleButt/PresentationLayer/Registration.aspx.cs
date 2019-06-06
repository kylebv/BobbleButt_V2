using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace BobbleButt
{
    public partial class Registration : System.Web.UI.Page
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["tempUser"]==null)
            {
                //Response.Redirect("Login_Register.aspx");
            }
            

        }
        private string ConfirmAdminMessage(bool isHtml, string adminEmail, string firstName, string lastName)
        {
            //Content if html is available 
            if (isHtml)
                return "<html><head><title>Admin Confirmation"
                        + " </title></head>"
                        + "<body><img src=cid:logoImage>" + "<br />"
                        + "<h3> Please confirm you are an admin in this email </h3>"
                        + "<p>Please click the button to confirm you are an admin "
                        + "<strong>" + firstName + " " + lastName + "</strong> associated with this email: <strong>" + adminEmail + "</strong></p></body></html>"
                        +"<button type = 'button'> Confirm</button>";
            //Text if html is not
            else
                return "Please confirm you are an admin in this email \r\n"
                        + "Please click the button to confirm you are an admin "
                        + firstName + " " + lastName + "associated with this email: " + adminEmail + ".";
        }

        protected void btnRegister_Click(object sender, System.EventArgs e)
        {
            //Add user into list and log them in
            if (IsValid)
            {
                user = (User)Session["tempUser"];
                Session.Remove("tempUser");
                //If user ticked register as admin box a confirmation email will be sent
                if (user.IsAdmin)
                {
                    user.FirstName = ((TextBox)FindControl("firstName")).Text;
                    user.LastName = ((TextBox)FindControl("lastName")).Text;
                    user.Street = ((TextBox)FindControl("streetAddress")).Text;
                    user.Suburb = ((TextBox)FindControl("suburb")).Text;
                    user.Postcode = ((TextBox)FindControl("postCode")).Text;
                    user.DOB = ((TextBox)FindControl("birthDate")).Text;
                    user.Phone = ((TextBox)FindControl("firstName")).Text;
                    GlobalData.userMap.Add(user.Email, user);

                    //Accessing gmail account to send email
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("bobblehead276@gmail.com", "bhpassword");
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("bobblehead276@gmail.com");
                    msg.To.Add(new MailAddress(user.Email));
                    msg.Subject = "Bobblehead - Confirm Admin Status";
                    //If html does not exist return non-html email
                    msg.Body = ConfirmAdminMessage(false, user.Email, user.FirstName, user.LastName);

                    //create an alternate HTML view that includes images and formatting 
                    string html = ConfirmAdminMessage(true, user.Email, user.FirstName, user.LastName);
                    AlternateView view = AlternateView
                        .CreateAlternateViewFromString(
                            html, null, "text/html");

                    //Adding an image to the email
                    string imgPath = Server.MapPath("../img/bobblebuttlogo.png");
                    LinkedResource img = new LinkedResource(imgPath);
                    img.ContentId = "logoImage";
                    view.LinkedResources.Add(img);

                    //add the HTML view to the message and send
                    msg.AlternateViews.Add(view);
                    try
                    {
                        client.Send(msg);
                        //Send to main page with pop message about sent email
                        Response.Redirect("Main.aspx?confirmAdmin=");

                    }
                    catch
                    {
                        lblRegEmail.Text = "Email could not be sent";
                        lblRegEmail.Visible = true;
                        
                    }
                    
                }
                //If user registered as non admin no email confirmation will be sent
                else
                {
                    user.FirstName = ((TextBox)FindControl("firstName")).Text;
                    user.LastName = ((TextBox)FindControl("lastName")).Text;
                    user.Street = ((TextBox)FindControl("streetAddress")).Text;
                    user.Suburb = ((TextBox)FindControl("suburb")).Text;
                    user.Postcode = ((TextBox)FindControl("postCode")).Text;
                    user.DOB = ((TextBox)FindControl("birthDate")).Text;
                    user.Phone = ((TextBox)FindControl("firstName")).Text;
                    QueryClass.AddUser(user);
                    Session.Add("user", user);

                    Response.Redirect("Main.aspx");

                }


                
            }
            

        }
    }
}