<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04.DeleteViewStateField.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="Tb" />
    </div>
        <script type="text/javascript">
            (function () {
                var elems = document.getElementsByTagName('div'), i;
                for (i in elems) {
                    if ((' ' + elems[i].className + ' ').indexOf(' ' + 'aspNetHidden' + ' ') > -1) {
                        elems[i].innerHTML = "";
                    }
                }
            })();
        </script>
    </form>
</body>
</html>
