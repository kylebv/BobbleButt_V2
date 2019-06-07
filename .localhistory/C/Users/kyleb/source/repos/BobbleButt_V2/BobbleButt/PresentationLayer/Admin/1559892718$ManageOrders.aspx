<%@ Page Title="" Language="C#" MasterPageFile="../PageHeader.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="BobbleButt.ManageOrders" %>
<%@ Import namespace="BobbleButt" %>
<%@ Import Namespace="BobbleButt.BusinessLayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="itemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0">
                    <thead>
                        <tr>
                            <th>ID #</th>
                            <th class="text-left">USER EMAIL</th>
                            <th class="text-right">PRODUCTS</th>
                            <th class="text-right">DATE</th>
                            <th class="text-right">STATUS</th>
                            <th class="text-right">UPDATE</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%  foreach (Order o in orders)
                            { %>
                        <tr>
                            <td class="no"><%=o.ID %></td>
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <td class="unit">
                                <% foreach (Product p in o.Products)
                                    {
                                      %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <td class="qty"><p><%=o.Date %></p></td>
                            
                            <td class="unit"><p><%=o.Status %></p></td>
                            <%string sent = "Mark as Sent";
                                if (o.Status.Equals("Sent"))
                                {
                                    sent = "Mark as Processing";
                                }
                                String singleFlag = "";
                                if(orders.Count==1)
                                { singleFlag = "&flagSingle=flagged"; }
                                   %>
                            <td class="qty"><input type="button" onclick="window.location.href='ManageOrders.aspx?mode=toggleSent&order=<%=o.ID%><%=singleFlag%>'; return false" class="btn btn-success" value="<%=sent %>" /></td>
                        </tr>
                        <%} %>
                    </tbody>
                    
                </table>
                

        </div>

    </div>
</div>
</asp:Content>
