<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.SaveInputToSessionAndShowIt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="TbInput" />
        <asp:Button Text="Save to session" ID="Btn" runat="server" OnClick="Btn_Click" />
    </div>
        <div>
            Session stored text: 
            <asp:Label Text="" ID="LblResult" runat="server" />
        </div>
    </form>
</body>
</html>
