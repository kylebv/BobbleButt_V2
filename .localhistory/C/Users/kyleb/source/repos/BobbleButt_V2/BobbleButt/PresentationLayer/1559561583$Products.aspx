<%@ Page Title="" Language="C#" MasterPageFile="PageHeader.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BobbleButt.Products" %>
<%@ Import Namespace="BobbleButt" %>
<%@ Import Namespace="BobbleButt.BusinessLayer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container pad-from-navbar">
    <div class="row">
        <div class="col-12 col-sm-3">
            <div class="card bg-light mb-3">
                <div class="card-header bg-secondary text-white text-uppercase"><i class="fa fa-list"></i> Categories</div>
                <ul class="list-group category_block">
                    <%foreach (string s in categories)
                        { %>
                    <li class="list-group-item"><a href="Products.aspx?category=<%=s %>"><%=s %></a></li>
                    <%} %>
                </ul>
            </div>
            
        </div>
        <div class="col">
            <div class="row">
                <%//Get all the products in the list
                    foreach (Product p in products)
                    {
                   %>
                <div class="col-12 col-md-6 col-lg-4 card-deck pad-from-footer">
                    <div class="card">
                        <!-- Add image of product -->
                        <img class="product-list-img" src="<%=p.Image %>" alt="Card image cap">
                        <div class="card-body d-flex flex-column">
                           <!-- Name of product -->
                           <h4 class="card-title"><a href="/PurchaseProduct.aspx?PassingValue=<%=p.ID %>" title="View Product"><%=p.Name %></a></h4>
                            <!-- Description of product -->
                            <p class="card-text"><%=p.Description %></p>
                            <div class="mt-auto">
                                <!-- Product is in stock -->
                                <%if ( p.Stock > 0)
                                    { %>
                            <!-- Price of product -->
                            <p class="price-card">$<%=p.Price.ToString("F") %></p>
                            <!-- Add to cart Button -->
                            <button type="submit"  value="Add to Cart" onclick="window.location.href='/Products.aspx?addItem=<%= p.ID %>'; return false" class="btn btn-success shadow btn-block">Add to Cart</button>
                                <%}
                                    // Disable add to cart button if out of stock
                                    else
                                    { %>
                                <p class="price-card">Out of Stock</p>
                            <button type="submit" disabled value="Add to Cart" class="btn btn-success shadow btn-block"/>
                                
                            <%} %>
                            </div>
                        </div>
                    </div>
                </div>
                <%}
                    if (products.Count==0)
                    {%>
                <p>No products found in search.</p>
                <%} %>
                
                
            </div>
        </div>

    </div>
</div>


</asp:Content>
