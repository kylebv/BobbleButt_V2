<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Admin_Users.aspx.cs" Inherits="BobbleButt.Admin_Users" %>
<%@Import namespace="BobbleButt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="itemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <th>ID #</th>
                            <th class="text-left">USER EMAIL</th>
                            <th class="text-right">ORDERS</th>
                            <th class="text-right">SUSPENDED</th>
                            <th class="text-right">UPDATE</th>
                            <th class="text-right">DELETE</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% int count = 0;
                            foreach (KeyValuePair<string,User> u in GlobalData.userMap)
                            {
                                count++;%>
                        <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left"><h3>
                                <p><%=u.Value.Email %></p>
                                
                            </td>
                            <td class="unit">
                                <%
    foreach (Order o in GlobalData.Orders) {
        if (o.UserEmail.Equals(u.Value.Email))
        {%>
                               <a href="Orders.aspx?order=<%=GlobalData.Orders.IndexOf(o) %>"><%=o.Date %></a>
                                <%} } %>

                            </td>
                            <td class="qty"><input type="checkbox" checked="<%=u.Value.IsSuspended %>"/></td>
                            <td class="unit"><input type="button" class="btn btn-success" value="Update" /></td>
                            <td class="qty"><input type="button" class="btn btn-danger" value="Delete" /></td>
                        </tr>
                        <%} %>
                       
                    </tbody>
                    
                </table>
                

        </div>

    </div>
</div>
</asp:Content>
