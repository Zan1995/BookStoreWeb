<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    this is owner page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">
    <form id="form1" runat ="server" >
    <asp:Button ID="Button1" runat="server" Text="Log out" OnClick="Button1_Click" /></form>
</asp:Content>

