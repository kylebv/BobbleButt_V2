using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


namespace BobbleButt.PresentationLayer
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GetForgotPasswordMessage(bool isHtml, string emailPassword)
        {
            //Content if html is available 
            if (isHtml)
                return "<html><head><title>Forgotten Password"
                        + " </title></head>"
                        + "<body><img src=cid:logoImage>" + "<br />"
                        + "<h3> Thanks for contacting us to retreive your password.</h3>"
                        + "<p>The password linked to the account "
                        + txtForgottenEmail.Text + " is: <strong>" + emailPassword + "</strong>.</p></body></html>";
            //PLain text if html is not
            else
                return "Thanks for contacting us to retreive your password. \r\n"
                        + "The password linked to the account "
                        + txtForgottenEmail.Text + "is: " + emailPassword + ".";
        }


        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //Go through all the user accounts registered
            foreach (var u in GlobalData.userMap)
            {
                //Check if the user email they entered exists
                if (txtForgottenEmail.Text == u.Value.Email)
                {
                    //Hide error message 
                    lblEmailMessage.Visible = false;

                    // Author:  
                    // URL: https://stackoverflow.com/questions/4559011/sending-asp-net-email-through-gmail/4559071
                    // Date Used: 06/06/19
                    // Website Name: Stackover Flow forms
                    // Use: To send an email form gmail rather than using papercut
                    //---------------------------------------------------------------------------
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
                    //------------------------------------------------------------------------------


                    //Add email content including from, to, subject and body
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("bobblehead276@gmail.com");
                    msg.To.Add(new MailAddress(txtForgottenEmail.Text));
                    msg.Subject = "Bobblehead - Account Password Retrieval";
                    //If html does not exist return non-html email
                    msg.Body = GetForgotPasswordMessage(false, u.Value.Password);

                    //create an alternate HTML view that includes images and formatting 
                    string html = GetForgotPasswordMessage(true, u.Value.Password);
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
                        Response.Redirect("Main.aspx?forgotEmail=");
                    }
                    catch
                    {
                        //Display error message for email failing to send 
                        lblEmailMessage.Text = "Error sending email";
                        lblEmailMessage.Visible = true;
                    }
                    

                }
                //Reveal error message if no email matches ones registered with bobblebutt 
                else
                {
                    lblEmailMessage.Text = "This email is not registered at Bobblehead"; 
                    lblEmailMessage.Visible = true;
                }
            }








        }
        

    }
}