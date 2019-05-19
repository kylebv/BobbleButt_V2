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
            <asp:DropDownList ID="DdlPostage" OnSelectedIndexChanged="ddlPostage_Changed" runat="server"/>
            <span id="postPrice" runat="server">Postage: $<%= GlobalData.postageList[DdlPostage.SelectedIndex].Price.ToString("F"); %></span>

          
        </div>
        <div class="col-md-8 order-md-1">
          <h4 class="mb-3">Shipping address</h4>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">First name</label>
                <asp:TextBox runat="server"  id="firstName" class="form-control" placeholder="First name *"/>
                  <asp:RequiredFieldValidator ID="valFirstName" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a first name" runat="server" controltovalidate="firstName"/>
                
              </div>
              <div class="col-md-6 mb-3">
                <label for="lastName">Last name</label>
                <asp:TextBox runat="server" class="form-control" id="lastName" placeholder="Last name *"/>
                  <asp:RequiredFieldValidator ID="valLastName" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a last name" runat="server" controltovalidate="lastName"/>
                
              </div>
            </div>



            <div class="mb-3">
              <label for="email">Email</label>
              <asp:TextBox runat="server" TextMode="Email" class="form-control" id="email" placeholder="you@example.com *"/>
                <asp:RequiredFieldValidator ID="valEmail" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter an email address" runat="server" controltovalidate="email"/>
                                        <asp:RegularExpressionValidator Display="Dynamic" ID="regexEmail" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

            </div>
            <div class="mb-3">
              <label for="phone">Phone number</label>
              <asp:TextBox runat="server" TextMode="Number" MaxLength="10" class="form-control" id="phone" placeholder="0412345678 *"/>
                <asp:RequiredFieldValidator ID="valPhone" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a phone number" runat="server" controltovalidate="phone"/>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regexPhone" CssClass="label-error" runat="server" ValidationExpression="^[0-9]{10}$" ControlToValidate="phone" ErrorMessage="Invalid Phone Number"></asp:RegularExpressionValidator>

              
            </div>

            <div class="mb-3">
              <label for="address">Street address</label>
              <asp:TextBox runat="server" class="form-control" id="streetAddress" placeholder="1234 Main St *" />
                <asp:RequiredFieldValidator ID="valStreetAddress" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a street address" runat="server" controltovalidate="streetAddress"/>
              
            </div>

            <div class="mb-3">

            </div>

            <div class="row">
              <div class="col-md-7 mb-3">
                              <label for="suburb">Suburb</label>
              <asp:TextBox runat="server" class="form-control" id="suburb" placeholder="Suburb *"/>
                  <asp:RequiredFieldValidator ID="valSuburb" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a suburb" runat="server" controltovalidate="suburb"/>
              </div>
              <div class="col-md-5 mb-3">
                <label for="postcode">Postcode</label>
              <asp:TextBox runat="server" TextMode="Number" MaxLength="4" class="form-control" id="postcode" placeholder="1234 *"/>
                  <asp:RequiredFieldValidator ID="valPostcode" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a postcode" runat="server" controltovalidate="postcode"/>
                                  <asp:RegularExpressionValidator Display="Dynamic" ID="regexPoscode" CssClass="label-error" runat="server" ValidationExpression="^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$" ControlToValidate="postcode" ErrorMessage="Invalid Postcode"></asp:RegularExpressionValidator>

              </div>
              
            </div>
            
            <hr class="mb-4"/>

            <h4 class="mb-3">Payment</h4>

            <div class="d-block my-3">
              <div class="">
                <asp:radiobutton GroupName="gp" OnCheckedChanged="chk_Changed" autopostback="true" runat="server" id="credit" class="" checked="true"/>
                <label class="" for="credit">Credit card</label>
              </div>
              <div class="">
                <asp:radiobutton GroupName="gp" AutoPostBack="true" OnCheckedChanged="chk_Changed" runat="server" id="paypal" class="" />
                <label class="" for="paypal">Paypal</label>
              </div>
            </div>
           
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
                <asp:TextBox runat="server" class="form-control" MaxLength="3" id="card_cvv" placeholder="" />
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
            <asp:Button runat="server" OnClick="btnCheckout_Clicked" class="btn btn-success btn-lg btn-block" text="Continue to checkout"/>
        </div>
    </div>
        </form>
    </body>
</html>

