<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">
    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .size3 {float:left;width:23%;
                display:block;
                margin:0 15px 0 15px
        }

    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div style="text-align:center">
       <br /> 
        <asp:RadioButtonList ID="RadioButtonListSearchOption" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="auto-style1" OnSelectedIndexChanged="RadioButtonListSearchOption_SelectedIndexChanged" Width="420px" Font-Bold="True">
            <asp:ListItem>Title</asp:ListItem>
            <asp:ListItem>Author</asp:ListItem>
            <asp:ListItem Value="Category">Category</asp:ListItem>
        </asp:RadioButtonList>
        
        <br />
         <asp:DropDownList ID="DropDownListSearchOption" runat="server" OnSelectedIndexChanged="DropDownListSearchOption_SelectedIndexChanged" AutoPostBack="True" Height="32px">
          
        </asp:DropDownList>
       
        <asp:TextBox ID="TextBoxSearch" runat="server" Width="398px" Height="28px"></asp:TextBox>
       
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="SearchButton_Click" Height="32px" />
         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Search box can'nt Empty" ForeColor="Red"
            ControlToValidate="TextBoxSearch"></asp:RequiredFieldValidator>--%>

        <br />
        <br />
        <br />
        <br />
        <br />
         </div>
       <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
           
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
            
            <HeaderTemplate>

        </HeaderTemplate>
        <ItemTemplate>
             <div class="size3" style="text-align:center">
        <table border="0" style="width: 330px;height:400px"  >
            <tr>
                <td >
                    <image src="images/<%# Eval("ISBN") %>.jpg" width="100" height="120" ></image>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1"  CommandName="Details" runat="server">
                        
                        Details
                    </asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td>
                   Title:
                <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' />
            </td>
             </tr>
            <tr>
               <td>
                   Author:
               
           
                <asp:Label ID="Author" runat="server" Text='<%# Eval("Author") %>' />
            </td>
            </tr>
            <tr>
                 <td>
                   Price:
                <asp:Label ID="Label2" runat="server" Text="Label">S$</asp:Label>
          
                <asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>' />
            </td>
            </tr>

             <tr style="display:none">
                 <td >   
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("BookID") %>' />
            </td>
            </tr>
        </table>
            
                 </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>


        </asp:Repeater>
           </asp:Panel>
       
      
   
    </form>
</body>
    <style>
        .auto-style1 {
            margin-left: 808px;
        }
        </style>
</html>

</asp:Content>

    