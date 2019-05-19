<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BobbleButt.About" %>

<asp:Content runat="server" ContentPlaceHolderID="Main"> 

  
<div class="container-fluid text-center">    
  <div class="row content">
      <!-- Have two coloumns so that text will be in one and an image in the other -->
    <div class="col-sm-2 sidenav">
        <!-- Doctor strange Image -->
      <img src="img/doctorStrange.png" class="pad-from-navbar  pad-from-footer" style="max-height:100%; max-width:100%"/>
    </div>
      <!-- Second coloumn -->
    <div class="col-sm-10 text-left pad-from-footer pad-from-navbar"> 
      <h2 class="blue-text">About Bobble Butt</h2>
      <h3 class="blue-text">What we do</h3>
     <!-- Text About Us-->
      <p>Bobble Butt is all about sharing what we love the most, Bobbleheads. A bobble head is a figurine that can be based on many things 
        including characters from movies, video games, comics, sports and a lot more. The meaning of bobblehead is in the name itself, 
        which is having an extra-large head compared to the body that can move and bobble around. </p>
      <p>With a wide range of products available for you to choose from we guarantee that our bobbleheads come in pristine condition. 
        We deliver straight to you and can provide many bobblehead characters based on Marvel comics, DC comics, video games, 
        movies and sports. At Bobble Butt our main aim is to provide YOU with a pleasant experience.</p>
    </div>
  </div>
</div>

</asp:Content>
