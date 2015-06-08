<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.NorthwindEmployees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ItemType="_02.NorthwindEmployees.Employee" ID="GvEmployees" runat="server" SelectMethod="GvEmployees_GetData"
             AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="4">
            <Columns>
                <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                    <ItemTemplate >
                        <a href='<%# "EmpDetails.aspx?id=" + Item.EmployeeID %>'><div><%# Item.FirstName + " " + Item.LastName %></div></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
