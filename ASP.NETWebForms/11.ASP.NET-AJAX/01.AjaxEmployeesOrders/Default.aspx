<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.AjaxEmployeesOrders.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="ScriptManagerId" />

            <asp:GridView runat="server" ID="GvEmployees" ItemType="_01.AjaxEmployeesOrders.Employee"
                DataKeyNames="EmployeeId" SelectMethod="GvEmployees_GetData"
                OnSelectedIndexChanged="GvEmployees_SelectedIndexChanged"
                AutoGenerateColumns="true" AutoGenerateSelectButton="true">
            </asp:GridView>


            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvOrders" runat="server" ItemType="_01.AjaxEmployeesOrders.Order"
                        AutoGenerateColumns="true"
                        AllowPaging="true" PageSize="8" OnPageIndexChanging="GvOrders_PageIndexChanging">
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GvEmployees" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress runat="server" ID="UpdateProgress" DisplayAfter="1" >
                <ProgressTemplate> 
                    <h1>loading...</h1>
                    <asp:Image runat="server" ImageUrl="~/loadingeffect2.png" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
