<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="AnyTest2_1.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Frameset//EN" >
<html>
	<head>
		<title>Any Test</title>
		<meta content="False" name="vs_snapToGrid" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<script type="text/javascript">
<!--
function Stub()
{
    if(!<%=SmthBool.ToString().ToLower()%>)
        alert("1");
}
// -->
        </script>
	</head>
	<frameset id="mainframeset" title="MainFrameSet" border="10" bordercolor="blue" rows="20%,*" runat="server" style="BACKGROUND-COLOR: green" frameborder="yes" framespacing="20">
		<frame name="maintitle" src="maintitle.aspx" noresize scrolling="no">
		<frameset cols="25%, *">
			<frame name="contents" src="contents.aspx">
			<frame name="main">
		</frameset>
		<noframes>
			<p>This page requires frames, but your browser does not support them.</p>
		</noframes>
	</frameset>
</html>