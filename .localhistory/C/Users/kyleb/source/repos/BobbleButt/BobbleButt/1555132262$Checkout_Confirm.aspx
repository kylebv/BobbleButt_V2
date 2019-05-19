<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout_Confirm.aspx.cs" Inherits="BobbleButt.Checkout_Confirm" %>
<%@ Import Namespace="BobbleButt" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BobbleButt - Checkout</title>
    <meta name="viewport"
        content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css"
          rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <link href="stylesheet.css" rel="stylesheet" />
    <script type=text/javascript src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    </head>
<body class="blue">
    <form id="form1" runat="server">

    <div class="container login-form-1">
      <div class="row">
        <div class="col-md-4 order-md-2 mb-4">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="text-muted">Your cart</span>
              <%int cartCount = 0; foreach(Product p in cart)
                  { cartCount += p.Quantity; } %>
            <span class="badge badge-secondary badge-pill"><%=cartCount %></span>
          </h4>
          <ul class="list-group mb-3">
              <%double total = 0;
                  foreach (Product p in cart)
                  {
                      total += p.Quantity * p.Price;%>
            <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h6 class="my-0"><%=p.Name %></h6>
                <small class="text-muted">Quantity: <%= p.Quantity %></small>
              </div>
              <span class="text-muted">$<%=(p.Quantity*p.Price).ToString("F") %></span>
            </li>
              <%} %>
            
            <li class="list-group-item d-flex justify-content-between">
              <span>Total (AUD)</span>
              <strong>$<%=total.ToString("F") %></strong>
            </li>
          </ul>

          
        </div>
        <div class="col-md-8 order-md-1">
          <h4 class="mb-3">Shipping address</h4>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">First name: <%= order.FirstName %></label>
                
              </div>
              <div class="col-md-6 mb-3">
                <label for="lastName">Last name: <%= order.LastName %></label>
              </div>
            </div>



            <div class="mb-3">
              <label for="email">Email: <%= order.UserEmail %></label>
            </div>
            <div class="mb-3">
              <label for="phone">Phone number: <%= order.Phone %></label>
            </div>

            <div class="mb-3">
              <label for="address">Street address: <%= order.StreetAddress %></label>
            </div>
            <div class="mb-3">
              <label for="address">Suburb: <%= order.Suburb %></label>
            </div>
            <div class="mb-3">
              <label for="address">Postcode: <%= order.Postcode %></label>
            </div>
            <div class="mb-3">
              <label for="address">Street address: <%= order.StreetAddress %></label>
            </div>

            <div class="mb-3">
                <% if(order.PaypalID!=null){ %>
                <label for="address">Paypal ID: <%= order.PaypalID %></label>
                <%} %>
                <% else{ %>
                <label for="address">Card #: **** **** **** <%= order.CardNumber.Substring(11) %></label>
                <%} %>
            </div>

            </div>
            
            <hr class="mb-4"/>

            <h4 class="mb-3">Payment</h4>

            
           
             <div id="cardForm" runat="server">
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="card_name">Name on card</label>
                <asp:TextBox runat="server" class="form-control" id="card_name" placeholder="" />
                <small class="text-muted">Full name as displayed on card</small>
                  <asp:RequiredFieldValidator ID="valCardName" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a card name" runat="server" controltovalidate="card_name"/>
              </div>
              <div class="col-md-6 mb-3">
                <label for="card_number">Credit card number</label>
                <asp:TextBox runat="server" MaxLength="16" class="form-control" id="card_number" placeholder="" />
                  <asp:RequiredFieldValidator ID="valCardNumber" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a card #" runat="server" controltovalidate="card_number"/>
                                  <asp:RegularExpressionValidator Display="Dynamic" ID="regexCardNumber" CssClass="label-error" runat="server" ValidationExpression="^[0-9]{16}$" ControlToValidate="card_number" ErrorMessage="Invalid Card Number"></asp:RegularExpressionValidator>

              </div>
            </div>
            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="card_expiration">Expiration</label>
                <asp:TextBox runat="server" MaxLength="5" class="form-control" id="card_expiration" placeholder="" />
                  <asp:RequiredFieldValidator ID="valCardExpiration" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter an expiration date" runat="server" controltovalidate="card_expiration"/>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regexCardExpiration" CssClass="label-error" runat="server" ValidationExpression="^((0[1-9])|(1[0-2]))\/(\d{2})$" ControlToValidate="card_expiration" ErrorMessage="Invalid Date Format (mm/yy)"></asp:RegularExpressionValidator>


              </div>
              <div class="col-md-3 mb-3">
                <label for="card_expiration">CVV</label>
                <asp:TextBox runat="server" class="form-control" id="card_cvv" placeholder="" />
                  <asp:RequiredFieldValidator ID="valCardCvv" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a CVV #" runat="server" controltovalidate="card_cvv"/>
                                  <asp:RegularExpressionValidator Display="Dynamic" ID="regexCardCvv" CssClass="label-error" runat="server" ValidationExpression="^[0-9]{3}$" ControlToValidate="card_cvv" ErrorMessage="Invalid Cvv"></asp:RegularExpressionValidator>


              </div>
            </div>
                </div>
            <div id="paypalForm" runat="server">
            <div class="mb-3">
              <label for="payPalEmail">Email</label>
              <asp:TextBox runat="server" TextMode="Email" class="form-control" id="payPalEmail" placeholder="you@example.com *"/>
                <asp:RequiredFieldValidator ID="valPayPalEmail" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter an email address" runat="server" controltovalidate="payPalEmail"/>
                                        <asp:RegularExpressionValidator Display="Dynamic" ID="regexPayPalEmail" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="payPalEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

              
            </div>
                 <div class="mb-3">
              <label for="payPalPassword">Password</label>
              <asp:TextBox runat="server" TextMode="Password" class="form-control" id="payPalPassword" placeholder="*******"/>
                     <asp:RequiredFieldValidator ID="valPayPalPassword" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a password" runat="server" controltovalidate="payPalPassword"/>
                     </div>
                </div>
            <hr class="mb-4"/>
            <asp:Button runat="server" class="btn btn-success btn-lg btn-block" text="Continue to checkout"/>
        </div>
    </div>
        </form>
    </body>
</html>


