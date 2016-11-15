<%@ Register TagPrefix="vs" Namespace="Vladsm.Web.UI.WebControls" Assembly="GroupRadioButton" %>
<%@ Page language="c#" Codebehind="DataGridWControlsForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DataGridWithControlsForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DataGrid With Controls</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body>
		<form id="DataGridWithControlsForm" method="post" runat="server">
			<asp:DataGrid id="DGWCheckBox" AutoGenerateColumns="false" DataKeyField="ID" BorderWidth="1" BorderColor="lightgray"
				Font-Name="Verdana" Font-Size="8pt" CellPadding="2" CellSpacing="0" GridLines="Both" Width="90%" AllowPaging="True" PageSize="3"
				runat="server">
				<HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
				<ItemStyle BackColor="white" ForeColor="darkblue" />
				<AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
				<PagerStyle HorizontalAlign="Left" BackColor="#DEEBE7" Mode="NumericPages" />
				<Columns>
					<asp:BoundColumn HeaderText="Ф. И. О." DataField="Name" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" />
					<asp:TemplateColumn HeaderText="Kill" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<asp:CheckBox ID="CheckBoxKill" Runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
			<hr>
			<asp:DataGrid id="DGWRadioButton" AutoGenerateColumns="false" DataKeyField="ID" BorderWidth="1"
				BorderColor="lightgray" Font-Name="Verdana" Font-Size="8pt" CellPadding="2" CellSpacing="0"
				GridLines="Both" Width="90%" runat="server">
				<HeaderStyle BackColor="teal" ForeColor="white" Font-Bold="true" />
				<ItemStyle BackColor="white" ForeColor="darkblue" />
				<AlternatingItemStyle BackColor="beige" ForeColor="darkblue" />
				<Columns>
					<asp:BoundColumn HeaderText="Ф. И. О. (&lt;input type=&quot;checkbox&quot; id=&quot;CheckBoxHeader&quot; name=&quot;CheckBoxHeader&quot;&gt;)" DataField="Name" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Left" />
					<asp:TemplateColumn HeaderText="Choice (&lt;input type=&quot;radio&quot; id=&quot;RadioButtonHeader&quot; name=&quot;Choice&quot; value=&quot;0&quot;&gt;)" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<input type="radio" id="RadioButton<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")) %>" name="Choice"<%# ((bool)DataBinder.Eval(Container.DataItem,"Checked")) ? " checked" : "" %> value="<%# Convert.ToString(((System.Data.DataRowView)Container.DataItem)["ID"]) %>">
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Choice (asp:RadioButton)" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<asp:RadioButton ID="RadioButton" GroupName="ChoiceChoice" Runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Checked" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
						<ItemTemplate>
							<%# ((bool)DataBinder.Eval(Container.DataItem,"Checked")) ? "checked" : "unchecked" %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<vs:GroupRadioButton id="selectRadioButton" runat="server" value="test" GroupName="country" />
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Button ID="btnSubmit" Text="Submit" Runat="server" />
		</form>
	</body>
</HTML>