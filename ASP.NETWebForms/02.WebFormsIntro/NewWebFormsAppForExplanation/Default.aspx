<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewWebFormsAppForExplanation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Hello, ASP.NET from the aspx code</h1>
        <h1><asp:Label ID="lblHello" runat="server"></asp:Label></h1>
        <div class="container"> 
            <p>This is the current assembly location:</p>
            <asp:Label ID="lblLocation" runat="server"></asp:Label>
        </div>
        <div class="container">
            Code-behind refers to code for your ASP.NET page that is contained within a separate class file. This allows a clean separation of your HTML from your presentation logic. 
            Inheriting from the Page class gives the code-behind page access to the ASP.NET intrinsic objects, such as Request and Response. In addition, inheriting from the Page class provides a framework for handling events for controls within the ASP.NET page.
            When you use Microsoft Visual Studio .NET to create ASP.NET Web Forms, code-behind pages are the default method. In addition, Visual Studio .NET automatically performs precompilation for you when you build your solution. Note that code-behind pages that are created in Visual Studio .NET include a special page attribute, Codebehind, which Visual Studio .NET uses. 
        </div>
    </div>
</asp:Content>
