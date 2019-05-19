<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BobbleButt.Main" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script>
    function openModal() {
            $('#myModal').modal('show');
        }
        </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Main"> 

    <div id="myModal" class="modal fade">
	<div class="modal-dialog modal-confirm">
		<div class="modal-content">
			<div class="modal-header">
				<div class="icon-box">
					<i class="material-icons">&#xE876;</i>
				</div>				
				<h4 class="modal-title">Awesome!</h4>	
			</div>
			<div class="modal-body">
				<p class="text-center">Your booking has been confirmed. Check your email for detials.</p>
			</div>
			<div class="modal-footer">
				<button class="btn btn-success btn-block" data-dismiss="modal">OK</button>
			</div>
		</div>
	</div>
</div>
 

<!--https://www.popcultcha.com.au/-->
<div class="col-sm-12">
    <img src="img/mainBackground.png" alt="Image" class="main-central-img">
</div>

  
<h3 class="main-heading-text">Popular Categories</h3>
<div class="container pad-from-navbar">    
  <div class="row">
    <div class="col-sm-4">
      <div class="card"> <!--card-primary-->
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">DC</div>
            <!--https://www.goodfon.com/wallpaper/justice-league-dc-comics-2290.html-->
            <img src="img/DCCategory.png" class="img-responsive main-height-img" style="width:100%;" alt="Image">
            </a>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="card"> 
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">Disney</div>
            <!--https://wall.alphacoders.com/big.php?i=512776-->
            <img src="img/disneyCategory.png" class="img-responsive main-height-img" style="width:100%" alt="Image">
            </a>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="card">
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">Marvel</div>
            <!--https://awallpaperspc.blogspot.com/2018/12/marvel-backgrounds-wallpaper.html-->
            <img src="img/marvelCategory.png" class="img-responsive main-height-img" style="width:100%" alt="Image">
            </a>
      </div>
    </div>
  </div>
</div>




<!--https://www.w3schools.com/bootstrap/tryit.asp?filename=trybs_temp_store&stacked=h-->
<h3 class="main-heading-text">Trending Now</h3>
<div class="container pad-from-navbar">    
  <div class="row">
    <div class="col-sm-4">
      <div class="card main-box-color">
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">Batman</div>
            <div class="card-body">
            <img src="img/batman.png" class="img-responsive main-height-img-product" style="width:100%" alt="Image">
            </div>
            </a>
        <!--<div class="card-footer">Buy 50 mobiles and get a gift card</div>-->
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="card main-box-color">
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">Batwoman</div>
            <div class="card-body">
            <img src="img/batwoman.png" class="img-responsive main-height-img-product" style="width:100%" alt="Image">
            </div>
            </a>
        <!--<div class="card-footer">Buy 50 mobiles and get a gift card</div>-->
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="card main-box-color">
            <a href="contact.aspx">
            <div class="card-header bg-secondary main-text-color main-text-hover">Iron-man</div>
            <!--https://www.popcultcha.com.au/captain-america-civil-war-iron-man-wobbler-bobble-head.html-->
            <div class="card-body">
            <img src="img/ironMan.png" class="img-responsive main-height-img-product" style="width:100%" alt="Image">
            </div>
            </a>
        <!--<div class="card-footer">Buy 50 mobiles and get a gift card</div>-->
      </div>
    </div>
  </div>
</div>

</asp:content>
