<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02.NorthwindEmployees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView runat="server" ID="DvEmployee" ItemType ="_02.NorthwindEmployees.Employee" SelectMethod="DvEmployee_GetItem" AutoGenerateRows="true">
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
