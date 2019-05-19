<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BobbleButt.Products" %>
<%@ Import Namespace="BobbleButt" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container pad-from-navbar">
    <div class="row">
        <div class="col-12 col-sm-3">
            <div class="card bg-light mb-3">
                <div class="card-header bg-secondary text-white text-uppercase"><i class="fa fa-list"></i> Categories</div>
                <ul class="list-group category_block">
                    <%foreach (string s in GlobalData.categoryList)
                        { %>
                    <li class="list-group-item"><a href="Products.aspx?category=<%=s %>"><%=s %></a></li>
                    <%} %>
                </ul>
            </div>
            
        </div>
        <div class="col">
            <div class="row">
                <%int searchFailureCount = 0;
                    foreach (Product p in GlobalData.productList)
                    {
                        if (Request.QueryString["search"] == null && Request.QueryString["category"] == null)
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
                            <button type="submit"  value="Add to Cart" onclick="window.location.href='/Products.aspx?addItem=<%= GlobalData.productList.IndexOf(p) %>'; return false" class="btn btn-success shadow btn-block">Add to Cart</button>
                                <%}
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

                    else if (Request.QueryString["category"] == null && (p.Name.ToLower().Contains(Request.QueryString["search"].ToLower()) || p.Description.ToLower().Contains(Request.QueryString["search"].ToLower()) || p.Category.ToLower().Contains(Request.QueryString["search"].ToLower())))
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
                            <button type="submit"  value="Add to Cart" onclick="window.location.href='/Products.aspx?addItem=<%= GlobalData.productList.IndexOf(p) %>'; return false" class="btn btn-success shadow btn-block">Add to Cart</button>
                                <%}
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
                    else if (Request.QueryString["category"] != null && p.Category.ToLower().Equals(Request.QueryString["category"].ToLower()))
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
                            <button type="submit"  value="Add to Cart" onclick="window.location.href='/Products.aspx?addItem=<%= GlobalData.productList.IndexOf(p) %>'; return false" class="btn btn-success shadow btn-block">Add to Cart</button>
                                <%}
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
                    else if(Request.QueryString["search"]!=null)
                    {
                    %>searchFailureCount++;
                <%}
                    }
                    if (searchFailureCount == GlobalData.productList.Count)
                    {%>
                <p>No products found in search.</p>
                <%} %>
                
                
            </div>
        </div>

    </div>
</div>


</asp:Content>
