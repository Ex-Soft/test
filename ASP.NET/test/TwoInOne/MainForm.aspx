<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="TwoInOne.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>MainForm</TITLE>
		<meta name="vs_snapToGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<frameset id="mainframeset" title="MainFrameSet" border="10" borderColor="blue" rows="50%,*"
		runat="server" style="BACKGROUND-COLOR: green" frameborder="yes" framespacing="20">
		<frame name="Frame1" src="frame1.aspx">
		<frame name="Frame2" src="frame2.aspx">
		<noframes>
			<p>This page requires frames, but your browser does not support them.</p>
		</noframes>
	</frameset>
</HTML>
