using BobbleButt.BusinessLayer;
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
        protected void ddlPostage_Changed(object sender, EventArgs e)
        {
            postPrice.InnerText= "Postage: $"+GlobalData.postageList[DdlPostage.SelectedIndex].Price.ToString("F");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

           
           
            cart = new List<Product>();
            
            if (!IsPostBack) {
                foreach (PostageOptions po in GlobalData.postageList)
                {
                    ListItem li = new ListItem();
                    li.Text = po.Name;
                    DdlPostage.Items.Add(li);
                }
                DdlPostage.SelectedIndex = 0;
                postPrice.InnerText = "Postage: $" + GlobalData.postageList[DdlPostage.SelectedIndex].Price.ToString("F"); }



            if (Session["cart"] != null)
            {
                cart = (List<Product>)Session["cart"];

            }

            else { Response.Redirect("Checkout.aspx"); }
            // Make paypal or credit card form visible on page laod
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
            // Order is payed for and is added to users orders
            if (IsValid)
            {

                Order o = new Order();
                o.UserEmail = email.Text;
                o.FirstName = firstName.Text;
                o.LastName = lastName.Text;
                o.Phone = phone.Text;
                o.StreetAddress = streetAddress.Text;
                o.Suburb = suburb.Text;
                o.Postcode = postcode.Text;
                o.PostOption = QueryClass.GetPostageOptionByName(DdlPostage.SelectedItem.Text);
                o.Products = ((List<Product>)Session["cart"]);
                o.Date = DateTime.Now.ToString();

                if(paypal.Checked)
                {
                   // o.PaypalID = payPalEmail.Text;
                }
                else
                {
                    //Adding card details to the order to access it on the next page
                    o.CardNumber = card_number.Text;
                    o.CardName = card_name.Text;
                    o.CardCVC = card_cvv.Text;
                    o.CardExpiryDate = card_expiration.Text;   
                }
                Session.Add("order", o);
                Response.Redirect("Checkout_Confirm.aspx");
            }
        }
        protected void chk_Changed(object sender, EventArgs e)
        {
            // Check to see which radio button was checked
            if(paypal.Checked)
            {
                // Make paypal information visible and credit card information invisible
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
                // Make credit information visible and paypal information invisible
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