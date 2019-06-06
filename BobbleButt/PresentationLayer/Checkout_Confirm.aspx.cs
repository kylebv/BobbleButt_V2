using BobbleButt.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace BobbleButt
{
    public partial class Checkout_Confirm : System.Web.UI.Page
    {
        protected Order order;
        protected List<Product> cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["order"] != null && Session["cart"] != null)
            {
                order = (Order)Session["order"];
                cart = (List<Product>)Session["cart"];
            }
            // If cart/order is empty redirect to checkout
            else
            {
                Response.Redirect("Checkout.aspx");
            }
        }

        private string invoiceMessage(bool isHtml, string firstName, string lastName, string postCode, string streetAddress, string suburb, int postOption, string orderDate, List<Product> products)
        {
            double total = 0;
            //Content if html is available 
            if (isHtml)
            {
                String s = "<html><head><title>Order Invoice"
                        + " </title></head>"
                        + "<body><img src=cid:logoImage style = 'width:50%;'>" + "<br />"
                        + "<h3> Invoice </h3>"
                        + "<div style = 'overflow: hidden; display: table; '><div style = 'float: left; width: 50 %; padding: 5px; '> <h4> Billed To: </h4>"
                        + "<p>" + firstName + " " + lastName + "<br />" + streetAddress + ", " + suburb + "<br />" + postCode + "</p></div>"
                        + "<div style = 'float: left; width: 50 %; padding: 5px; '><h4> Shipped To: </h4>"
                        + "<p>" + firstName + " " + lastName + "<br />" + streetAddress + ", " + suburb + "<br />" + postCode + "</p></div></div>"
                        + "<div style='float: left; width = 100%'><p><strong> Invoice Date: </strong>" + orderDate + "</p>"
                        + "<table style='border-style: solid;'>"
                        + "<tr>"
                        + "<th><strong> Quantity </strong></th>"
                        + "<th><strong> Product </strong></th>"
                        + "<th><strong> Price </strong></th>"
                        + "<th><strong> Total Product Price </strong></th>"
                        + "</tr>";
                //Put all the product details in a table 
                foreach (Product p in products)
                {
                    s += "<tr>"
                         + "<th>" + p.Quantity + "</th>"
                         + "<th>" + p.Name + "</th>"
                         + "<th> $" + p.Price.ToString("F") + "</th>"
                         + "<th> $" + (p.Quantity * p.Price).ToString("F") + "</th>"
                         + "</tr>";
                    total += p.Quantity * p.Price;
                }
                //Postage price and total product price
                double finalTotal = order.PostOption.Price + total;
                s += "<tr>"
                    + "<th></th>"
                    + "<th></th>"
                    + "<th> Postage Option: </th>"
                    + "<th>" + order.PostOption.Name + "</th>"
                    + "</tr>";
                s += "<tr>"
                    + "<th></th>"
                    + "<th></th>"
                    + "<th> Postage Cost: </th>"
                    + "<th> $" + order.PostOption.Price.ToString("F") + "</th>"
                    + "</tr>";
                s += "<tr>"
                    + "<th></th>"
                    + "<th></th>"
                    + "<th> <strong>TOTAL (AUD):</strong> </th>"
                    + "<th> <strong>$" + finalTotal.ToString("F") + "</strong></th>"
                    + "</tr>";
                s += "</table> </div>"
                + "</body></html>";
                return s;
            }
            //PLain text if html is not
            else
            {
                double totalElse = 0;
                String a = "Billed To: " + firstName + " " + lastName + "\r\n" + streetAddress + ", " + suburb + "\r\n" + postCode
                       + "Shipped To:" + firstName + " " + lastName + "\r\n" + streetAddress + ", " + suburb + "\r\n" + postCode
                       + "\r\n Invoice Date: " + orderDate + "Quantity: ";
                foreach (Product p in products) { a += p.Quantity; }
                a += "Product Name: ";
                foreach (Product p in products) { a += p.Name; }
                a += "Price: ";
                foreach (Product p in products) { a += p.Price; }
                a += "Total Product Price: ";
                foreach (Product p in products) { a += p.Price * p.Quantity; totalElse += p.Quantity * p.Price; }
                double finalTotal = order.PostOption.Price + total;
                a += "Postage Option: " + order.PostOption.Name + "\r\n Postage Price: " + order.PostOption.Price.ToString("F") + "TOTAL (AUD): " + totalElse.ToString("F");
                return a;
            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string cardNumber, cardName;
            int cvc, count = 0;
            DateTime expiryDate;
            double totalPriceCost = 0, totalCheckout;

            //Get user input for payment details
            cardNumber = order.CardNumber;
            cardName = order.CardName;
            cvc = Convert.ToInt32(order.CardCVC);
            expiryDate = Convert.ToDateTime(order.CardExpiryDate + "/1");


            //Get total of products in checkout
            foreach (Product p in cart)
            {
                totalPriceCost += p.Quantity * p.Price;
            }

            //Total of checkout including postage
            totalCheckout = totalPriceCost + order.PostOption.Price;


            INFT3050.PaymentSystem.IPaymentSystem paymentSystem = INFT3050.PaymentSystem.INFT3050PaymentFactory.Create();

            INFT3050.PaymentSystem.PaymentRequest payment = new INFT3050.PaymentSystem.PaymentRequest();

            //User input being added to payment process
            payment.CardName = cardName;
            payment.CardNumber = cardNumber;
            payment.CVC = cvc;
            payment.Expiry = expiryDate;
            payment.Amount = Convert.ToDecimal(totalCheckout);
            payment.Description = "test";

            var task = paymentSystem.MakePayment(payment);

            //Keep repeating until the task has completed
            while (count == 0)
            {
                if (task.IsCompleted)
                {
                    //Hide card invalid message
                    lblCardMessage.Visible = false;

                    //Transaction was approved
                    if (Convert.ToInt32(task.Result.TransactionResult) == 0)
                    {
                        order = (Order)Session["order"];
                        GlobalData.Orders.Add(order);
                        List<Product> temp = new List<Product>();
                        foreach (Product p in order.Products)
                        {
                            foreach (Product p2 in GlobalData.productList)
                            {
                                //Reduce stock based on quanity purchase
                                if (p2.Name.Equals(p.Name))
                                {
                                    p2.Stock -= p.Quantity;
                                }
                            }
                        }
                        foreach (Product p in GlobalData.productList)
                        {
                            if (p.Stock > 0)
                            {
                                temp.Add(GlobalData.productList[GlobalData.productList.IndexOf(p)]);
                            }
                        }
                        GlobalData.productList = temp;
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

                        //Adding message 
                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("bobblehead276@gmail.com");
                        msg.To.Add(new MailAddress(order.UserEmail));
                        msg.Subject = "Bobblehead - Invoice";
                        //If html does not exist return non-html email
                        msg.Body = invoiceMessage(false, order.FirstName, order.LastName, order.Postcode, order.StreetAddress, order.Suburb, order.PostOption.ID, order.Date, order.Products);

                        //create an alternate HTML view that includes images and formatting 
                        string html = invoiceMessage(true, order.FirstName, order.LastName, order.Postcode, order.StreetAddress, order.Suburb, order.PostOption.ID, order.Date, order.Products);
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
                        }
                        catch
                        {
                            lblCardMessage.Text = "Error Sending Email";
                        }

                        //Remove items from cart and redirect to success purchase home/main page
                        Session.Remove("order");
                        Session.Remove("cart");
                        Response.Redirect("Main.aspx?orderEmail=" + order.UserEmail);
                    }
                    //Transaction was denied
                    else if (Convert.ToInt32(task.Result.TransactionResult) == 1)
                    {
                        lblCardMessage.Text = "The card was denied";
                        lblCardMessage.Visible = true;
                    }
                    //Transaction was invalid
                    else if (Convert.ToInt32(task.Result.TransactionResult) == 2)
                    {
                        lblCardMessage.Text = "The card details were invalid";
                        lblCardMessage.Visible = true;
                    }
                    //Transaction card expiry date was invalid
                    else if (Convert.ToInt32(task.Result.TransactionResult) == 3)
                    {
                        lblCardMessage.Text = "The card Expiry Date was invalid";
                        lblCardMessage.Visible = true;
                    }
                    //Transaction timed out
                    else if (Convert.ToInt32(task.Result.TransactionResult) == 4)
                    {
                        lblCardMessage.Text = "The card details could not be processed due to Connection Failure";
                        lblCardMessage.Visible = true;
                    }
                    //Will stop the while loop
                    count = 1;
                }
                //Keep the count at 0 so the while loop continues
                else
                {
                    count = 0;
                }
            }
        }

    }
}