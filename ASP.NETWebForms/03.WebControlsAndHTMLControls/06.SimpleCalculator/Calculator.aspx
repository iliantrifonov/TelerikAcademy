<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_06.SimpleCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellspacing="2" cellpadding="2">
                <thead>
                    <tr>
                        <th colspan="4">
                            <input type="text" autofocus="autofocus" /></th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <td colspan="2">
                            <input type="button" value="0" style="width: 70px" /></td>
                        <td>
                            <input type="button" value="." /></td>
                        <td>
                            <input type="button" value="/" /></td>
                    </tr>
                </tfoot>
                <tbody>
                    <tr>
                        <td>
                            <input type="button" value="1" /></td>
                        <td>
                            <input type="button" value="2" /></td>
                        <td>
                            <input type="button" value="3" /></td>
                        <td>
                            <input type="button" value="+" /></td>
                    </tr>
                    <tr>
                        <td>
                            <input type="button" value="4" /></td>
                        <td>
                            <input type="button" value="5" /></td>
                        <td>
                            <input type="button" value="6" /></td>
                        <td>
                            <input type="button" value="-" /></td>
                    </tr>
                    <tr>
                        <td>
                            <input type="button" value="7" /></td>
                        <td>
                            <input type="button" value="8" /></td>
                        <td>
                            <input type="button" value="9" /></td>
                        <td>
                            <input type="button" value="*" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
