<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Register.aspx.cs" Inherits="BobbleButt.Login_Register" %>

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
        <div class="container login-container">
            <div class="row">
                <div class="col-md-6 login-form-1">
                    <h3>Sign In</h3>
                        <div class="form-group">
                            <asp:TextBox TextMode="Email" id="logEmail" class="form-control" runat="server" placeholder="Your Email *" value="" />
                        </div>
                    
                        <div class="form-group">
                            <asp:TextBox type="password" id="logPassword" runat="server" class="form-control" placeholder="Your Password *" value="" />
                        </div>
                    
                        <div class="form-group">
                            <asp:Button onclick="btnLogin_Click"  runat="server" class="btnSubmit" text="Login" />
                        </div>
                        <div class="form-group">
                            <a href="#" class="ForgetPwd">Forget Password?</a>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="errorMessage" runat="server" Visible="false" class="label-error">Login details do not match any in our system.</asp:Label>
                        </div>
                </div>
                <div class="col-md-6 login-form-2">
                    <h3>Register</h3>
                        <div class="form-group">
                            <asp:TextBox runat="server" TextMode="Email" id="regEmail1" class="form-control" placeholder="Your Email *" value="" />
                        </div>
                                        
                    <div class="form-group">
                            <asp:TextBox runat="server" TextMode="Email" id="regEmail2" class="form-control" placeholder="Re-enter Email *" value="" />
                        <asp:RegularExpressionValidator ID="regexEmailValid" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="regEmail1" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
<br />
                    <asp:CompareValidator 
                           ID="compareEmails" Operator="Equal" runat="server"
                           ValidationGroup="Validate" ControlToValidate="regEmail1"  
                           ControlToCompare="regEmail2" CssClass="label-error" ErrorMessage="Emails do not match." SetFocusOnError="true">
                    </asp:CompareValidator>
                        </div>
                    

                        <div class="form-group">
                            <asp:TextBox TextMode="Password" runat="server" id="regPassword1" class="form-control" placeholder="Your Password *" value="" />
                        </div>
                    
                    <div class="form-group">
                            <asp:TextBox  TextMode="Password" runat="server" id="regPassword2" class="form-control" placeholder="Re-enter Password *" value="" />
                        <asp:RegularExpressionValidator ID="checkLength" CssClass="label-error" runat="server"
                           ControlToValidate="regPassword1"
                           ErrorMessage="Minimum password length is 8"
                           ValidationExpression=".{8}.*" />
                        <br />
                    <asp:CompareValidator
                           ID="comparePasswords" Operator="Equal" runat="server"
                           ValidationGroup="Validate" ControlToValidate="regPassword1"  
                           ControlToCompare="regPassword2" CssClass="label-error" ErrorMessage="Passwords do not match." SetFocusOnError="true">
                    </asp:CompareValidator>
                        </div>
                    <div class="form-group">
                            <asp:Button onclick="btnRegister_Click"  runat="server" class="btnSubmit" text="Register" />
                        </div>
                    <div class="form-group">
                        <label class="ForgetPwd">Register as Admin?</label>
                        <asp:CheckBox runat="server" CssClass="btn" id="chkAdmin"/>
                        </div>
                    <div class="form-group">
                            <asp:Label ID="errorMessage2" runat="server" Visible="false" class="label-error">Email already exists in our system.</asp:Label>
                        </div>
                    
                        </div>
                </div>
            </div>
    </form>
</body>
</html>
