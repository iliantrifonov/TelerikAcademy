<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_04.StudentRegistrationForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" Text="First name"></asp:Label>
            <asp:TextBox ID="TbFirstName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Last name"></asp:Label>
            <asp:TextBox ID="TbLastName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Faculty number"></asp:Label>
            <asp:TextBox ID="TbFacultyNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:DropDownList ID="DdlUniversity" runat="server">
               <asp:ListItem Value="Telerik Academy" Text="Telerik Academy"></asp:ListItem>
                <asp:ListItem Value="NYU" Text="New York University"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:DropDownList ID="DdlSpeciality" runat="server">
               <asp:ListItem Value="Programming" Text="Programming"></asp:ListItem>
                <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:ListBox SelectionMode="Multiple" ID="LbCourses" runat="server">
                <asp:ListItem Value="C#">C#</asp:ListItem>
                <asp:ListItem Value="JS">JS</asp:ListItem>
                <asp:ListItem Value="Databases">Databases</asp:ListItem>
            </asp:ListBox>
        </div>
        <div>
            <asp:Button ID="BtnSubmit" Text="Submit" runat="server" OnClick="BtnSubmit_Click" />
        </div>
        <asp:Panel ID="PanelResult" runat="server" >
            This is your entered data:
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
