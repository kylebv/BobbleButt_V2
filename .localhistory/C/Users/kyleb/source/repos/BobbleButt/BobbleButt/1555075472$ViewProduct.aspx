<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BobbleButt.About" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content ID="ViewContent2" ContentPlaceHolderID="Main" runat="server">
    <script type="text/javascript">
        function deleteList() {
            
            $(globa).remove(); 
        }
    </script>
    <div id="viewItemlist">

    
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0">
                    <thead>
                        <tr>
                            <th>ID #</th>
                            <th class="text-left">NAME</th>
                            <th class="text-right">CATEGORY</th>
                            <th class="text-right">STOCK</th>
                            <th class="text-right">DESCRIPTION</th>
                            <th class="text-right">PRICE</th>
                            <th class="text-right">IMAGE</th>
                            <th class="text-right">QUANTITY</th>
                            <th class="text-right">UPDATE</th>
                            <th class="text-right">DELETE</th>

                        </tr>
                    </thead>
                    <tbody>
                    <% int count = 0;
                        

                         
                        foreach (Product p in GlobalData.productList)
                        {
                            count++;

                            //if (user == null && order == null)
                                %>

                    <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=p.Name %></p>
                                
                            </td>
                            
                                
                           
                            <td class="text-left">
                                <p><%=p.Category %></p>
                                
                            </td>
                            <!--<td class="unit">-->
                                
                            
                            
                            <td class="text-left">
                                <p><%=p.Stock %></p>
                                
                            </td>
                            <!--<td class="unit">-->
                                
                            <td class="text-left">
                                <p><%=p.Description %></p>
                            </td>
                            
                            <td class="text-left">
                                <p><%=p.Price %></p>
                            </td>
                                
                            <!--<td class="unit">-->
                            
                           
                            <td class="text-left">
                                <p><%=p.Image %></p>
                            </td>
                            
                                <!--<td class="unit">-->
                            
                            
                            <td class="text-left">
                                <p><%=p.Quantity %></p>
                            </td>

                            <td class="text-left">
                                <input type="button" class="btn btn-success" onclick="window.location.href='ViewProduct.aspx?mode=UpdateItem&product=<%=GlobalData.productList.IndexOf(p)%>'; return false" value="UPDATE"/>
                            </td>

                            <td class="text-left">
                                <input type="button" onclick="window.location.href='ViewProduct.aspx?mode=DeleteItem&product=<%=GlobalData.productList.IndexOf(p)%>'; return false" class="btn btn-success" value="DELETE"/>
                                
                            </td>
                     </tr>
                        <% } %>
</tbody>
                    
                </table>
                

        </div>

    </div>
</div>
                            
</asp:content>