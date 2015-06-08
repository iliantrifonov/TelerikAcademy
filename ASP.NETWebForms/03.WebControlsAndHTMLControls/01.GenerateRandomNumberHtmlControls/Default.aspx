<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.GenerateRandomNumberHtmlControls._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <input id="inputFrom" runat="server" type="text" placeholder="From" />
        <input id="inputTo" runat="server" type="text" placeholder="To" />
        <input id="btnRandom" runat="server" type="submit" value="Generate random number" onserverclick="btnRandom_ServerClick" />
    </div>

</asp:Content>
