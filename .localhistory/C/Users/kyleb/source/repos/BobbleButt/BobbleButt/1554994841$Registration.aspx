<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BobbleButt.Registration" %>

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
         <img src="img/bobblebuttlogo.png" class="img-fixed-logo"/>
    <div class="container login-container login-form-1 reg-form">
            <h3>Registration</h3>
            <div class="form-group">
                <asp:Label ID="errorMessage" runat="server" Visible="false" class="label-error">Please enter all required fields</asp:Label>
                <label for="firstName" class="col-sm-3 control-label">First Name*</label>
                <div class="col-sm-5">
                    <asp:TextBox runat="server"  id="firstName" placeholder="First Name" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="lastName" class="col-sm-3 control-label">Last Name*</label>
                <div class="col-sm-5">
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
                <div class="col-sm-4">
                    <asp:TextBox runat="server" id="suburb" placeholder="Suburb" class="form-control"/>
                </div>
            </div>
            
        <div class="form-group">
                <label for="Postcode" class="col-sm-3 control-label">Postcode*</label>
                <div class="col-sm-2">
                    <asp:TextBox runat="server" MaxLength="4" id="Postcode" placeholder="Postcode" class="form-control"/>
                </div>
            <!-- regex checks postcode accoring to australian postcode rules, taken from https://www.etl-tools.com/regular-expressions/is-australian-post-code.html-->
                <asp:RegularExpressionValidator Display="Dynamic" ID="regexPoscode" CssClass="label-error" runat="server" ValidationExpression="^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$" ControlToValidate="postcode" ErrorMessage="Invalid Postcode"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                <label for="birthDate" class="col-sm-3 control-label">Date of Birth*</label>
                <div class="col-sm-4">
                    <asp:TextBox textmode="Date" runat="server" id="birthDate" class="form-control"/>
                </div>
                <asp:CompareValidator ID="valBirthDate" Operator="LessThan" CssClass="label-error" type="String" ControltoValidate="birthDate" ErrorMessage="Birth date is invalid" runat="server" />
            </div>
            <div class="form-group">
                <label for="phoneNumber" class="col-sm-3 control-label">Phone number* </label>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" MaxLength="10" id="phoneNumber" placeholder="Phone number" class="form-control"/>
                </div>
                <asp:RegularExpressionValidator Display="Dynamic" ID="regexPhone" CssClass="label-error" runat="server" ValidationExpression="^[0-9]{10}$" ControlToValidate="phoneNumber" ErrorMessage="Invalid Phone Number"></asp:RegularExpressionValidator>

            </div>
        <asp:RequiredFieldValidator runat="server" controltovalidate="postcode"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="phoneNumber"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="birthDate"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="streetAddress"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="firstName"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="lastName"/>
        <asp:RequiredFieldValidator runat="server" controltovalidate="suburb"/>

                        <div class="form-group">
                <div class="col-sm-9 col-sm-offset-3">
                    <span class="help-block">*Required fields</span>
                </div>
            </div>
            <asp:Button runat="server" OnClick="btnRegister_Click" class="btn btnSubmit btn-block" Text="Register"/>
        </div> <!-- ./container -->
        </form>
    </body>
</html>

