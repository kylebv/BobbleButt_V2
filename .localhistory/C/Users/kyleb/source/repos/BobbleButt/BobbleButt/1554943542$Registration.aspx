﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BobbleButt.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BobbleButt - Login</title>
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
         <img src="img/bobblebuttlogo.png" class="img-fixed-logo" style="max-width:15%"/>
    <div class="container login-container login-form-1">
            <h2>Registration</h2>
            <div class="form-group">
                <label for="firstName" class="col-sm-3 control-label">First Name*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server"  id="firstName" placeholder="First Name" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="lastName" class="col-sm-3 control-label">Last Name*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server"  id="lastName" placeholder="Last Name" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="streetAddress" class="col-sm-3 control-label">Street Address*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server"  id="streetAddress" placeholder="Street Address" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="suburb" class="col-sm-3 control-label">Suburb*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" id="suburb" placeholder="Suburb" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="State" class="col-sm-3 control-label">State*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" id="state" placeholder="State" class="form-control"/>
                </div>
            </div>
        <div class="form-group">
                <label for="Postcode" class="col-sm-3 control-label">Postcode*</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" TextMode="Number" id="Postcode" placeholder="Postcode" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="birthDate" class="col-sm-3 control-label">Date of Birth*</label>
                <div class="col-sm-9">
                    <asp:TextBox textmode="Date" runat="server" id="birthDate" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="phoneNumber" class="col-sm-3 control-label">Phone number* </label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" TextMode="Number" id="phoneNumber" placeholder="Phone number" class="form-control"/>
                </div>
            </div>
                        <div class="form-group">
                <div class="col-sm-9 col-sm-offset-3">
                    <span class="help-block">*Required fields</span>
                </div>
            </div>
            <button type="submit" class="btn btn-primary btn-block">Register</button>
        </div> <!-- ./container -->
        </form>
    </body>
    </html>

