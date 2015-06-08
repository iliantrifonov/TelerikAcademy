<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_03.ShowFromOneTextBoxInAnother.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TbInput" runat="server"></asp:TextBox>
        <asp:Button ID="BtnShow" Text="Show the text entered in the text box" runat="server" OnClick="BtnShow_Click" />
        <asp:TextBox ID="TbOutput" runat="server"></asp:TextBox>
        <asp:Label ID="LblOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
