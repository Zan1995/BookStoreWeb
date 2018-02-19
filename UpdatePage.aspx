<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdatePage.aspx.cs" Inherits="UpdatePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form1" Runat="Server">
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


    <form id="form2" runat="server">
        <br />
        <div class="container" style="max-width:95%">
        <div> 
            <div class="form-group" style="width:20%">          
                <asp:DropDownList CssClass="form-control" ID="ddlField" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlField_SelectedIndexChanged">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Title</asp:ListItem>
                    <asp:ListItem>ISBN</asp:ListItem>
                    <asp:ListItem>Category</asp:ListItem>
                </asp:DropDownList> 
            </div> 
            <div class="input-group" style="width:50%">                              
               <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" CssClass="form-control"
                   OnTextChanged="txtSearch_TextChanged"></asp:TextBox>                             
            </div>
            <div class="input-group" style="width:30%">                              
               <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" CssClass="form-control"
                   OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>                            
            </div>
            
        </div>
        <br />
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="btn-group">
                <asp:Button ID="btnShow"  CssClass="btn btn-primary" runat="server" Text="Add Book"/>
            </div>
            <p></p>
            <!-- ModalPopupExtender -->
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID = "btnShow"
                OnLoad = "btnShow_Click" BackgroundCssClass ="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" align="center" style="display:none" CssClass ="modalPopup">
                <div class="modal-header">
                    <h3 class ="modal-title">Add New Book</h3>     
                    <p></p>               
                </div>                
                <div class="form-group">
                    <label>Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" 
                        style="width:80%"></asp:TextBox>
                    <asp:Label ID="lblTitle" runat="server" CssClass="text-danger" Text=""></asp:Label>                 
                                                       
                </div>
                <div class="form-group ">
                    <asp:Label ID="Label10" runat="server" Text="Label">ISBN</asp:Label>
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"
                        style="width:80%"></asp:TextBox>
                    <asp:Label ID="lblISBN" runat="server" CssClass="text-danger" Text=""></asp:Label>
                 </div>
                <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Label">Category</asp:Label>
                    <asp:DropDownList ID="ddlCat" runat="server" CssClass="form-control"
                        style="width:80%"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Label">Author</asp:Label>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"
                        style="width:80%"></asp:TextBox>
                    <asp:Label ID="lblAuthor" runat="server" CssClass="text-danger" Text=""></asp:Label>
                </div>
                <div class="container" style="width:80%;">
                    <div class="row">
                        <div class="form-group" style="width:33%; padding:10px;">
                            <asp:Label ID="Label13" runat="server" Text="Label">Price</asp:Label>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblPrice" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        </div>
                        <div class="form-group" style="width:33%; padding:10px;">
                            <asp:Label ID="Label14" runat="server" Text="Label">Stock</asp:Label>
                            <asp:DropDownList ID="ddlStock" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group" style="width:33%; padding:10px;">
                            <asp:Label ID="Label15" runat="server" Text="Label">Discount</asp:Label>
                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblDiscount" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        </div> 
                     </div>
                </div>  
                <div class="modal-footer">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" 
                        OnClick="btnAdd_Click"/>
                    <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" 
                        OnClick ="btnCancel_Click" Text="Cancel" />   
                    <br />
                    <asp:Literal ID="litAdded" runat="server"></asp:Literal>                    
                </div>               
            </asp:Panel>
            <!-- ModalPopupExtender -->
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  
                CellPadding="5" CellSpacing="1"
                DataKeyNames="BookID" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
                OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" >
                <HeaderStyle HorizontalAlign="Center" />
                <PagerStyle HorizontalAlign="Center" Width ="1em"/>
                <%--<%-- OnRowDataBound="OnRowDataBound" %>--%>
                <Columns>                    
                    <asp:TemplateField HeaderText="BookID" SortExpression="BookID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="8%" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ISBN">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="17%" HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock">
                        <EditItemTemplate>
                            <div class="input-group">                              
                              <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>                              
                            </div>                            
                            <br />                         
                            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                                 ControlToValidate="txtStock" ErrorMessage="Value must be a whole number" />
                        </EditItemTemplate>                        
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <div class="input-group">                              
                              <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>                              
                            </div>                              
                            <br />  
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ControlToValidate="txtPrice" 
                                ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$"
                                ErrorMessage="Price must be in currency format"
                                ForeColor ="red">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" 
                                Text='<%#Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Discount">
                        <EditItemTemplate>
                            <div class="input-group">                              
                              <asp:TextBox ID="txtDiscount" CssClass="form-control" runat="server"></asp:TextBox>                              
                            </div>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                runat="server" ControlToValidate="txtDiscount" 
                                ValidationExpression="^[0-9]{2}$"
                                ErrorMessage="Discount can only be maximum 2 digits"
                                 ForeColor ="red">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:TemplateField>                   
                        
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" 
                         ControlStyle-CssClass ="btn btn-outline-primary"
                          ShowDeleteButton ="True" ControlStyle-Height="3em" 
                         CancelImageUrl ="icons/icon_cancel.png" ItemStyle-Width="20%" 
                        ItemStyle-HorizontalAlign ="Center"/>                        
                </Columns>
            </asp:GridView>            
            <br />
            <asp:Literal ID="litNoResults" runat="server"></asp:Literal>
        </div>
            </div>
    </form>
</asp:Content>

