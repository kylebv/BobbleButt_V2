<%@ Page Title="" Language="C#" MasterPageFile="PageHeader.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BobbleButt.Checkout" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function updateQuantity(control, prod) {
    window.location.href ="/Checkout.aspx?item="+prod+"&quantity="+document.getElementById(control).value;
  }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
	<table id="cart" class="table table-hover table-condensed">
    				<thead>
                        <!-- Headings for the table -->
						<tr>
							<th style="width:50%">Product</th>
							<th style="width:10%">Price</th>
							<th style="width:8%">Quantity</th>
							<th style="width:22%" class="text-center">Subtotal</th>
							<th style="width:10%"></th>
						</tr>
					</thead>
					<tbody>
                        <% double total = 0;
                            //Calculates the the total of the checkout and adds product details to each row based on items in the shopping cart
                            foreach (Product p in cart)
                            {
                                total += p.Quantity * p.Price;%>
						<tr>
                            <!-- Put description and name data and an image in the product coloumn -->
							<td data-th="Product">
								<div class="row">
									<div class="col-sm-2 hidden-xs"><img src="<%=p.Image %>" alt="..." class="cart-image-lg"/></div>
									<div class="col-sm-10 pad-left-table">
										<h4 class="pad-left-table"><%=p.Name %></h4>
										<p class="pad-left-table"><%=p.Description %></p>
									</div>
								</div>
							</td>
                            <!-- Display price of individual product -->
							<td data-th="Price">$<%=p.Price.ToString("F") %></td
                            <!-- Display amount of specific products wanted -->
							<td data-th="Quantity">
                                <!-- Textbox to edit quantity of product wanted -->
								<input type="number" max=<%=Convert.ToInt32(p.Stock) %> min=0 class="form-control text-center" id="q_<%=cart.IndexOf(p) %>" value="<%=p.Quantity %>">
							</td>
                             <!-- Cost of product based on quantity displayed -->
							<td data-th="Subtotal" class="text-center">$<%=(p.Quantity*p.Price).ToString("F") %></td>
							<!-- Buttons to refresh checkout page to get updated total or delete a product from checkout -->
                            <td class="actions" data-th="">
								<button class="btn btn-info btn-sm" onclick="updateQuantity('q_<%=cart.IndexOf(p)%>', '<%=cart.IndexOf(p)%>'); return false"><i class="fa fa-refresh"></i></button>
								<button class="btn btn-danger btn-sm" onclick="window.location.href='/Checkout.aspx?delete=<%=cart.IndexOf(p)%>';return false"><i class="fa fa-trash-o"></i></button>								
							</td>
						</tr>
                        <%} %>
					</tbody>
					<tfoot>
						
						<tr>
							<td colspan="3" class="hidden-xs"></td>
                            <!-- Total cost of checkout displayed using total variable calculated above -->
							<td class="hidden-xs text-center"><strong>Total: $<%=total.ToString("F") %></strong></td>
							<!-- Button/Link  to proceed to final steps of checkout -->
                            <td><a href="Checkout_Info.aspx" class="btn btn-success btn-block">Checkout</a></td>
						</tr>
					</tfoot>
				</table>
</div>
</asp:Content>
