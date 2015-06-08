<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_01_02.RegisterForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Logon info</h4>
            <asp:Button Text="Validate logon group" ID="BtnLogon" OnClick="BtnLogon_Click" runat="server" />
            <asp:Label Text="" ID="LblLogonError" runat="server" />
            <div>
                <asp:TextBox runat="server" ID="TbEmail" TextMode="Email" placeholder="Email" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                    ControlToValidate="TbEmail" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupLogon">Required field!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorEmail"
                    runat="server" ForeColor="Red" Display="Dynamic"
                    ErrorMessage="Email address is incorrect!"
                    ControlToValidate="TbEmail" EnableClientScript="False"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
            </asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbUsername" placeholder="Username" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
                    ControlToValidate="TbUsername" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupLogon">Required field!</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbPassword" TextMode="Password" placeholder="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                    ControlToValidate="TbPassword" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupLogon">Required field!</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbRepeatPassword" TextMode="Password" placeholder="Repeat password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server"
                    ControlToValidate="TbRepeatPassword" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupLogon">Required field!</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                    ControlToCompare="TbPassword"
                    ControlToValidate="TbRepeatPassword" Display="Dynamic"
                    ErrorMessage="Password doesn't match!" EnableClientScript="False"></asp:CompareValidator>
            </div>
        </div>
        <div>
            <h4>Personal info</h4>
            <asp:Button Text="Validate Personal group" ID="BtnPersonal" OnClick="BtnPersonal_Click" runat="server" />

            <asp:Label Text="" ID="LblPersonalError" runat="server" />

            <div>
                <asp:TextBox runat="server" ID="TbFirstName" placeholder="First name" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                    ControlToValidate="TbFirstName" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupPersonal">Required field!</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbLastName" placeholder="Last name" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                    ControlToValidate="TbLastName" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupPersonal">Required field!</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbAge" TextMode="Number" placeholder="from 18 to 81" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server"
                    ControlToValidate="TbAge" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupPersonal">Required field!</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidatorAge" runat="server" ValidationGroup="ValidationGroupPersonal"
                    ErrorMessage="The age must be between 18 and 81." ControlToValidate="TbAge" ForeColor="Red"
                    MinimumValue="18" MaximumValue="81" Display="Dynamic" />
            </div>
        </div>
        <div>
            <h4>Address info</h4>
            <asp:Button Text="Validate Address group" ID="BtnAddress" OnClick="BtnAddress_Click" runat="server" />

            <asp:Label Text="" ID="LblAddressError" runat="server" />

            <div>
                <asp:TextBox runat="server" ID="TbAddress" TextMode="MultiLine" placeholder="Address" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                    ControlToValidate="TbAddress" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupAddress">Required field!</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox runat="server" ID="TbPhone" TextMode="Phone" placeholder="1 800 5551212" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                    ControlToValidate="TbPhone" ErrorMessage="RequiredFieldValidator"
                    ValidationGroup="ValidationGroupAddress">Required field!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorPhone"
                    runat="server" ForeColor="Red" Display="Dynamic"
                    ErrorMessage="Phone number is incorrect!"
                    ControlToValidate="TbPhone" EnableClientScript="False"
                    ValidationExpression="(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]‌​)\s*)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)([2-9]1[02-9]‌​|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$">
            </asp:RegularExpressionValidator>
            </div>
        </div>
        <div>
            <div>
                <asp:CheckBox Text="I Agree with the Terms of Service: " ID="CbAgree" runat="server" />
                <asp:CustomValidator ID="CustomValidatorAcceptTerms" runat="server"
                    OnServerValidate="CustomValidatorAcceptTerms_ServerValidate" Display="Dynamic"
                    ErrorMessage="Acceptance of the terms is required." ValidationGroup="ValidationGroupAddress" />
            </div>
        </div>
        <asp:Button Text="Submit" OnClick="Unnamed_Click" runat="server" />
    </form>
</body>
</html>
