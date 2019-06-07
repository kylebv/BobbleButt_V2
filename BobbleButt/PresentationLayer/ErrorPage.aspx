<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/PageHeader.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="BobbleButt.PresentationLayer.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

        <div class="container login-container">
            <div class="row">
                <div class="col-md-12 login-form-1">
                    <!-- Login fields displayed -->
                    <h3>Whoops an Error Occured</h3>
                        <!-- Email -->
                        <div class="form-group">
                            <p> An error has occured while using the Bobblehead site: 
                            </p>
                            <strong><asp:Label runat="server" ID="lblErrorMessage"></asp:Label></strong>
                        </div>
                      
                </div>
            </div>
        </div>

</asp:Content>
