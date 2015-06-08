<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" ID="RepeaterEmployees" ItemType="_02.NorthwindEmployees.Employee" SelectMethod="RepeaterEmployees_GetData">
            <ItemTemplate>
                <div><%# Item.FirstName + " " + Item.LastName %></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
