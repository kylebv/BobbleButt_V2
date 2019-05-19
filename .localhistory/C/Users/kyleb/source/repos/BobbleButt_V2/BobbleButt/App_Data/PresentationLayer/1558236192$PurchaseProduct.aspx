<%@ Page Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="PurchaseProduct.aspx.cs" Inherits="BobbleButt.PurchaseProduct" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content runat="server" ContentPlaceHolderID="Main"> 
  
<div class="container-fluid">
    <div class="content-wrapper">	
		<div class="item-container">	
			<div class="container">	
				<div class="col-md-12">
                    <!-- Image slot -->
					<div class="product col-md-3 card mt-4"">
                        <asp:image runat="server" id="productViewImage" class="card-img-top img-fluid" alt=""/>
					</div>			
				</div>
				<!-- Coloumn for imafe  -->
				<div class="col-md-7">
                    <h3>
                    <!-- Labels for product name, description and price so that they can be altered with existing data in product list -->
					<div><asp:Label runat="server"  id="productViewName" class="product-title" Text="Product Name"/><br/></div></h3>
					<div><asp:Label runat="server"  id="productViewDescription" class="card-text" Text="Product Description"/></div>
					<hr>
					<div><asp:Label runat="server"  id="productViewPrice" Text="Product Price"/></div>
					<div>In Stock</div>
					<hr>
                    <!-- Button for adding an item to the shopping cart -->
					<div class="btn-group cart">
						<asp:button runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" class="btn btn-success"/>
                    </div>
		
				</div>
			</div> 
		</div>

	</div>
</div>
</asp:Content>