<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.RedirectWithCookies.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>There is no actual login system so just write a user name to "log in" :)</div>
            <asp:TextBox runat="server" ID="TbUserName" />
            <asp:Button Text="Log in" ID="LogIn" OnClick="LogIn_Click" runat="server" />
        </div>
    </form>
</body>
</html>
