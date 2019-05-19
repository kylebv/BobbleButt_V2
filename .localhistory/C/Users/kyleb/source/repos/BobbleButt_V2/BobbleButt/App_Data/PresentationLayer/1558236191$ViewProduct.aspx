<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="BobbleButt.ViewProduct" %>
<%@ Import Namespace="BobbleButt" %>
<asp:Content ID="ViewContent2" ContentPlaceHolderID="Main" runat="server">
    <script type="text/javascript">
        function addNew() {
              //Go to Insert new product page
              window.location.href = 'ManageItems.aspx';
        }
    </script>
    <div id="viewItemlist">
    <div class="itemlist overflow-auto">
        <div style="min-width: 600px">
           
                <table border="0">
                    <thead>
                        <tr>
                            <!-- The names of all the headings in the table -->
                            <th>ID #</th>
                            <th class="text-left">NAME</th>
                            <th class="text-right">CATEGORY</th>
                            <th class="text-right">STOCK</th>
                            <th class="text-right">DESCRIPTION</th>
                            <th class="text-right">PRICE</th>
                            <th class="text-right">IMAGE</th>
                            <th class="text-right">UPDATE</th>
                            <th class="text-right">DELETE</th>

                        </tr>
                    </thead>
                    <tbody>
                    <% int count = 0;
                        

                        //Goes through each product and adds them to the page 
                        foreach (Product p in GlobalData.productList)
                        {
                            //Keeps track of the ID number for the page
                            count++;

                           
                                %>
                        <!-- Adds the product name to the page -->
                    <tr>
                            <td class="no"><%=count %></td>
                            <td class="text-left">
                                <p><%=p.Name %></p>
                                
                            </td>
                            
                                
                           <!-- Adds product Category -->
                            <td class="text-left">
                                <p><%=p.Category %></p>
                                
                            </td>
 
                            
                            <!-- Adds product stock -->
                            <td class="text-left">
                                <p><%=p.Stock %></p>
                                
                            </td>
                          
                            <!-- Adds product description -->    
                            <td class="text-left">
                                <p><%=p.Description %></p>
                            </td>
                            
                            <!-- Adds product price -->
                            <td class="text-left">
                                <p><%=p.Price %></p>
                            </td>
                                
                         
                            
                            <!-- Image name NOT the actual image -->
                            <td class="text-left">
                                <p><%=p.Image %></p>
                            </td>
                            

                            <!-- Send product value back to ViewProduct so that product equals the value of current product  -->
                            <td class="text-left">
                                <input type="button" class="btn btn-success" onclick="window.location.href='ViewProduct.aspx?mode=UpdateItem&product=<%=GlobalData.productList.IndexOf(p)%>'; return false" value="UPDATE"/>
                            </td>
                            
                            <!-- Send back product value to ViewProduct -->
                            <td class="text-left">
                                <input type="button" onclick="window.location.href='ViewProduct.aspx?mode=DeleteItem&product=<%=GlobalData.productList.IndexOf(p)%>'; return false" class="btn btn-danger" value="DELETE"/>
                                
                            </td>
                     </tr>
                        <% } %>
</tbody>
                 <!-- Add new item button -->  
                </table>
                
                <input type="button" onClick="addNew()" class="btn btn-success" value="ADD NEW"/>
        </div>

    </div>
</div>
                            
</asp:content>