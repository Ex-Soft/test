<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="ASPImaging.index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>index</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td width="100%">
						<font face="arial" size="2"><b>EX-1: Adding two images- Test</b></font>
						<BR>
						&nbsp;<BR>
						<IMG src="imager.aspx?type=counter">
						<BR>
						&nbsp;</td>
				</tr>
				<tr>
					<td width="100%"><font face="arial" size="2"><b>EX-2: Zooming images- Test</b></font>
						<BR>
						<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="imager.aspx"></asp:imagebutton></td>
				</tr>
				<tr>
					<td width="100%"><INPUT id="txtPosX" type="hidden" size="1" runat="server"><INPUT id="txtPosY" type="hidden" size="1" runat="server">
						<font face="arial" size="2" color="red"><b>Click anywhere on the image to zoom</b></font><font face="arial" size="2">..or 
							click here for original page</font>
						<asp:Button id="Button1" runat="server" Text="Original"></asp:Button></FONT>
					</td>
				</tr>
				<tr>
					<td width="100%"><BR>
						<font face="arial" size="2"><b>EX-3: Enlarging images - Test&nbsp;</b></font>
						<BR>
						<BR>
						<asp:Image id="Image1" runat="server" ImageUrl="imager.aspx"></asp:Image>
						<BR>
						&nbsp;
						<asp:Button id="Button2" runat="server" Text="Click to enlarge"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
