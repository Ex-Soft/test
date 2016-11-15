<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestFormsAuthentication._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Test FormsAuthentication</title>
    </head>
    <body>
        <form id="TestFormsAuthenticationForm" runat="server">
            HttpContext.Current.Request.LogonUserIdentity.Name: <asp:Label ID="lblLogonUserIdentityName" runat="server" /><br/>
            System.Security.Principal.WindowsIdentity.GetCurrent().Name: <asp:Label ID="lblWindowsIdentityGetCurrentName" runat="server" /><br/>
            <asp:Button ID="btnConnect" Text="Connect" onclick="BtnConnectClick" runat="server"/>
            <hr/>
            <asp:Label ID="lblError" runat="server" />
        </form>
    </body>
</html>