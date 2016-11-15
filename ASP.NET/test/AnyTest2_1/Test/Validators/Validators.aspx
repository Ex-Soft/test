<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validators.aspx.cs" Inherits="AnyTest2_1.TestValidatorsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Test Validators</title>
   	    <meta name="vs_snapToGrid" content="False" />
	    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
	    <style type="text/css">
            .Input { font: 10pt verdana; color: red; }
            span { font-weight: bold; color: aqua; }
        </style>
        <script type="text/javascript">
<!--
function __validateAmount(source, args)
{
    args.IsValid=(args.Value%10 == 0);
}
// -->
        </script>
    </head>
    <body>
        <h1 style="color: blue">Validators</h1>
        <hr size="10" color="blue" />
        <form id="TestValidatorsForm" style="background-color: teal" runat="server">
            <span>Password </span><asp:TextBox id="password1" textmode="password" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ControlToValidate="password1"
                ErrorMessage="Required field"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>Password </span><asp:TextBox id="password2" textmode="password" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                ControlToValidate="password2"
                Display="static"
                ForeColor="blue"
                runat="server">
            Required field
            </asp:RequiredFieldValidator>
            <br />
            <span>Password </span><asp:TextBox id="password3" textmode="password" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                ControlToValidate="password3"
                ErrorMessage="Required field"
                Display="dynamic"
                ForeColor="blue"
                runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                ControlToValidate="password3"
                ValidationExpression=".{8,}"
                ErrorMessage="You must enter at least 8 characters"
                Display="dynamic"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>e-mail </span><asp:TextBox CssClass="Input" id="EMail1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                ControlToValidate="EMail1"
                ErrorMessage="Required field"
                Display="static"
                ForeColor="blue"
                ValidationGroup="EMails"
                SetFocusOnError="true"
                runat="server" />
            <br />
            <asp:TextBox id="Percent" runat="server" /><span>%</span>
            <asp:RangeValidator ID="RangeValidator1"
                ControlToValidate="Percent"
                MinimumValue="0"
                MaximumValue="100"
                Type="Integer"
                ErrorMessage="Value out of range"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>Date </span><asp:TextBox id="MyDate" runat="server" />
            <asp:RangeValidator
                ID="RangeValidatorDate"
                ControlToValidate="MyDate"
                Type="Date"
                ErrorMessage="Date out of range"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>Min=</span><asp:TextBox id="Minimum" runat="server" />
            <span>Max=</span><asp:TextBox id="Maximum" runat="server" />
            <asp:CompareValidator ID="CompareValidator1"
                ControlToValidate="Maximum"
                ControlToCompare="Minimum"
                Type="Integer"
                Operator="GreaterThanEqual"
                ErrorMessage="Invalid maximum"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>Password </span><asp:TextBox id="password11" TextMode="password" runat="server" />
            <span>Re-enter password </span><asp:TextBox id="password22" TextMode="password" runat="server" />
            <asp:CompareValidator ID="CompareValidator2"
                ControlToValidate="password22"
                ControlToCompare="password11"
                Type="String"
                Operator="Equal"
                ErrorMessage="Mismatch"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>Digits </span><asp:TextBox id="Quantity" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="Quantity"
                ValidationExpression="^\d+$"
                ErrorMessage="Digits only"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>e-mail </span><asp:TextBox id="EMail2" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                ControlToValidate="EMail2"
                ValidationExpression="^[\w\.-]+@[\w-]+\.[\w\.-]+$"
                ErrorMessage="Invalid e-mail address"
                Display="static"
                ForeColor="blue"
                ValidationGroup="EMails"
                SetFocusOnError="true"
                runat="server" />
            <br />
            <span>Input%10 </span><asp:TextBox id="Amount" runat="server" />
            <asp:CustomValidator ID="CustomValidator1"
                ControlToValidate="Amount"
                ClientValidationFunction="__validateAmount"
                OnServerValidate="ValidateAmount"        
                ErrorMessage="Amount must be a multiple of 10"
                Display="static"
                ForeColor="blue"
                runat="server" />
            <br />
            <span>User name </span><asp:TextBox id="UserName" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                ControlToValidate="UserName"
                ErrorMessage="The user name can't be blank"
                Display="none"
                runat="server" />
            <br />
            <span>Password </span><asp:TextBox id="password4" textmode="password" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                ControlToValidate="password4"
                ErrorMessage="The password can't be blank"
                Display="none"
                runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                ControlToValidate="password4"
                ValidationExpression=".{8,}"
                ErrorMessage="The password must contain at least 8 characters"
                Display="none"
                runat="server" />
            <asp:ValidationSummary ID="ValidationSummary1"
                DisplayMode="BulletList"
                HeaderText="This page containts the following errors"
                ShowMessageBox="true"
                ShowSummary="true"
                runat="server" />
            <br />
            <br />
            <asp:button id="ButtonTest" runat="server" Text="Test" onclick="OnClick" />&nbsp;
            <asp:Button ID="ButtonTestEMailOnly" Text="e-Mail (only)" ValidationGroup="EMails" runat="server" />&nbsp;
            <asp:Button ID="ButtonWOValidators" Text="WO Validators" CausesValidation="false" runat="server" />
        </form>
    </body>
</html>
