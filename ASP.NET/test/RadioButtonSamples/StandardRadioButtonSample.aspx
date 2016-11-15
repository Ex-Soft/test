<%@ Page language="c#" Codebehind="StandardRadioButtonSample.aspx.cs" AutoEventWireup="false" Inherits="Vladsm.Samples.RadioButtonSamples.StandardRadioButtonSample" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Standard RadioButton sample</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">

			<!-- Countries for selection -->
			<asp:DataGrid id="countriesGrid" runat="server" DataKeyField="ID" AutoGenerateColumns="False">
				<Columns>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:RadioButton id="selectRadioButton" runat="server" GroupName="country" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Font-Bold="True" />
					<asp:BoundColumn DataField="Capital" HeaderText="Capital" HeaderStyle-Font-Bold="True" />
				</Columns>
			</asp:DataGrid>

		</form>
	</body>
</HTML>
