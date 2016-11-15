<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAutoPostBack.aspx.cs" Inherits="AnyTest2_1.TestAutoPostBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>Test AutoPostBack I</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestAutoPostBackForm" onsubmit="alert('<form ... onsubmit ... >');" runat="server">
		<asp:CheckBox ID="CheckBoxAutoPostBack" Text="CheckBoxAutoPostBack" TextAlign="Right" AutoPostBack="True" OnCheckedChanged="CheckBoxAutoPostBack_CheckedChanged" Runat="server" />
		<br />
		<asp:Label ID="LabelInfo" Runat="server" />
    </form>
</body>
</html>
