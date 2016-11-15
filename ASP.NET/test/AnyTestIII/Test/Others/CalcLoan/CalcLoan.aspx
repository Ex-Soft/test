<%@ Page language="c#" Codebehind="CalcLoan.aspx.cs" AutoEventWireup="false" Inherits="CalcLoan.CalcLoanForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CalcLoan</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<H1>Mortgage Payment Calculator</H1>
		<hr>
		<form id="CalcLoanForm" method="post" runat="server">
			<TABLE id="TableGrid" cellSpacing="1" cellPadding="8" width="100%" bgColor="aqua" border="0">
				<TR>
					<TD style="WIDTH: 94px" vAlign="middle" align="right">Principal</TD>
					<TD><asp:textbox id="Principal" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px" vAlign="middle" align="right">Rate (percent)</TD>
					<TD><asp:textbox id="Rate" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px" vAlign="middle" align="right">Term (month)</TD>
					<TD><asp:textbox id="Term" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px"></TD>
					<TD><asp:button id="ButtonComputePayment" runat="server" Text="Compute payment"></asp:button></TD>
				</TR>
			</TABLE>
			<br>
			<hr>
			<br>
			<h3><asp:label id="Output" runat="server"></asp:label></h3>
		</form>
	</body>
</HTML>