<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:TextBox runat="server" ID="TbMessage" />
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <h2>Log in to post messages</h2>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnSubmit" Text="Send" OnClick="BtnSubmit_Click" />
        </LoggedInTemplate>
    </asp:LoginView>
    <div class="row">
        <asp:LinkButton CssClass="btn btn-success" Text="Refresh" PostBackUrl="~/Default.aspx" runat="server" />
    </div>

    <asp:ListView runat="server" ID="LvMessages" ItemType="Chat.Models.Message" SelectMethod="LvMessages_GetData">
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
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
