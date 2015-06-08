<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="_01.UserProfile.PersonalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Hello, this is your personal information page</h2>
    <div>
        <asp:Label ID="LblFirstName" runat="server">First Name: </asp:Label>
        <asp:TextBox ID="TbFirstName" runat="server">Pesho</asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblLastName" runat="server">Last Name: </asp:Label>
        <asp:TextBox ID="TbLastName" runat="server">Petrov</asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblAge" runat="server">Age: </asp:Label>
        <asp:TextBox ID="TbAge" runat="server">22</asp:TextBox>
    </div>
</asp:Content>
