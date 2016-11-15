<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="AnyTestII.MainForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
        <title>AnyTest II</title>
    </head>
	<frameset id="mainframeset" title="MainFrameSet" border="10" bordercolor="blue" rows="20%,*" runat="server" style="BACKGROUND-COLOR: green" frameborder="yes" framespacing="20">
		<frame name="maintitle" src="maintitle.aspx" noresize scrolling="no">
		<frameset cols="25%, *">
			<frame name="contents" src="contents.html">
			<frame name="main">
		</frameset>
		<noframes>
			<p>This page requires frames, but your browser does not support them.</p>
		</noframes>
	</frameset>
</html>
