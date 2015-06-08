<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sum.aspx.cs" Inherits="SumNumbersWebForms.Sum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="form-group">
            <asp:Label ID="lbFirstNumber" runat="server" Text="First Number"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbFirstNumber"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbSecondNumber" runat="server" Text="Second Number"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbSecondNumber"></asp:TextBox>
        </div>

        <asp:Button runat="server" Text="Sum" ID="btnSum" OnClick="btnSum_Click" />

        <div class="form-group">
            <asp:Label ID="lbResult" runat="server"  Text="Result"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbResult"></asp:TextBox>
        </div>
    </div>
</asp:Content>
