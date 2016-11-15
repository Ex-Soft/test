<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Controls Contents</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="ControlsContentsForm" method="post" runat="server" style="color: maroon; background-color: aqua">
			<div align="center">
                          <h1>Test Controls</h1>
			</div>
                        <hr>
                        <div nowrap>
                          <ol style="1">
				<li><asp:hyperlink id="HyperlinkTestPostBackUrl" runat="server" NavigateUrl="testpostbackurl/firstform.aspx" Target="main" text="Test PostBackUrl" />
				<li><asp:hyperlink id="HyperlinkTestPostBackUrlII" runat="server" NavigateUrl="testpostbackurlii/testpostbackurliifirstform.aspx" Target="main" text="Test PostBackUrl II" />
				<li><asp:hyperlink id="HyperlinkTestRODCtrls" runat="server" NavigateUrl="testrodctrls/testrodctrlsform.aspx" Target="main" text="Test ReadOnly or Disabled Ctrls" />
				<li><asp:hyperlink id="HyperlinkTestDynamicCtrls" runat="server" NavigateUrl="testdynamicctrls/testdynamicctrlsform.aspx" Target="main" text="Test Dynamic Ctrls" />
				<li><asp:hyperlink id="HyperlinkTestDynamicCtrlsII" runat="server" NavigateUrl="testdynamicctrls/testdynamicctrlsformii.aspx" Target="main" text="Test Dynamic Ctrls (II)" />
				<li><asp:hyperlink id="HyperlinkTestCtrlsForm" runat="server" NavigateUrl="testctrls/testctrlsform.aspx" Target="main" text="Test Ctrls" />
				<li><asp:hyperlink id="HyperlinkTestEnableEventValidationForm" runat="server" NavigateUrl="TestEnableEventValidation/TestEnableEventValidationForm.aspx" Target="main" text="Test EnableEventValidation" />
				<li><a href="TestDataBind/TestDataBindForm.aspx" target="main">Test DataBind</a><br />
			  </ol>
                        </div>
                        <hr>
                        <br>
                        <div align="center">
                          <asp:hyperlink id="HyperlinkMainContents" runat="server" NavigateUrl="../../contents.aspx" text="Main contents" align="center"></asp:hyperlink>
			</div>
		</form>
	</body>
</html>
