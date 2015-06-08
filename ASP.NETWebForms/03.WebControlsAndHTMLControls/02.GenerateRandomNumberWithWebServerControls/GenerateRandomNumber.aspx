<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateRandomNumber.aspx.cs" Inherits="_02.GenerateRandomNumberWithWebServerControls.GenerateRandomNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TbFrom" runat="server"></asp:TextBox>
        <asp:TextBox ID="TbTo" runat="server"></asp:TextBox>
        <asp:Button ID="BtnGenerate" Text="Generate random number" runat="server" OnClick="BtnGenerate_Click" />
        <asp:Label ID="LabelResult" runat="server" Text="" Visible="false" />
    </div>
    </form>
</body>
</html>
