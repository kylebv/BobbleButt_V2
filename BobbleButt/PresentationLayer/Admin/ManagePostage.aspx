<%@ Page Title="" Language="C#" MasterPageFile="../PageHeader.Master" AutoEventWireup="true" CodeBehind="ManagePostage.aspx.cs" Inherits="BobbleButt.ManagePostage" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <script type="text/javascript">
    </script>
    <div id="viewItemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0">
                    <thead>
                        <tr>
                            <th>ID #</th>
                            <th class="text-left">NAME</th>
                            <th class="text-right">PRICE</th>
                            <th class="text-right">DESCRIPTION</th>
                            <th class="text-right">ETA</th>
                            <th class="text-right">UPDATE</th>
                            <th class="text-right">DELETE</th>

                        </tr>
                    </thead>
                    <tbody>
                    <%  foreach (PostageOptions p in options)
                        {                           
                                %>
                            <!-- Add postage name to table -->
                    <tr>
                            <td class="no"><%=p.ID %></td>
                            <td class="text-right">
                                <p><%=p.Name %></p>
                                
                            </td>
                            
                                
                           <!-- Add postage price -->
                            <td class="text-right">
                                <p><%=p.Price.ToString("F") %></p>
                                
                            </td>
                          <td class="text-right">
                                <p><%=p.Description %></p>
                                
                            </td>
                         <td class="text-right">
                                <p><%=p.ETA %></p>
                                
                            </td>
                            <!-- Update Button -->
                            <td class="text-right">
                                <input type="button" class="btn btn-success" onclick="window.location.href='UpdatePostage?postage=<%=p.Name%>'; return false" value="Update"/>
                            </td>
                        <%String s = "DELETE";
                            String cl = "btn-danger";
                            if (p.IsDeleted)
                            {
                                s = "RESTORE";
                                cl = "btn-success";
                            }%>
                            <!-- Delete Button -->
                            <td class="text-right">
                                <input type="button" onclick="window.location.href='ManagePostage?delete=<%=p.ID%>'; return false" class="btn <%=cl %>" value="<%=s %>"/>
                            </td>
                     </tr>
                        <% } %>
</tbody>
                    
                </table>
                
                <input type="button" onClick="window.location.href = 'UpdatePostage';return false" class="btn btn-success" value="Add New"/>
        </div>

    </div>
</div>
</asp:Content>
