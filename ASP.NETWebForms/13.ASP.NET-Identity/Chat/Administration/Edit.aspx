<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Chat.Administration.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="TbMessage" />

    <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnSubmit" Text="Send" OnClick="BtnSubmit_Click" />
    <div class="row">
        <asp:LinkButton CssClass="btn btn-success" Text="Refresh" PostBackUrl="~/Administration/Edit.aspx" runat="server" />
    </div>

    <asp:ListView runat="server" ID="LvMessages" ItemType="Chat.Models.Message" SelectMethod="LvMessages_GetData" UpdateMethod="LvMessages_UpdateItem" DeleteMethod="LvMessages_DeleteItem" DataKeyNames="Id">
        <LayoutTemplate>
            <h2>Messages:</h2>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="row">
                    by <%#: Item.Author.FirstName %> <%#: Item.Author.LastName %>, dated <%# Item.DatePublished %>:
                </div>
                <h6 class="row">
                    <%#: Item.Content %>
                </h6>
                <div class="row">
                    <asp:Button CssClass="btn btn-primary" runat="server" ID="BtnEdit" CommandName="Edit" Text="Edit" />
                    <asp:Button CssClass="btn btn-danger" runat="server" ID="BtnDelete" CommandName="Delete" Text="Delete" />
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                by <%#: Item.Author.FirstName %> <%#: Item.Author.LastName %>, dated <%# Item.DatePublished %>:
            </div>
            <h6 class="row">
               <asp:TextBox Text="<%# BindItem.Content %>" runat="server" ID="MsgEdit" TextMode="MultiLine" ></asp:TextBox>
            </h6>
             <div class="row">
                    <asp:Button CssClass="btn btn-primary" runat="server" ID="BtnUpdate" CommandName="Update" Text="Update" />
                    <asp:Button CssClass="btn btn-danger" runat="server" ID="BtnDelete" CommandName="Cancel" Text="Cancel" />
                </div>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
