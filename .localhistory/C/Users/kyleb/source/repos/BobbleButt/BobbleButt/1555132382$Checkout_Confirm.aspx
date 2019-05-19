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
          <div class="row">
            <asp:Button runat="server" class="btn btn-success btn-lg btn-block" text="Continue to checkout"/>
              </div>
        </div>
    </div>
        </form>
    </body>
</html>


