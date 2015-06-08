<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintName.aspx.cs" Inherits="PrintName.PrintName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <asp:Button ID="btnEnterName" Text="Enter name to show" runat="server" OnClick="BtnEnterName_Click" />
            <div>
                <asp:Label ID="lblShowName" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
