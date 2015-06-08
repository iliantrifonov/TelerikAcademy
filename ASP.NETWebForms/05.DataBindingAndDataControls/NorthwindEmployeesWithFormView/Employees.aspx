<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployeesWithFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ItemType="_02.NorthwindEmployees.Employee" ID="GvEmployees" runat="server" SelectMethod="GvEmployees_GetData" DataKeyNames="EmployeeID"
                AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="4" OnSelectedIndexChanged="GvEmployees_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                        <ItemTemplate>

                            <div><%# Item.FirstName + " " + Item.LastName %></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" SelectText="Show info" />
                </Columns>
            </asp:GridView>
            <asp:FormView runat="server" ID="FvDetail" ItemType="_02.NorthwindEmployees.Employee">
                <ItemTemplate>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div><%# "Name: " + Item.FirstName + " " + Item.LastName %></div>
                    <div><%# "Title: " + Item.Title %></div>
                    <div><%# "City: " + Item.City %></div>
                    <div><%# "Address: " + Item.Address %></div>
                    <div><%# "Id: " + Item.EmployeeID %></div>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
