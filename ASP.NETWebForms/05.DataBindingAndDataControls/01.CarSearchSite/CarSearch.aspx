<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSearch.aspx.cs" Inherits="_01.CarSearchSite.CarSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="DdlMake" AutoPostBack="true" OnSelectedIndexChanged="DdlMake_SelectedIndexChanged" ItemType="String">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="DdlModel">
        </asp:DropDownList>
        <asp:CheckBoxList runat="server" ID="CblExtras">
        </asp:CheckBoxList>
        <asp:RadioButtonList runat="server" ID="RbEngines">
        </asp:RadioButtonList>

        <asp:Button runat="server" Text="Submit" ID="BtnSubmit" OnClick="BtnSubmit_Click" />

        <asp:Literal runat="server" ID="LiteralResult" ></asp:Literal>
    </div>
    </form>
</body>
</html>
