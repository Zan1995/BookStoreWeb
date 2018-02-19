<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DetailPage.aspx.cs" Inherits="DetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">

    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .right {
            float: right;
            width: 60%;
            padding: 10px;
        }
         .left {float:left;
                width:40%;
                padding:10px;
        }

        .auto-style1 {
            border-style: hidden;
            border-color: inherit;
            border-width: medium;
            float: left;
            width: 34%;
            padding: 10px;
            height: 374px;
        }

        .auto-style2 {
            margin-left: 101px;
            margin-top: 52px;
        }

        .auto-style3 {
            margin-top: 0px;
        }

        .auto-style4 {
            height: 80px;
        }
        .auto-style5 {
            width: 822px;
            height: 400px;
        }

    </style>
</head>
<body>
    <br /> <br /> <br />
    <form id="form1" runat="server">
    <div class="auto-style1">
        <asp:Image ID="Image1" runat="server" align="middle" CssClass="auto-style2" Height="285px" Width="231px"/>
    </div>
    <div class="right">
        <br /> 
         <table border="0" class="auto-style5"  >
            <tr>
                <td >
                    Title
                </td>
                <td>
                    <asp:Label ID="LabelTitleName" runat="server" ></asp:Label>
                </td>
            </tr>
             <tr>
                <td >
                    Author
                </td>
                <td>
                     <asp:Label ID="LabelAuthor" runat="server" ></asp:Label>
                </td>
            </tr>
             <tr>
                <td >
                    CategoryName
                </td>
                <td>
                    <asp:Label ID="LabelCategoryName" runat="server" ></asp:Label>
                </td>
            </tr>
              <tr>
                <td >
                    Stock
                </td>
                <td>
                    <asp:Label ID="LabelStock" runat="server" ></asp:Label>
                </td>
            </tr>
              <tr>
                <td class="auto-style4" >
                    Price
                </td>
                <td class="auto-style4">
                    <asp:Label ID="LabelPrice" runat="server" ></asp:Label>
                </td>
            </tr>
             </table>
        <br /> <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add to Cart" CssClass="auto-style3" Font-Size="Medium" Height="57px" Width="152px" />
        </div>
    </form>
</body>
</html>
</asp:Content>

