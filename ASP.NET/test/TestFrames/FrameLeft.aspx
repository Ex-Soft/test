<%@ Page language="c#" Codebehind="FrameLeft.aspx.cs" AutoEventWireup="false" Inherits="TestFrames.FrameLeftForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Frame Left</title>
		<meta content="False" name="vs_snapToGrid">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function FrameRightSet()
{
	var
		Ctrl;
		
	if(!(Ctrl=parent.document.getElementById("FrameRight")))
		return;
		
	Ctrl.src="FrameRightButton.aspx";
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="FrameLeftForm" method="post" runat="server">
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:LinkButton ID="LinkButton1" Runat="server">LinkButton1</asp:LinkButton></td>
				</tr>
				<tr>
					<td><asp:LinkButton ID="Linkbutton2" href="FrameRightLinkButton.aspx" target="FrameRight" Runat="server">LinkButton2</asp:LinkButton></td>
				</tr>
				<tr>
					<td><a id="HtmlAnchor" href="FrameRightLinkButton.aspx" target="FrameRight">HtmlAnchor</a></td>
				</tr>
				<tr>
					<td><asp:Button ID="Button1" Text="Button" Runat="server" /></td>
				</tr>
				<tr>
					<td><input type="button" id="HtmlButton" value="HtmlButton" onclick="FrameRightSet()"></td>
				</tr>
				<tr>
					<td><a id="HtmlAnchorImg" href="FrameRightLinkButton.aspx" target="FrameRight"><img src="images/wall.gif" onclick="this.src='images/27265.gif'" alt="Click me!" title="Click me!" border="0"></a></td>
				</tr>
				<tr>
					<td><asp:Label ID="LabelInfo" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
