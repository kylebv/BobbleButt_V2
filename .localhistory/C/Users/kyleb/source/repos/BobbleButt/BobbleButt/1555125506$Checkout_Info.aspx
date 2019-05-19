<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout_Info.aspx.cs" Inherits="BobbleButt.Checkout_Info" %>
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
                <label for="firstName">First name</label>
                <asp:TextBox runat="server"  id="firstName" class="form-control" placeholder="First name *"/>
                
              </div>
              <div class="col-md-6 mb-3">
                <label for="lastName">Last name</label>
                <asp:TextBox runat="server" class="form-control" id="lastName" placeholder="Last name *"/>
                
              </div>
            </div>



            <div class="mb-3">
              <label for="email">Email</label>
              <asp:TextBox runat="server" TextMode="Email" class="form-control" id="email" placeholder="you@example.com *"/>
              
            </div>
            <div class="mb-3">
              <label for="phone">Phone number</label>
              <asp:TextBox runat="server" TextMode="Email" class="form-control" id="phone" placeholder="0412345678 *"/>
              
            </div>

            <div class="mb-3">
              <label for="address">Street address</label>
              <asp:TextBox runat="server" class="form-control" id="streetAddress" placeholder="1234 Main St *" />
              
            </div>

            <div class="mb-3">

            </div>

            <div class="row">
              <div class="col-md-7 mb-3">
                              <label for="suburb">Suburb</label>
              <asp:TextBox runat="server" class="form-control" id="suburb" placeholder="Suburb *"/>
              </div>
              <div class="col-md-5 mb-3">
                <label for="postcode">Suburb</label>
              <asp:TextBox runat="server" TextMode="Number" class="form-control" id="postcode" placeholder="1234 *"/>
              </div>
              
            </div>
            
            <hr class="mb-4">

            <h4 class="mb-3">Payment</h4>

            <div class="d-block my-3">
              <div class="">
                <asp:radiobutton GroupName="gp"  runat="server" id="credit" class="" checked="true"/>
                <label class="" for="credit">Credit card</label>
              </div>
              <div class="">
                <asp:radiobutton GroupName="gp" runat="server" id="paypal" class="" />
                <label class="" for="paypal">Paypal</label>
              </div>
            </div>
           
             <div id="paypalForm" runat="server">
            <div class="row">
              <div class="mb-3">
              <label for="payPalEmail">Email</label>
              <asp:TextBox runat="server" TextMode="Email" class="form-control" id="payPalEmail" placeholder="you@example.com *"/>
              
            </div>
                 <div class="mb-3">
              <label for="payPalPassword">Password</label>
              <asp:TextBox runat="server" TextMode="Password" class="form-control" id="TextBox2" placeholder="11111111*"/>
              
            </div>
            </div>
           
                </div>
            <hr class="mb-4"/>
            <button class="btn btn-success btn-lg btn-block" type="submit">Continue to checkout</button>
        </div>
      </div>
    </div>
        </form>
    </body>
</html>

