<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="BobbleButt.Orders" %>
<%@Import namespace="BobbleButt" %>
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
                        <% int count = 0;
                            foreach (Order o in GlobalData.Orders)
                            {
                                count++;
                                if (user == null && order == null)
                                {%>
                        <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <td class="unit">
                                <%
                                    foreach (Product p in o.Products)
                                    {
        %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <td class="qty"><p><%=o.Date %></p></td>
                            
                            <td class="unit"><p><%=o.Status %></td>
                            <%string sent = "Mark as Sent";
                                if (o.Status.Equals("Sent"))
                                {
                                    sent = "Mark as Processing";
                                }%>
                            <td class="qty"><input type="button" onclick="window.location.href='Orders.aspx?mode=toggleSent&order=<%=GlobalData.Orders.IndexOf(o)%>'; return false" class="btn btn-success" value="<%=sent %>" /></td>
                        </tr>
                        <%}
                            else if (mode == null && user == null)
                            {
                                if (Convert.ToInt32(order) == GlobalData.Orders.IndexOf(o))
                                {%>
                        <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <td class="unit">
                                <%
                                    foreach (Product p in o.Products)
                                    {

        %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <td class="qty"><p><%=o.Date %></p></td>
                            
                            <td class="unit"><p><%=o.Status %></td>
                            <%string sent = "Mark as Sent";
                                if (o.Status.Equals("Sent"))
                                {
                                    sent = "Mark as Processing";
                                }%>
                            <td class="qty"><input type="button" onclick="window.location.href='Orders.aspx?mode=toggleSent&order=<%=GlobalData.Orders.IndexOf(o)%>'; return false" class="btn btn-success" value="<%=sent %>" /></td>
                        </tr>
                        <%}
                            }
                            else if (mode == null && order == null)
                            {
                                if (user.Equals(o.UserEmail))
                                {%>
                        <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <td class="unit">
                                <%
                                    foreach (Product p in o.Products)
                                    {
        %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <td class="qty"><p><%=o.Date %></p></td>
                            
                            <td class="unit"><p><%=o.Status %></td>
                            <%string sent = "Mark as Sent";
                                if (o.Status.Equals("Sent"))
                                {
                                    sent = "Mark as Processing";
                                }%>
                            <td class="qty"><input type="button" onclick="window.location.href='Orders.aspx?mode=toggleSent&order=<%=GlobalData.Orders.IndexOf(o)%>'; return false" class="btn btn-success" value="<%=sent %>" /></td>
                        </tr>
                        <%}
                            }
                            else
                            { %>
                        <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=o.UserEmail %></p>
                                
                            </td>
                            <td class="unit">
                                <%
                                    foreach (Product p in o.Products)
                                    {
        %>
                               <p>Name: <%=p.Name %> Quantity: <%=p.Quantity %></p>
                                <br />
                                <%}  %>

                            </td>
                            <td class="qty"><p><%=o.Date %></p></td>
                            
                            <td class="unit"><p><%=o.Status %></td>
                            <%string sent = "Mark as Sent";
                                if (o.Status.Equals("Sent"))
                                {
                                    sent = "Mark as Processing";
                                }%>
                            <td class="qty"><input type="button" onclick="window.location.href='Orders.aspx?mode=toggleSent&order=<%=GlobalData.Orders.IndexOf(o)%>'; return false" class="btn btn-success" value="<%=sent %>" /></td>
                        </tr>
                        <%}

                            }%>
                       
                    </tbody>
                    
                </table>
                

        </div>

    </div>
</div>
</asp:Content>
