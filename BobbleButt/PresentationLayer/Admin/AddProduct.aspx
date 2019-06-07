<%@ Page Title="" Language="C#" MasterPageFile="../PageHeader.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="BobbleButt.AddProduct" %>

<%@ Import Namespace="BobbleButt" %>

<asp:Content ID="manageModification" runat="server" ContentPlaceHolderID="Main"> 
                <div class="container login-container login-form-2 reg-form">
                    <h3>Product Management</h3>
                        <!-- Input textbox for inserting a new name -->
                        <div class="form-group">
                            <label>Name:</label>
                            <asp:TextBox id="manageInsertName" class="form-control" runat="server" placeholder="Product Name" value="" MaxLength="40"/>
                            <!-- Validators -->
                            <!-- Check if textbox is empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertName" class="label-error" ErrorMessage="Name field cannot be empty"/>
                        </div>

                        <!-- Input textbox for inserting a new category -->
                        <div class="form-group">
                            <label>Category:</label>
                            <asp:DropDownList id="manageInsertCategory" class="form-control" runat="server"></asp:DropDownList>
                            </div>

                        <!-- Input textbox for inserting a new stock -->
                        <div class="form-group">
                            <label>Stock:</label>
                            <asp:TextBox id="manageInsertStock" class="form-control" runat="server" placeholder="Product Stock" value="" MaxLength="7"/> 
                            <!-- Validators -->
                            <!-- Check if stock is greater or equal to zero -->
                            <asp:CompareValidator Display="Dynamic" ID="stockValidator" controlToValidate="manageInsertStock" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Stock field is invalid (Integer greater or equal to zero)"></asp:CompareValidator>
                            <!-- Check if field is empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertStock" class="label-error" ErrorMessage="Stock field cannot be empty"/>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regexStock" CssClass="label-error" runat="server" ValidationExpression="^\d+$" ControlToValidate="manageInsertStock" ErrorMessage="Stock must be a number "></asp:RegularExpressionValidator>
                        </div>
                        
                        <!-- Input textbox for description -->
                        <div class="form-group">
                            <label>Description:</label>
                            <!-- Validators -->
                            <!-- Check if textbox is empty -->
                            <asp:TextBox type="name" id="manageInsertDescription" class="form-control" TextMode="MultiLine" Rows="4" runat="server" placeholder="Product Description" value=""/>
                        </div>

                        <!-- Input textbox for Price -->
                        <div class="form-group">
                            <label>Price:</label>
                            <asp:TextBox id="manageInsertPrice" class="form-control" runat="server" placeholder="Product Price" value="" MaxLength="9"/>
                            <!-- Validators -->
                            <!-- Check price is greater or equal to 0 -->
                            <asp:CompareValidator Display="Dynamic" ID="priceValidator" controlToValidate="manageInsertPrice" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Price field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                            <!-- Check field isn't empty -->
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="manageInsertPrice" class="label-error" ErrorMessage="Price field cannot be empty"/>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regexPrice" CssClass="label-error" runat="server" ValidationExpression="^\$?(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$" ControlToValidate="manageInsertPrice" ErrorMessage="Price must be a number "></asp:RegularExpressionValidator>
                        </div>

                        <!-- Image Upload -->
                        <div class="form-group">
                                <label class="text-white">Image (.png .jpg):</label>
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
                        
                        <!-- Submission button -->
                        <div class="form-group">
                            <asp:Button runat="server" class="btnSubmit" text="Submit" OnClick="ManageInsertsSubmitBtn_Click"/>
                        </div>
                </div>
</asp:Content>

