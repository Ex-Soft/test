<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDynamicCtrlsFormII.aspx.cs" Inherits="AnyTest2_1.TestDynamicCtrlsFormII" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Dynamic Controls Form II</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestDynamicCtrlsFormII" runat="server">
        Start: <asp:Label id="LabelDateTimeStart" runat="server" /><br />
        <asp:PlaceHolder ID="PlaceHolderMain" runat="server" /><br />
        Stop: <asp:Label id="LabelDateTimeStop" runat="server" /><br />
        Diff: <asp:Label id="LabelDateTimeDiff" runat="server" />
    </form>
</body>
</html>
