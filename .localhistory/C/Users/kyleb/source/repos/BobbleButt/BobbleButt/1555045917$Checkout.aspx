<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BobbleButt.Checkout" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
	<table id="cart" class="table table-hover table-condensed">
    				<thead>
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
                            foreach (Product p in cart)
                            {
                                total += p.Quantity * p.Price;%>
						<tr>
							<td data-th="Product">
								<div class="row">
									<div class="col-sm-2 hidden-xs"><img src="<%=p.Image %>" alt="..." class="img-responsive"/></div>
									<div class="col-sm-10 pad-left-table">
										<h4 class="pad-left-table"><%=p.Name %></h4>
										<p class="pad-left-table"><%=p.Description %></p>
									</div>
								</div>
							</td>
							<td data-th="Price">$<%=p.Price.ToString("F") %></td>
							<td data-th="Quantity">
								<input type="number" class="form-control text-center" value="<%=p.Quantity %>">
							</td>
							<td data-th="Subtotal" class="text-center">$<%=(p.Quantity*p.Price).ToString("F") %></td>
							<td class="actions" data-th="">
								<button class="btn btn-info btn-sm"><i class="fa fa-refresh"></i></button>
								<button class="btn btn-danger btn-sm"><i class="fa fa-trash-o"></i></button>								
							</td>
						</tr>
                        <%} %>
					</tbody>
					<tfoot>
						
						<tr>
							<td colspan="3" class="hidden-xs"></td>
							<td class="hidden-xs text-center"><strong>Total: $<%=total.ToString("F") %></strong></td>
							<td><a href="#" class="btn btn-success btn-block">Checkout</a></td>
						</tr>
					</tfoot>
				</table>
</div>
</asp:Content>
