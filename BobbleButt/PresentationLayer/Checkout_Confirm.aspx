﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout_Confirm.aspx.cs" Inherits="BobbleButt.Checkout_Confirm" %>
<%@ Import Namespace="BobbleButt" %>
<%@ Import Namespace="BobbleButt.BusinessLayer" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BobbleButt - Checkout</title>
    <meta name="viewport"
        content="width=device-width, initial-scale=1" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/stylesheet.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    </head>
<body class="blue">
    <form id="form1" runat="server">

        <div class="container login-form-1">
          <div class="row">
            <div class="col-md-4 order-md-2 mb-4">

              <h4 class="d-flex justify-content-between align-items-center mb-3">
                <span class="text-muted">Your cart</span>
                <span class="badge badge-secondary badge-pill"><%=cartCount %></span>
              </h4>
              <ul class="list-group mb-3">
                  <%double total = 0;
                      foreach (Product p in cart)
                      {%>
                <li class="list-group-item d-flex justify-content-between lh-condensed">
                  <div>
                    <!-- Name and quantity of product  -->
                    <h6 class="my-0"><%=p.Name %></h6>
                    <small class="text-muted">Quantity: <%= p.Quantity %></small>
                  </div>
                  <!-- Subtotal of individual product based on quantity -->
                  <span class="text-muted">$<%=(p.Quantity*p.Price).ToString("F") %></span>
                </li>
                  <%} %>
                  <li class="list-group-item d-flex justify-content-between lh-condensed">
                  <div>
                    <h6 class="my-0">Postage</h6>
                    <!-- Name and price of postage from postage list -->
                    <small class="text-muted"><%= order.PostOption.Name %></small>
                  </div>
                  <span class="text-muted">$<%=order.PostOption.Price.ToString("F") %></span>
                </li>
                  <!-- Adding the postage price on to the total checkout price -->
                  <%total += order.PostOption.Price; %>
            
                <!-- Displaying total amount -->
                <li class="list-group-item d-flex justify-content-between">
                  <span>Total (AUD)</span>
                  <strong>$<%=total.ToString("F") %></strong>
                </li>
              </ul>
             <!-- Button to finalize/confirm purchase -->
             <div class="mb-3 ">
                <asp:Button runat="server" OnClick="btnConfirm_Click" class="btn btn-success btn-lg btn-block" text="Finalise Purchase"/>
             </div>
            <!-- An error label for when a card fails. The code behind will add text -->
                <div class="col-md-12 mb-6">
                     <asp:label id="lblCardMessage" Visible="false" runat="server" style="color:red;"></asp:label>
                </div>
            </div>
            <div class="col-md-8 order-md-1">
              <h4 class="mb-3">Confirm Details</h4>
                <br />
                  <!-- Labels of required details and details of specific user making purchase -->
                  <div class="mb-3">
                    <label for="firstName"><strong>First name: </strong><%= order.FirstName %></label>
                
                  </div>
                  <div class="mb-3">
                    <label for="lastName"><strong>Last name: </strong><%= order.LastName %></label>
                  </div>

                <div class="mb-3">
                  <label for="email"><strong>Email: </strong><%= order.UserEmail %></label>
                </div>
                <div class="mb-3">
                  <label for="phone"><strong>Phone number: </strong><%= order.Phone %></label>
                </div>

                <div class="mb-3">
                  <label for="address"><strong>Street address: </strong><%= order.StreetAddress %></label>
                </div>
                <div class="mb-3">
                  <label for="address"><strong>Suburb: </strong><%= order.Suburb %></label>
                </div>
                <div class="mb-3">
                  <label for="address"><strong>Postcode: </strong><%= order.Postcode %></label>
                </div>
                <div class="mb-3">
                  <label for="address"><strong>Street address: </strong><%= order.StreetAddress %></label>
                </div>
                <!-- Postage options and price displayed from a list -->
                <div class="mb-3">
                  <label for="address"><strong>Postage: </strong><%= order.PostOption.Name %> ($<%= order.PostOption.Price.ToString("F") %>)</label>
                </div>

                <div class="mb-3">
                    <!-- Checks to see if user is paying with paypal or credit card and display card number or card number accordingly -->
                    <% if(order.PaypalID!=null){ %>
                    <label for="address"><strong>Paypal ID: </strong><%= order.PaypalID %></label>
                    <%} %>
                    <% else{ %>
                    <label for="address"><strong>Card #: </strong>**** **** **** <%= order.CardNumber.Substring(12) %></label>
                    <%} %>
                </div>
                
                

                </div>
           
     
        </div>
        </form>
    </body>
</html>


