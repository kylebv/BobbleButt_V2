<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="ProductPostage.aspx.cs" Inherits="BobbleButt.ProductPostage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container login-container login-form-2 reg-form">
            <h3>Postage Options</h3>
            <!-- Create textbox that takes up whole row for postage name -->
            <div class="form-group">
                    <div class="col-sm-12">
                    <asp:TextBox ID="namePostage" runat="server" class="form-control" placeholder="Name"/>
                    <!-- Check to see if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="namePostage" class="label-error" ErrorMessage="Name field cannot be empty"/>
                 </div>
            </div>
            
            <!-- Create textbox for postage price -->
            <div class="form-group">
                <div class="col-sm-12">
                    <asp:TextBox runat="server"  id="pricePostage" placeholder="Price" class="form-control"/>
                    <!-- Validators -->
                    <!-- Check if price is greater or equal to zero -->
                    <asp:CompareValidator Display="Dynamic" controlToValidate="pricePostage" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Price field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                    <!-- Check to see if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="pricePostage" class="label-error" ErrorMessage="Price field cannot be empty"/>
                </div>
            </div>

            <!-- What is required to fill out -->
            <div class="form-group">
                <div class="col-sm-9 col-sm-offset-3">
                    <span class="help-block text-white">*Required fields</span>
                </div>
            </div>
            <!-- Submission button -->
            <asp:Button runat="server" class="btn btnSubmit btn-block" Text="Confirm"/>
        </div>
</asp:Content>

