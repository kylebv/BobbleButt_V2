<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="BobbleButt.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container login-container login-form-2 reg-form">
            <h3>EditProfile</h3>
        <div class="form-group">
                                <asp:Label ID="errorMessage" runat="server" Visible="false" class="label-error">Please enter all required fields</asp:Label>
                
                <div class="col-sm-5">
                    <asp:TextBox runat="server"  id="firstName" placeholder="First Name" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                
                <div class="col-sm-5">
                    <asp:TextBox runat="server"  id="lastName" placeholder="Last Name" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                
                <div class="col-sm-9">
                    <asp:TextBox runat="server"  id="streetAddress" placeholder="Street Address" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                
                <div class="col-sm-4">
                    <asp:TextBox runat="server" id="suburb" placeholder="Suburb" class="form-control"/>
                </div>
            </div>
            
        <div class="form-group">
                
                <div class="col-sm-2">
                    <asp:TextBox runat="server" MaxLength="4" id="Postcode" placeholder="Postcode" class="form-control"/>
                </div>
            <!-- regex checks postcode accoring to australian postcode rules, taken from https://www.etl-tools.com/regular-expressions/is-australian-post-code.html-->
                <asp:RegularExpressionValidator Display="Dynamic" ID="regexPoscode" CssClass="label-error" runat="server" ValidationExpression="^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$" ControlToValidate="postcode" ErrorMessage="Invalid Postcode"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                
                <div class="col-sm-4">
                    <asp:TextBox textmode="Date" runat="server" id="birthDate" class="form-control"/>
                </div>
                <asp:CompareValidator ID="valBirthDate" Operator="LessThan" CssClass="label-error" type="String" ControltoValidate="birthDate" ErrorMessage="Birth date is invalid" runat="server" />
            </div>
            <div class="form-group">
                
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
            <asp:Button runat="server" OnClick="btnConfirm_Click" class="btn btnSubmit btn-block" Text="Confirm"/>
        </div>
</asp:Content>
