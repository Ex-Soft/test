<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebConfig.MainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Web.config</title>
</head>
<body>
    <form id="MainForm" runat="server">
    <div>
        <h1>&lt;appSettings&gt;</h1>
        <asp:Label ID="LabelAppSettings" runat="server" />
        <hr />
        <h1>&lt;connectionStrings&gt;</h1>
        <asp:Label ID="LabelConnectionStrings" runat="server" />
        <hr />
        <h1>&lt;NameValueSection&gt;</h1>
        <asp:Label ID="LabelNameValueSection" runat="server" />
        <hr />
        <h1>&lt;DictionarySection&gt;</h1>
        <asp:Label ID="LabelDictionarySection" runat="server" />
        <hr />
        <h1>&lt;SingleTagSection&gt;</h1>
        <asp:Label ID="LabelSingleTagSection" runat="server" />
        <hr />
        <h1>&lt;MyConfigHandler&gt;</h1>
        <asp:Label ID="LabelMyConfigHandler" runat="server" />
        <hr />
        <h1>&lt;MyConfigHandlerAdvanced&gt;</h1>
        <asp:Label ID="LabelMyConfigHandlerAdvanced" runat="server" />
        <hr />
    </div>
    </form>
</body>
</html>
