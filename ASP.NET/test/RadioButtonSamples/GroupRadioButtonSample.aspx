<%@ Register TagPrefix="vs" Namespace="Vladsm.Web.UI.WebControls" Assembly="GroupRadioButton" %>
<%@ Page language="c#" Codebehind="GroupRadioButtonSample.aspx.cs" AutoEventWireup="false" Inherits="Vladsm.Samples.RadioButtonSamples.GroupRadioButtonSample" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GroupRadioButton sample</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- Countries for selection -->
			<asp:DataGrid id="countriesGrid" runat="server" DataKeyField="ID" AutoGenerateColumns="False">
				<Columns>
					<asp:TemplateColumn>
						<ItemTemplate>
							<vs:GroupRadioButton id="selectRadioButton" runat="server" value="test" GroupName="country" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Font-Bold="True" />
					<asp:BoundColumn DataField="Capital" HeaderText="Capital" HeaderStyle-Font-Bold="True" />
				</Columns>
			</asp:DataGrid>
			<!-- Button to select country -->
			<div style="MARGIN-TOP:10px"><asp:Button ID="selectButton" Runat="server" Text="Select" /></div>
			<!-- Currently selected country -->
			<div style="MARGIN-TOP:10px" nowrap><asp:Label ID="selectedCountryInfo" Runat="server" /></div>
		</form>
	</body>
</HTML>
