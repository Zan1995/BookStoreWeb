<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

<style>
    body, html {
    height: 100%;
}

.parallax { 
    /* The image used */
    background-image: url("Image/img_parallax.jpg");

    /* Full height */
    height: 100%; 

    /* Create the parallax scrolling effect */
    background-attachment: fixed;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
    opacity:0.5;
}

    .auto-style1 {
        font-size: 4.5rem;
        font-weight: 300;
        line-height: 1.2;
        text-align: center;
    }

</style>

<!-- Container element -->
<p style="margin =400px; fill-opacity=0;">
<div class="jumbotron">
  <p class="auto-style1">Team8 BookShop</p>
  <p class="text-center">Bringing wealth of knowledge to you.</p>
   <%-- <p class="text-center"><a class="btn btn-primary btn-lg" href="#container2">Learn more</a></p>--%>
    </div>
</p>

<%--<p style="margin-bottom:400px;">
<div class="jumbotron" id="container2">
  <h1 class="auto-style1">Knowledge is POWER</h1>
  <p class="text-center">We host an extensive collection of books that will satisfy your hunger for more knowledge!</p>   
</div>
  </p> --%>

<div class="parallax"></div>



</asp:Content>


