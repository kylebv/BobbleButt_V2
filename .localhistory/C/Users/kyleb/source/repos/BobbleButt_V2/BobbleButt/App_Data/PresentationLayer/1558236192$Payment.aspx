<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="BobbleButt.Payment" %>

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
    <script type="text/javascript">
        function togglePayment1() {
        
            
            //https://stackoverflow.com/questions/1136046/jquery-show-hide-toggle-works-but-doesnt-stay-as-it-should-it-reverts-to-ori
            event.preventDefault();
            $("#CreditCardDiv").show();
            $("#PaypalDiv").hide();
           
        }function togglePayment2() {
        
            
            
            event.preventDefault();
            $("#CreditCardDiv").hide();
            $("#PaypalDiv").show();
           
        }

        /*function dateValidate() {
           
            var selectedMonth = $("select.creditCardMonth").children("options:selected").text(); 
            var selectedYear = $("select.creditCardYear").children("options:selected").text();
            if (selectedMonth == "January" && selectedYear == "2019" || selectedMonth == "February" && selectedYear == "2019" || selectedMonth == "March" && selectedYear == "2019") {
                $("#creditCardDate").show();
            }
            else {
                $("#creditCardDate").hide();
            }
        }*/
        

           
    </script>
    </head>
<body class="blue">
    <form id="form1" runat="server">

<div class="payment-container login-container">
            <div class="row">
                <div class="col-md-12 login-form-1">
                    <h3>Payment</h3>
                        <label> Select Payment: </label>
                        <div class="form-group">
                            <label>
                            <asp:Button id="paypalBtnSwitch" runat="server" Text="Paypal" OnClientClick="togglePayment2()"/>
                            <span class="glyphicon glyphicon-ok"></span>
                            </label>
                        </div>
                        <div class="form-group">
                            <label>
                            <asp:Button id="creditCardBtnSwitch" runat="server" Text="Credit Card" OnClientClick="togglePayment1()"/>
                                <span class="glyphicon glyphicon-ok"></span>
                            </label>
                        </div>
                    <hr/>
                </div>
            </div>
</div>
<div id="PaypalDiv" class="payment-container login-container">
            <div class="row">
                <div class="col-md-12 login-form-1">
                        <div class="form-group">
                            <label>Email:</label>
                            <asp:TextBox textmode="Email" id="paypalEmail" class="form-control" runat="server" placeholder="Email" value="" OnTextChanged="logEmail_TextChanged" />
                            <!--<asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="paypalEmail" class="label-error" ErrorMessage="Email field cannot be empty"/>-->
                        </div>

                        <div class="form-group">
                            <asp:Label ID="paypalEmailErrorMessage" runat="server" Visible="false" class="label-error">Email field cannot be empty</asp:Label>
                        </div>
                    
                        <div class="form-group">
                            <label>Password:</label>
                            <asp:TextBox id="paypalPassword" type="password" runat="server" class="form-control" placeholder="Password" value="" />
                           <!-- <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="paypalPassword" class="label-error" ErrorMessage="Password field cannot be empty"/>-->
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="paypalPasswordErrorMessage" runat="server" Visible="false" class="label-error">Password field cannot be empty</asp:Label>
                        </div>

                          <div class="form-group">
                            <asp:Button runat="server" class="btnSubmit" text="Submit" OnClick="paypalBtn_Click"/>
                        </div>
                </div>
         </div>
</div>
<div id="CreditCardDiv" class="payment-container login-container payment-invisible">
            <div class="row">
                <div class="col-md-12 login-form-1">
                        <div class="form-group">
                            <label>Card Number:</label>
                            <asp:TextBox class="form-control" type="number" runat="server" placeholder="Card Number" id="creditCardNumber"/>
                            <!--<asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="creditCardNumber" class="label-error" ErrorMessage= "Card Number field cannot be empty"/>-->
                        </div>
                    
                        <div class="form-group">
                            <asp:Label ID="creditCardNumberError" runat="server" Visible="false" class="label-error">Card Number is NOT the correct length</asp:Label>
                        </div>
                        <div class="form-group">
                            <label>CSC:</label>
                            <asp:TextBox runat="server" type="number" class="form-control" placeholder="CSC" id="creditCSC" maxLength="4" minLength="3"/>
                            <!--<asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="creditCSC" class="label-error" ErrorMessage="CSC field cannot be empty"/>-->
                        </div>
                    
                        <div class="form-group">
                            <asp:Label ID="creditCSCError" runat="server" Visible="false" class="label-error">CSC is NOT the correct length</asp:Label>
                        </div>


                        <div>
                        <label>Card Expiry Date:</label>
                            <div>
                              <select id="creditCardMonth" name="month">
                                <option>January</option>       
                                <option>February</option>       
                                <option>March</option>       
                                <option>April</option>       
                                <option>May</option>       
                                <option>June</option>       
                                <option>July</option>       
                                <option>August</option>       
                                <option>September</option>       
                                <option>October</option>       
                                <option>November</option>       
                                <option>December</option>
                              </select>
                            </div> <br/>
                            <div>
                           
                              <select id="creditCardYear" name="year">
                                <option>2019</option>       
                                <option>2020</option>       
                                <option>2021</option>       
                                <option>2022</option>       
                                <option>2023</option>       
                                <option>2024</option>       
                                <option>2025</option>       
                                <option>2026</option>       
                                <option>2027</option>       
                                <option>2028</option>       
                                <option>2029</option>       
                                <option>2030</option>
                              </select>
                            </div>
                          </div> <br/>
                       <div class="form-group">
                            <asp:Label ID="creditCardDate" runat="server" Visible="false" class="label-error">Date is invalid: Cannot be before current date</asp:Label>
                            </div>
                          <div class="form-group">
                            <asp:Button runat="server" class="btnSubmit" text="Submit" OnClick="creditCardBtn_Click"/>
                        </div>
                </div>
            </div>
  </div>




</form>

</body>
</html>