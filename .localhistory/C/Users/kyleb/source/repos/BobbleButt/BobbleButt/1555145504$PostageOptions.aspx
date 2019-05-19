<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="PostageOptions.aspx.cs" Inherits="BobbleButt.PostageOptions1" %>
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
                            <th class="text-right">UPDATE</th>
                            <th class="text-right">DELETE</th>

                        </tr>
                    </thead>
                    <tbody>
                    <% int count = 0;
                        

                         
                        foreach (PostageOptions p in GlobalData.postageList)
                        {
                            count++;

                           
                                %>

                    <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=p.Name %></p>
                                
                            </td>
                            
                                
                           
                            <td class="text-left">
                                <p><%=p.Price.ToString("F") %></p>
                                
                            </td>
                            <td class="text-left">
                                <input type="button" class="btn btn-success" onclick="window.location.href='ProductPostage.aspx?postage=<%=GlobalData.postageList.IndexOf(p)%>'; return false" value="Update"/>
                            </td>
                            <td class="text-left">
                                <input type="button" onclick="window.location.href='ViewProduct.aspx?delete=<%=GlobalData.postageList.IndexOf(p)%>'; return false" class="btn btn-danger" value="Delete"/>
                            </td>
                     </tr>
                        <% } %>
</tbody>
                    
                </table>
                
                <input type="button" onClick="window.location.href = 'ProductPostage.aspx';return false" class="btn btn-success" value="Add New"/>
        </div>

    </div>
</div>
</asp:Content>
