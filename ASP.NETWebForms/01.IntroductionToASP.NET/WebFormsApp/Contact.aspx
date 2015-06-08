<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebFormsApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>For more on cupcakes please contact us.</h3>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">cupcake@sweet.com</a><br />
        <strong>For help with your cupcake addiction:</strong> <a href="mailto:Marketing@example.com">chocolate@cupcake.org</a>
    </address>
</asp:Content>
