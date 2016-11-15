<%@ Page language="c#" Codebehind="TestSession.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestSession" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TestSession</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript">
<!--
function OnClickSubmit()
{
   document.getElementById("Hidden4Submit").value=true;
   document.getElementById("Hidden4Submit2").value=true;
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestSessionForm" method="post" runat="server">
			<asp:Literal ID="Hidden4Submit" Runat="server" />
			<input ID="Hidden4Submit2" name="Hidden4Submit2" type="hidden" value="false">
			<h1 align="center">Test Session</h1>
			<hr style="WIDTH: 50%" align="center">
			<div align="center"><asp:datagrid id="DataStaff" runat="server" AllowSorting="true" Width="90%" GridLines="vertical"
					Font-Size="8pt" Font-Name="Verdana" BorderColor="lightgray" BorderWidth="1" CellPadding="2" AutoGenerateColumns="false">
					<columns>
						<asp:boundcolumn headertext="ID" datafield="IdentificationNumber" headerstyle-horizontalalign="center"
							itemstyle-horizontalalign="center" />
						<asp:boundcolumn headertext="Name" datafield="FullName" headerstyle-horizontalalign="center" sortexpression="FullName asc" />
						<asp:boundcolumn headertext="Salary" datafield="MinimumSalary" headerstyle-horizontalalign="center"
							sortexpression="MinimumSalary asc" itemstyle-horizontalalign="center" DataFormatString="{0:c}" />
						<asp:buttoncolumn HeaderText="Action" Text="Change" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center"
							CommandName="ChangeSalary" />
					</columns>
					<headerstyle backcolor="teal" forecolor="white" font-bold="true" />
					<itemstyle backcolor="white" forecolor="darkblue" />
					<alternatingitemstyle backcolor="beige" forecolor="darkblue" />
				</asp:datagrid></div>
			ID&nbsp;<asp:textbox id="ContragentId" Runat="server" ReadOnly="true"></asp:textbox>&nbsp;New&nbsp;Salary&nbsp;<asp:textbox id="NewSalaryValue" Runat="server"></asp:textbox>&nbsp;<input type="submit" value="Submit" onclick="OnClickSubmit()"><br>
			<asp:Label ID="SessionInfo" Runat="server" /></form>
	</body>
</HTML>
