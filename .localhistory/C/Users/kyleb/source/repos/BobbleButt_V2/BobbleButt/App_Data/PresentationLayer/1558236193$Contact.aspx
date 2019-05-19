<%@ Page Title="" Language="C#" MasterPageFile="~/PageHeader.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BobbleButt.Contact" %>

<asp:Content runat="server" ContentPlaceHolderID="Main"> 


     <div class="contact-row">
         <!-- Create 3 different coloumns so that address, email and phone will be in there own coloumn-->
        <div class="contact-column pad-from-footer">
            <!-- Address -->
            <img src="img/addressSymbol.png" class="contact-image-centre pad-from-navbar"/>
            <h2 class="contact-text-contacts blue-text">ADDRESS</h2>
            <address style="text-align:center; color:darkgray" class="contact-image-centre">
                <strong>Bobblehead Office</strong> <br/>
                72 Hart Street <br/>
                OMADALE, New South Wales 2261
            </address>
        </div>
        <div class="contact-column pad-from-footer">
            <!-- Phone -->
            <img src="img/phoneSymbol.png" class="contact-image-centre pad-from-navbar"/>
            <h2 class="contact-text-contacts blue-text">PHONE</h2>
            <p class="contact-text-contacts"> <strong>Bobblehead Office</strong></p>
            <p class="contact-text-contacts"> Phone: (02) 4945 2276</p>
            <p class="contact-text-contacts"> <strong>Bobblehead Help</strong></p>
            <p class="contact-text-contacts"> Phone: (02) 3954 2326</p>
            <p class="contact-text-contacts"> <strong>Bobblehead Kyle</strong></p>
            <p class="contact-text-contacts"> Phone: (02) 2923 4324</p>
            <p class="contact-text-contacts"> <strong>Bobblehead Robert</strong></p>
            <p class="contact-text-contacts"> Phone: (02) 1342 5346</p>
        </div>
         <!-- Email -->
        <div class="contact-column pad-from-footer">
            <img src="img/emailSymbol.png" class="contact-image-centre pad-from-navbar"/>
            <h2 class="contact-text-contacts blue-text">EMAIL</h2>
            <p class="contact-text-contacts"> <strong>Help Email</strong></p>
            <p class="contact-text-contacts"> BobbleButtHelp@gmail.com</p>
            <p class="contact-text-contacts"> <strong>Kyle Email</strong></p>
            <p class="contact-text-contacts"> BobbleButtKyle@gmail.com</p>
            <p class="contact-text-contacts"> <strong>Robert Email</strong></p>
            <p class="contact-text-contacts"> BobbleButtRobert@gmail.com</p>
        </div>
     </div>
 </asp:Content>


