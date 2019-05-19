<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="BobbleButt.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container login-container login-form-2 reg-form">
            <h3>Update Product</h3>
           
            <div class="form-group">
               <!-- Text box created which is product name takes up 6 coloumns out of 12 -->
                <div class="col-sm-6">
                    <asp:TextBox runat="server"  id="productUpdateName" placeholder="Product Name"  class="form-control" />
                    <!-- Check if name field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="productUpdateName" class="label-error" ErrorMessage="Name field cannot be empty"/>
                </div>
            </div>

            <!-- Textbox for category -->
            <div class="form-group">
                <div class="col-sm-6">
                    <asp:TextBox runat="server"  id="productUpdateCategory" placeholder="Product Category" class="form-control"/>
                    <!-- Check if category field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="productUpdateCategory" class="label-error" ErrorMessage="Category field cannot be empty"/>
                </div>
            </div>

            <!-- Textbox for stock -->
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:TextBox runat="server" type="number"  id="productUpdateStock" placeholder="Product Stock" class="form-control"/>
                    <!-- Validators -->
                    <!-- Check if stock input is greater than or equal to 0 -->
                    <asp:CompareValidator Display="Dynamic" ID="stockValidator" controlToValidate="productUpdateStock" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Stock field is invalid (Integer greater or equal to zero)"></asp:CompareValidator>
                    <!-- Check if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="productUpdateStock" class="label-error" ErrorMessage="Stock field cannot be empty"/>
                </div>
            </div>

            <!-- Textbox for description -->
            <div class="form-group">
                <div class="col-sm-9">
                    <asp:TextBox runat="server" id="productUpdateDescription" placeholder="Product Description" class="form-control"/>
                </div>
            </div>
            
            <!-- textbox for price -->
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:TextBox runat="server" type="number" id="productUpdatePrice" placeholder="Product Price" class="form-control" />
                    <!-- Validators -->
                    <!-- Check if price is greater or equal to zero-->
                    <asp:CompareValidator Display="Dynamic" ID="priceValidator" controlToValidate="productUpdatePrice" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Price field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                    <!-- Check if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="productUpdatePrice" class="label-error" ErrorMessage="Price field cannot be empty"/>
                </div>
            </div>
            <!-- Spot to upload images to update product image -->
            <div class="form-group">
                    <label>Image:</label>
                    <asp:FileUpload id="updateFileUploadImg" runat="server" /> <br/>
                    <!-- Check if no file is selected -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="updateFileUploadImg" class="label-error" ErrorMessage="No file selected"/>
             </div>

                         <!-- Error message for Image Upload where wrong file type is uploaded -->
             <div class="form-group">
                   <asp:Label ID="updateImageFileError" runat="server" Visible="false" class="label-error">Wrong file type has been uploaded</asp:Label>
             </div>

            <!-- Text box for updated quantity -->
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:TextBox runat="server" type="number" id="productUpdateQuantity" placeholder="Product Quantity" class="form-control"/>
                    <!-- Validators -->
                    <!-- Check if value is greater or equal to zero -->
                    <asp:CompareValidator Display="Dynamic" ID="quantityValidator" controlToValidate="productUpdateQuantity" runat="server" class="label-error" Operator="GreaterThanEqual" ValueToCompare="0" ErrorMessage="Quantity field is invalid, value must be greater or equal to zero"></asp:CompareValidator>
                    <!-- Check if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="productUpdateQuantity" class="label-error" ErrorMessage="Quantity field cannot be empty"/>
                </div>
            </div>
        
            <!-- What fields are required to fill out -->
            <div class="form-group">
                <div class="col-sm-9 col-sm-offset-3">
                    <span class="help-block text-white">*Required fields</span>
                </div>
            </div>

            <!-- Submission button -->
            <asp:Button runat="server" class="btn btnSubmit btn-block" OnClick="updateConfirmBtn_Clicked" Text="Confirm"/>
        </div>
</asp:Content>

