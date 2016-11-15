<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUserControlForm.aspx.cs" Inherits="AnyTest.TestUserControlForm" %>
<%@ Register TagPrefix="uc" TagName="WebUserControl1" src="WebUserControl1.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Test User Control</title>
    </head>
    <body>
        <form id="TestUserControlForm" runat="server">
            <uc:WebUserControl1 id="TestUserControl1" runat="server" />
            <uc:WebUserControl1 id="TestUserControl2" runat="server" />
            <asp:Button ID="Button1" Text="DoIt!" runat="server" />
        </form>
    </body>
</html>
