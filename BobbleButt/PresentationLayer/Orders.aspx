<%@ Page Title="" Language="C#" MasterPageFile="PageHeader.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="BobbleButt.Orders" %>
<%@Import namespace="BobbleButt" %>
<%@Import namespace="BobbleButt.BusinessLayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="itemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0">
                    <thead>
                        <tr>
                            <!-- Table Headings -->
                            <th>ID #</th>
                            <th class="text-left">USER EMAIL</th>
                            <th class="text-right">PRODUCTS</th>
                            <th class="text-right">DATE</th>
                            <th class="text-right">STATUS</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (Order o in orders)
                            {
                                %>
                        <tr>
                            <!-- Adding ID to table through a count -->
                            <td class="no"><%=o.ID %></td>
                            <!-- Adding user email to table -->
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <!-- Adding the name and quantity of a product -->
                            <td class="unit">
                                <%
                                    foreach (Product p in o.Products)
                                    {
                                 %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <!-- Date of purchase -->
                            <td class="qty">                            
                                <p><%=o.Date %></p></td>
                            
                            <!-- Status of order -->
                            <td class="unit"><p><%=o.Status %></td>
                            </tr>
                        <%}%> 
                       
                    </tbody>
                    
                </table>
                

        </div>

    </div>
</div>
</asp:Content>
