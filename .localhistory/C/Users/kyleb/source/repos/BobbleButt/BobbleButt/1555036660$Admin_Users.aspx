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
                                count++%>
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
                            <td class="total"><input type="button" class="btn btn-success" />Update</td>
                            <td class="total"><input type="button" class="btn btn-success" />Delete</td>
                        </tr>
                        <%} %>
                        <tr>
                            <td class="no">01</td>
                            <td class="text-left"><h3>Website Design</h3>Creating a recognizable design solution based on the company's existing visual identity</td>
                            <td class="unit">$40.00</td>
                            <td class="qty">30</td>
                            <td class="total">$1,200.00</td>
                        </tr>
                        <tr>
                            <td class="no">02</td>
                            <td class="text-left"><h3>Website Development</h3>Developing a Content Management System-based Website</td>
                            <td class="unit">$40.00</td>
                            <td class="qty">80</td>
                            <td class="total">$3,200.00</td>
                        </tr>
                        <tr>
                            <td class="no">03</td>
                            <td class="text-left"><h3>Search Engines Optimization</h3>Optimize the site for search engines (SEO)</td>
                            <td class="unit">$40.00</td>
                            <td class="qty">20</td>
                            <td class="total">$800.00</td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="2"></td>
                            <td colspan="2">SUBTOTAL</td>
                            <td>$5,200.00</td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td colspan="2">TAX 25%</td>
                            <td>$1,300.00</td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td colspan="2">GRAND TOTAL</td>
                            <td>$6,500.00</td>
                        </tr>
                    </tfoot>
                </table>
                <div class="thanks">Thank you!</div>
                <div class="notices">
                    <div>NOTICE:</div>
                    <div class="notice">A finance charge of 1.5% will be made on unpaid balances after 30 days.</div>
                </div>
            </main>
            <footer>
                itemlist was created on a computer and is valid without the signature and seal.
            </footer>
        </div>
        <!--DO NOT DELETE THIS div. IT is responsible for showing footer always at the bottom-->
        <div></div>
    </div>
</div>
</asp:Content>
