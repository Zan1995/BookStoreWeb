<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">
            <form id="form1" runat="server">

       <div >
            <asp:login runat="server" Height="304px" Width="478px" CssClass="auto-style10">
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td class="auto-style4">
                        <table cellpadding="0" style="font-size: medium">
                            <tr>
                                <td id="U" align="center" colspan="2" style="font-family: Arial; font-size: xx-large; text-align: left">Log In.<br /> </td>
                            </tr>
                            <tr>
                                <td id="U" align="center" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: large; text-align: left" class="auto-style9">
                                    <br />
                                    Use a local account to log In.<br /> </td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="auto-style7">
                                    <br />
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Bold="True" Font-Size="Medium">User Name:       </asp:Label>
                                </td>
                                <td class="auto-style8">
                                    &nbsp;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl30">*</asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7">
                                    <br />
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Bold="True" Font-Size="Medium"> Password:     </asp:Label>
                                </td>
                                <td class="auto-style8">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl30">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1" colspan="2">
                                    <br />
                                    <asp:Button class="btn btn-outline-primary" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="ctl30" Font-Size="Medium" OnClick="LoginButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        </asp:login>
    </div>
    
    <asp:Label ID="Label1" runat="server" Text="New User?"></asp:Label>
    <p><asp:Button ID="Button1"  runat="server" class="btn btn-primary" Text="Register New User" Height="30px" Width="144px" OnClick="Button1_Click1" /></p>
    </form>
</asp:Content>

