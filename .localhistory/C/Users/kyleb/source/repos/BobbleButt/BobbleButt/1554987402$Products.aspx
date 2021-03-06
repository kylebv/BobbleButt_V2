﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BobbleButt.Products" %>
<%@ Import Namespace="BobbleButt" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container pad-from-navbar">
    <div class="row">
        <div class="col-12 col-sm-3">
            <div class="card bg-light mb-3">
                <div class="card-header bg-secondary text-white text-uppercase"><i class="fa fa-list"></i> Categories</div>
                <ul class="list-group category_block">
                    <li class="list-group-item"><a href="category.html">Cras justo odio</a></li>
                    <li class="list-group-item"><a href="category.html">Dapibus ac facilisis in</a></li>
                    <li class="list-group-item"><a href="category.html">Morbi leo risus</a></li>
                    <li class="list-group-item"><a href="category.html">Porta ac consectetur ac</a></li>
                    <li class="list-group-item"><a href="category.html">Vestibulum at eros</a></li>
                </ul>
            </div>
            
        </div>
        <div class="col">
            <div class="row">
                <%foreach (Product p in GlobalData.productList)
                    {
                   %>
                <div class="col-12 col-md-6 col-lg-4 card-deck pad-from-footer">
                    <div class="card">
                        <img class="product-list-img" src="<%=p.Image %>" alt="Card image cap">
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title"><a href="Product?<%=GlobalData.productList.IndexOf(p) %>" title="View Product"><%=p.Name %></a></h4>
                            <p class="card-text"><%=p.Description %></p>
                            <div class="mt-auto">
                                <%if (p.Stock > 0)
                                    { %>
                            <p class="price-card">$<%=p.Price.ToString("F") %></p>
                            <asp:Button runat="server" Text="Add to Cart" href="#" class="btn btn-success shadow btn-block"/>
                                <%}
    else
    { %>
                                <p class="price-card">Out of Stock</p>
                            <asp:Button runat="server" Enabled="false" OnClick="btnCart_Click" Text="Add to Cart" class="btn btn-success shadow btn-block"/>
                                </div>
                            <%} %>
                            
                        </div>
                    </div>
                </div>
                <%} %>
                
                
            </div>
        </div>

    </div>
</div>


</asp:Content>
