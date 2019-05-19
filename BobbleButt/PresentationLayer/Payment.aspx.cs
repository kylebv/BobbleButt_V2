using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Payment : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Credit_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {

        }

        protected void paypalBtn_Click(object sender, EventArgs e)
        {
            string paypalEmail = ((TextBox)FindControl("paypalEmail")).Text;
            string paypalPword = ((TextBox)FindControl("paypalPassword")).Text;

            /*if (IsValid)
            {
                //GO TO OTHER PAGE
                //Repsonse.Redirect("_________________________");
            }*/







            if (paypalEmail != "")
            {
                ((Label)FindControl("paypalEmailErrorMessage")).Visible = false;
            }
            else if (paypalEmail == "")
            {
                ((Label)FindControl("paypalEmailErrorMessage")).Visible = true;
            }

            if (paypalPword != "")
            {
                ((Label)FindControl("paypalPasswordErrorMessage")).Visible = false;
            }
            else if (paypalPword == "")
            {
                ((Label)FindControl("paypalPasswordErrorMessage")).Visible = true;
            }
        }
        protected void creditCardBtn_Click(object sender, EventArgs e)
        {
            string creditMonth = Request.Form["month"];
            string creditYear = Request.Form["year"];
            string creditCardNumber = ((TextBox)FindControl("creditCardNumber")).Text;
            string creditCSC = ((TextBox)FindControl("creditCSC")).Text;

            /*if (IsValid)
            {
                if (creditMonth == "January" && creditYear == "2019" || creditMonth == "February" && creditYear == "2019" || creditMonth == "March" && creditYear == "2019")
                {

                    ((Label)FindControl("creditCardDate")).Visible = true;

                    
                }
                else
                {
                    ((Label)FindControl("creditCardDate")).Visible = false;
                    //NEED TO FILL THIS OUT SO IF CREDIT CARD VALUES ARE CORRECT IT MOVES TO A CONIFMRATION PAGE
                    //Response.Redirect("_________________")
                }
            }*/
            if (creditMonth == "January" && creditYear == "2019" || creditMonth == "February" && creditYear == "2019" || creditMonth == "March" && creditYear == "2019")
            {

                ((Label)FindControl("creditCardDate")).Visible = true;


            }
            else
            {
                ((Label)FindControl("creditCardDate")).Visible = false;
          
            }


            //string credit = ((TextBox)FindControl("creditCardNumber")).Text;
            int creditCardNumberLength = creditCardNumber.Length;
            int creditCSCLength = creditCSC.Length;

            if (creditCardNumberLength <16 || creditCardNumberLength > 19)
            {
                ((Label)FindControl("creditCardNumberError")).Visible = true;
            }
            else
            {
                ((Label)FindControl("creditCardNumberError")).Visible = false;
            }
            if (creditCSCLength < 3 || creditCSCLength > 4)
            {
                ((Label)FindControl("creditCSCError")).Visible = true;
            }
            else
            {
                ((Label)FindControl("creditCSCError")).Visible = false;
            }
           

        }
    }
}