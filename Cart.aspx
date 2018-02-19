<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" runat="Server">
    <br />
    <form id="form1" runat="server">
        <br />
        <asp:label id="lblSuccess" runat="server" text="Your cart is ready" font-size="X-Large" forecolor="#006600"></asp:label>
        <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False"
            datakeynames="Title"
            onrowediting="GridView1_RowEditing"
            onrowupdating="GridView1_RowUpdating"
            onrowdeleting="OnRowDeleting"
            onrowcancelingedit="OnRowCancelingEdit" cellpadding="2" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ReadOnly="True" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" ReadOnly="True" />
                <asp:BoundField DataField="Stock" HeaderText="Number in stock" SortExpression="Price" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxQ" runat="server" Text='<%# Bind("BookQuant") %>'></asp:TextBox>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQ" runat="server" Text='<%# Bind("BookQuant")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>

                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ReadOnly="True" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Discount" HeaderText="Discount(%)" SortExpression="Discount" ReadOnly="True" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Total ($)" >
                    <ItemTemplate>
                        <asp:Label ID="lblCompute" runat="server" ReadOnly="True"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Button" ShowEditButton="True" EditImageUrl="~/App_LocalResources/DeleteButton.jpg" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteImageUrl="~/App_LocalResources/DeleteButton.jpg" />

                
            </Columns>

        </asp:gridview>
        <br />
        <br />
        <br />

        <table>
            <tr>
                <td>Total Amount ($)</td>
                <td>
                    <asp:textbox id="tbxTotal" style="text-align: right" runat="server" width="625px" enabled="False" backcolor="White" enabletheming="True" forecolor="#006600"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>Discount ($)</td>
                <td>
                    <asp:textbox id="tbxDiscount" style="text-align: right" runat="server" width="625px" enabled="False" backcolor="White" forecolor="#006600"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>Total Amount After Discount ($)</td>
                <td>
                    <asp:textbox id="tbxAfterDiscount" style="text-align: right" runat="server" width="625px" enabled="False" backcolor="White" forecolor="#006600" font-size="X-Large"></asp:textbox>
                </td>
            </tr>

        </table>

        <br />
        <asp:button runat="server" text="Order" id="btnOrder" onclick="btnOrder_Click" />
    </form>

</asp:Content>

