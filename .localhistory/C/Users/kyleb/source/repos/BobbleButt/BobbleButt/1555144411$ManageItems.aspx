<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeFile="ManageItems.aspx.cs" Inherits="BobbleButt.ManageItems" %>

<%@ Import Namespace="BobbleButt" %>

<asp:Content ID="manageModification" runat="server" ContentPlaceHolderID="Main"> 

<div id="PaypalDiv" class="payment-container login-container" style="padding-bottom:35px">
            <div class="row">
                <div class="col-md-12 login-form-1">
                    <h3>Product Management</h3>
                        <!-- Input textbox for inserting a new name -->
                        <div class="form-group">
                            <label>Name:</label>
                            <asp:TextBox id="manageInsertName" class="form-control" runat="server" placeholder="Product Name" value=""/>
                            <!-- Validators -->
                            <!-- Check if textbox is empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertName" class="label-error" ErrorMessage="Name field cannot be empty"/>
                        </div>

                        <!-- Input textbox for inserting a new category -->
                        <div class="form-group">
                            <label>Category:</label>
                            <asp:TextBox id="manageInsertCategory" class="form-control" runat="server" placeholder="Product Category" value=""/>
                            <!-- Validators -->
                            <!-- Check if textbox is empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertCategory" class="label-error" ErrorMessage="Category field cannot be empty"/>
                        </div>

                        <!-- Input textbox for inserting a new stock -->
                        <div class="form-group">
                            <label>Stock:</label>
                            <asp:TextBox type="number" id="manageInsertStock" class="form-control" runat="server" placeholder="Product Stock" value=""/> 
                            <!-- Validators -->
                            <!-- Check if stock is greater or equal to zero -->
                            <asp:CompareValidator Display="Dynamic" ID="stockValidator" controlToValidate="manageInsertStock" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Stock field is invalid (Integer greater or equal to zero)"></asp:CompareValidator>
                            <!-- Check if field is empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertStock" class="label-error" ErrorMessage="Stock field cannot be empty"/>
                        </div>
                        
                        <!-- Input textbox for description -->
                        <div class="form-group">
                            <label>Description:</label>
                            <!-- Validators -->
                            <!-- Check if textbox is empty -->
                            <asp:TextBox type="name" id="manageInsertDescription" class="form-control" runat="server" placeholder="Product Description" value=""/>
                        </div>

                        <!-- Input textbox for Price -->
                        <div class="form-group">
                            <label>Price:</label>
                            <asp:TextBox type="number" id="manageInsertPrice" class="form-control" runat="server" placeholder="Product Price" value=""/>
                            <!-- Validators -->
                            <!-- Check price is greater or equal to 0 -->
                            <asp:CompareValidator Display="Dynamic" ID="priceValidator" controlToValidate="manageInsertPrice" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Price field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                            <!-- Check field isn't empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertPrice" class="label-error" ErrorMessage="Price field cannot be empty"/>
                        </div>

                        <!-- Image Upload -->
                        <div class="form-group">
                                <label>Image:</label>
                            <!--Author:
                            Use:  To allow for an image to be uploaded
                            Website Name: ASP.net webform Tutorials
                            Website Url: https://asp.net-tutorials.com/controls/file-upload-control 
                            Date: 11/04/19
                            -->
                        <asp:FileUpload id="FileUploadImg" runat="server" /> <br/>
                         <!-- Validators -->
                         <!-- Check if file selected is non existent -->
                        <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="FileUploadImg" class="label-error" ErrorMessage="No file selected"/>
                        </div>

                        <!-- Error message for Image Upload where wrong file type is uploaded. This box starts off as invisbile and changes if requirements arent met -->
                        <div class="form-group">
                            <asp:Label ID="insertImageFileError" runat="server" Visible="false" class="label-error">Wrong file type has been uploaded</asp:Label>
                        </div>

                        <!-- Textbox for quantity-->
                        <div class="form-group">
                            <label>Quantity:</label>
                            <asp:TextBox type="number" id="manageInsertQuantity" class="form-control" runat="server" placeholder="Product Quantity" value=""/>
                            <!-- Validators -->
                            <!-- Check quantity is greater or equal to zero -->
                            <asp:CompareValidator Display="Dynamic" ID="quantityValidator" controlToValidate="manageInsertQuantity" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Quantity field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                            <!-- Check if field doesnt have an input -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertQuantity" class="label-error" ErrorMessage="Quantity field cannot be empty"/>
                        </div>
                        
                        <!-- Submission button -->
                        <div class="form-group">
                            <asp:Button runat="server" class="btnSubmit" text="Submit" OnClick="ManageInsertsSubmitBtn_Click"/>
                        </div>
                </div>
            </div>
</div>



</asp:Content>

