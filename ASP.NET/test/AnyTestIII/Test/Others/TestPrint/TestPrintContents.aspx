<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Test Print Contents</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="TestPrintContentsForm" method="post" runat="server" style="color: maroon; background-color: aqua">
			<div align="center">
				<h1>Test Print</h1>
			</div>
			<hr>
			<div nowrap>
				<ol style="1">
					<li><asp:hyperlink id="HyperLinkSimplePrint" NavigateUrl="TestPrintMainForm.aspx?DocumentId=1&Id=1" Target="main" text="Simple Print" runat="server" /><br>
					<li><asp:hyperlink id="HyperLinkPrintWithInput" NavigateUrl="TestPrintMainForm.aspx?DocumentId=2&Id=2" Target="main" text="Print with input" runat="server" /><br>
				</ol>
			</div>
			<hr>
			<br>
			<div align="center">
				<asp:hyperlink id="HyperlinkOthersContents" runat="server" NavigateUrl="../otherscontents.aspx" text="Others contents" align="center" />
			</div>
		</form>
	</body>
</html>
