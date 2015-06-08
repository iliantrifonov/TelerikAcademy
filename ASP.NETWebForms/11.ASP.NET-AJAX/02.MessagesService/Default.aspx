<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.MessagesService.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" />
            <asp:TextBox runat="server" ID="TbUsername" placeholder="Username" />

            <asp:TextBox runat="server" ID="TbMessage" placeholder="Write your message..." />

            <asp:Button Text="Send" ID="BtnSend" OnClick="BtnSend_Click" runat="server" />

            <asp:Timer runat="server" ID="Timer" Interval="500" OnTick="Timer_Tick"></asp:Timer>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ListView runat="server" ID="LvMessages" ItemType="_02.MessagesService.Message">
                        <LayoutTemplate>
                            <h2>Latest messages:</h2>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div>
                                <div>------------------------------------------------------- </div>
                                <div><%# Item.DatePublished %>: <%#: Item.Username %> :</div>
                                <div><%#: Item.Content %></div>
                                <div>------------------------------------------------------- </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
                    <asp:AsyncPostBackTrigger ControlID="BtnSend" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            
        </div>
    </form>
</body>
</html>
