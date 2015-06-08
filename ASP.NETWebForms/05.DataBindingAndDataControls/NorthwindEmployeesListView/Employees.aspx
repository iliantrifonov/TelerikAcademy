<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindEmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView runat="server" ID="LvEmployees" ItemType="_02.NorthwindEmployees.Employee"  SelectMethod="LvEmployees_GetData">
            <LayoutTemplate>
                <h3>Employees</h3>
                
                <asp:Button runat="server" ID="BtnSortLastName" CommandName="Sort" CommandArgument="LastName" Text="Sort by first name" />
                <asp:Button runat="server" ID="BtnSortFirstName" CommandName="Sort" CommandArgument="FirstName" Text="Sort by last name" />
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div><%# Item.FirstName + " " + Item.LastName %></div>
            </ItemTemplate>
            
        </asp:ListView>

        <asp:DataPager ID="DataPagerCustomers" runat="server"
            PagedControlID="LvEmployees" PageSize="3"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>
    </form>
</body>
</html>
