<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BobbleButt.PresentationLayer.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BobbleButt - Forgot Password</title>
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
        <div class="container login-container login-form-1 reg-form">
            <h3>Password Assistance</h3>
            <!-- Information about password assistance -->
            <div class="form-group">
                 <div class="col-sm-12">
                    <label class="lblForgotPassword"> Enter the email address that is linnked to your Bobblehead account. </label>
                    <!-- Check to see if field is empty -->
                 </div>
            </div>
            <!-- Create textbox that takes up whole row for postage name -->
            <div class="form-group">
                    <div class="col-sm-12">
                    <asp:TextBox ID="txtForgottenEmail" runat="server" class="form-control" placeholder="Email" MaxLength="80"/>
                    <!-- Check to see if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="txtForgottenEmail" class="label-error" ErrorMessage="Email field cannot be empty"/>
                    <asp:RegularExpressionValidator Display="Dynamic" ID="valForgottenPassword" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtForgottenEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                 </div>
            </div>

            <!-- Submission button -->
            <asp:Button runat="server" OnClick="btnContinue_Click" class="btn btnSubmit btn-block" Text="Continue"/>
            <asp:label runat="server" ID="lblEmailMessage" Visible="false" style="color:red;"> This email is not registered at Bobblehead </asp:label>
        </div>
    </form>
</body>
</html>
