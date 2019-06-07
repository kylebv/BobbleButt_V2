<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Register.aspx.cs" Inherits="BobbleButt.Login_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BobbleButt - Login</title>
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
        <img src="../img/bobblebuttlogo.png" class="img-fixed-logo"/>
        <div class="container login-container">
            <div class="row">
                <div class="col-md-6 login-form-1">
                    <!-- Login fields displayed -->
                    <h3>Sign In</h3>
                        <!-- Email -->
                        <div class="form-group">
                            <asp:TextBox id="logEmail" class="form-control" runat="server" placeholder="Your Email *" value="" maxLength="80"/>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="logEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                        </div>
                        <!-- Password -->
                        <div class="form-group">
                            <asp:TextBox type="password" id="logPassword" runat="server" class="form-control" placeholder="Your Password *" value="" Maxlength="30"/>
                        </div>
                        <!-- Login button -->
                        <div class="form-group">
                            <asp:Button onclick="btnLogin_Click" causesvalidation="false" runat="server" class="btnSubmit" text="Login" />
                        </div>
                        <!-- Error message shown for wrong user name or password -->
                        <div class="form-group">
                            <asp:Label ID="errorMessage" runat="server" Visible="false" class="label-error">Login failed. You may be suspended, or your details are incorrect.</asp:Label>
                        </div>
                        <!-- Forgot Password link -->
                        <div class="form-group">
                              <asp:HyperLink id="forgotPasswordLink" NavigateUrl="/ForgotPassword" Text="Forgot your password?" runat="server"></asp:HyperLink>
                        </div>
                </div>
                <!-- Register fields displayed -->
                <div class="col-md-6 login-form-2">
                    <h3>Register</h3>
                    <!-- Email -->
                    <div class="form-group">
                            <asp:TextBox runat="server" TextMode="Email" id="regEmail1" class="form-control" placeholder="Your Email *" value="" MaxLength="80"/>
                            <asp:RequiredFieldValidator Enabled="false" Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter an email" runat="server" controltovalidate="regEmail1"/>
                    </div>
                    <!-- Confirm email -->                    
                    <div class="form-group">
                            <asp:TextBox runat="server" TextMode="Email" id="regEmail2" class="form-control" placeholder="Re-enter Email *" value="" MaxLength="80"/>
                            <asp:RequiredFieldValidator Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter an email" runat="server" controltovalidate="regEmail2"/>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regexEmailValid" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="regEmail1" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                        <br />
                        <!-- Check if email entered matches to original email entered -->
                            <asp:CompareValidator 
                                   ID="compareEmails" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="regEmail1"  
                                   ControlToCompare="regEmail2" CssClass="label-error" ErrorMessage="Emails do not match." SetFocusOnError="true">
                            </asp:CompareValidator>
                    </div>
                    <!-- Password -->
                     <div class="form-group">
                            <asp:TextBox TextMode="Password" runat="server" id="regPassword1" class="form-control" placeholder="Your Password *" value="" MaxLength="30"/>
                            <asp:RequiredFieldValidator Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a password" runat="server" controltovalidate="regPassword1"/>
                     </div>
                    <!-- Re-enter password -->
                    <div class="form-group">
                            <asp:TextBox  TextMode="Password" runat="server" id="regPassword2" class="form-control" placeholder="Re-enter Password *" value="" MaxLength="30"/>
                            <asp:RequiredFieldValidator Display="Dynamic" CssClass="label-error" ErrorMessage="Please enter a password" runat="server" controltovalidate="regPassword2"/>
                            <!-- Password length has to be 8 or greater -->
                            <asp:RegularExpressionValidator Display="Dynamic" ID="checkLength" CssClass="label-error" runat="server"
                           ControlToValidate="regPassword1"
                           ErrorMessage="Minimum password length is 8"
                           ValidationExpression=".{8}.*" />
                        <br />
                            <!-- Check to see passwords match -->
                            <asp:CompareValidator
                                   ID="comparePasswords" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="regPassword1"  
                                   ControlToCompare="regPassword2" CssClass="label-error" ErrorMessage="Passwords do not match." SetFocusOnError="true">
                            </asp:CompareValidator>
                    </div>
                    <!-- Register Button -->
                    <div class="form-group">
                            <asp:Button onclick="btnRegister_Click"  runat="server" class="btnSubmit" text="Register" />
                    </div>
                    <!-- Checkbox to register as an admin -->
                    <div class="form-group">
                        <label class="ForgetPwd">Register as Admin?</label>
                        <asp:CheckBox runat="server" CssClass="btn" id="chkAdmin"/>
                    </div>
                    <!-- Error message to display if email is already used--> 
                     <div class="form-group">
                         <asp:Label ID="errorMessage2" runat="server" Visible="false" class="label-error">Email already exists in our system.</asp:Label>
                     </div>
                    
                    <asp:RequiredFieldValidator runat="server" controltovalidate="regEmail1"/>


                </div>
                </div>
            </div>
    </form>
</body>
</html>
