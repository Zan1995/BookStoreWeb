<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    this is customer page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">
    <form id="form1" runat="server" ><asp:Button ID="Button1" runat="server" Text="Log out" OnClick="Button1_Click" /></form>
</asp:Content>

