using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Checkout_Info : System.Web.UI.Page
    {
        protected List<Product> cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("cart", GlobalData.productList);
            cart = new List<Product>();


            if (Session["cart"] != null)
            {
                cart = (List<Product>)Session["cart"];

            }
            if (!paypal.Checked)
            {
                paypalForm.Visible = false;
                cardForm.Visible = true;
            }
            else
            {
                paypalForm.Visible = true;
                cardForm.Visible = false;
            }

        }
        protected void btnCheckout_Clicked(object sender, EventArgs e)
        {
            if(IsValid)
            {
                Order o = new Order(email.Text, firstName.Text, lastName.Text, phone.Text, streetAddress.Text, suburb.Text, postcode.Text, null, null, ((List<Product>)Session["cart"]), "Processing", DateTime.Now.ToString());
                if(paypal.Checked)
                {
                    o.PaypalID = payPalEmail.Text;
                }
                else
                {
                    o.CardNumber = card_number.Text;
                }
                Session.Add("order", o);
                Response.Redirect("Checkout_Confirm.aspx");
            }
        }
        protected void chk_Changed(object sender, EventArgs e)
        {
            if(paypal.Checked)
            {
                paypalForm.Visible = true;
                cardForm.Visible = false;
                valCardCvv.Enabled = false;
                valCardExpiration.Enabled = false;
                valCardName.Enabled = false;
                valCardNumber.Enabled = false;
                valPayPalEmail.Enabled = true;
                valPayPalPassword.Enabled = true;

            }
            else if (credit.Checked)
            {
                paypalForm.Visible = false;
                cardForm.Visible = true;
                valCardCvv.Enabled = true;
                valCardExpiration.Enabled = true;
                valCardName.Enabled = true;
                valCardNumber.Enabled = true;
                valPayPalEmail.Enabled = false;
                valPayPalPassword.Enabled = false;
            }
        }
    }
}