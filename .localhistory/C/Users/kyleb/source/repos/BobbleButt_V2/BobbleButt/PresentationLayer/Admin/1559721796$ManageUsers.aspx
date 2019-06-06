<%@ Page Title="" Language="C#" MasterPageFile="../PageHeader.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="BobbleButt.Admin_Users" %>
<%@Import namespace="BobbleButt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="itemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
                <!-- Creating a table for the admin to view user order details -->
                <table border="0">
                    <thead>
                        <tr>
                             <!-- Headings for each of the coloumns that will include releted data below -->
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
                            // Will go through all the users existing and count them
                            foreach (KeyValuePair<string,User> u in GlobalData.userMap)
                            {
                                count++;%>
                        <tr>
                            <%--Add in the count for the ID coloumn for the amount of users existing--%>
                            <td class="no"><%=count %></td>
                            <!-- Add in the user emails to the email column -->
                            <td class="text-left">
                                <p><%=u.Value.Email %></p>
                                
                            </td>
                            <td class="unit">
                                <%
    //Go through all the orders in a list and add them to the order coloumn for a specfic user
    foreach (Order o in GlobalData.Orders) {
        //Checks to see if the user email equals the current user email in table so that the orders are related to a user
        if (o.UserEmail.Equals(u.Value.Email))
        {%>
                               <!-- Take user to a new page with the order details listed -->
                               <a href="Orders.aspx?order=<%=GlobalData.Orders.IndexOf(o) %>"><%=o.Date %></a><br />
                                <%} } %>

                            </td>
                            <!-- Display value of suspension "True" or "False" -->
                            <td class="qty"><p><%=u.Value.IsSuspended %></p></td>
                            <!-- Value for button text  -->
                            <%string suspended = "Suspend";
                                if (u.Value.IsSuspended)
                                {
                                    suspended = "Unsuspend";
                                }%>
                            <!-- Button to suspend a user with text value equalling above string -->
                            <td class="unit"><input type="button" onclick="window.location.href='Admin_Users.aspx?mode=toggleSuspend&user=<%=u.Value.Email%>'; return false" class="btn btn-success" value="<%=suspended %>" /></td>
                            <!-- Button to delete a user -->
                            <td class="qty"><input type="button" onclick="window.location.href='Admin_Users.aspx?mode=delete&user=<%=u.Value.Email%>'; return false" class="btn btn-danger" value="Delete" /></td>
                        </tr>
                        <%} %>
                       
                    </tbody>
                    
                </table>
                

        </div>

    </div>
</div>
</asp:Content>
