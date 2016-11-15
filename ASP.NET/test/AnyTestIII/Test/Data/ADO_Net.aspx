<%@ Page language="c#" Codebehind="ADO_Net.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.ADONETForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ADO.NET</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ADONETForm" method="post" runat="server">
			<asp:label id="LabelInit" Runat="server"></asp:label><br>
			<asp:label id="LabelLoad" Runat="server"></asp:label><br>
			<asp:datagrid id="MyDataGrid" AutoGenerateColumns="False" DataKeyField="ID" BorderWidth="1px" BorderColor="LightGray"
				CellPadding="2" Font-Name="Verdana" Font-Size="8pt" GridLines="Vertical" Width="90%" AllowSorting="True"
				Runat="server" Font-Names="Verdana">
				<AlternatingItemStyle ForeColor="DarkBlue" BackColor="Beige"></AlternatingItemStyle>
				<ItemStyle ForeColor="DarkBlue" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="N п/п">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="Ф. И. О.">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="А фот вам!!!">
						<ItemTemplate>
							<!-- <a href="javascript:AddDropClick()">Дать/Забрать</a> -->
							<a id="Anchor<%# DataBinder.Eval(Container,"ItemIndex").ToString() %>" style="cursor: hand; color: teal; text-decoration: underline" onclick="AddDropClick('<%# DataBinder.Eval(Container.DataItem,"ID") %>')">Дать/Забрать</a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Test Image">
						<ItemTemplate>
							<asp:LinkButton ID="LinkButtonImage" CommandName="TestImage" CommandArgument="SmthCommandArgument" CausesValidation="false" Runat="server">
								<asp:Image id="ImageButton" ImageUrl="../controls/images/wall.gif" BorderWidth="0" Runat="server" />
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Test Link">
						<ItemTemplate>
							<asp:LinkButton ID="LinkButtonText" CommandName="TestText" CommandArgument='<%# Convert.ToString(Convert.ToInt64(((System.Data.DataRowView)Container.DataItem)["ID"])) %>' Runat="server">Text</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<br>
			ID&nbsp;<asp:textbox id="ChangedId" Runat="server"></asp:textbox>&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="ChangedId" ErrorMessage="Required field" Display="Dynamic" Runat="server"
				id="RequiredFieldValidatorChangedId" />
			<asp:RangeValidator ControlToValidate="ChangedId" ErrorMessage="Id out of range" Type="Integer" Display="Dynamic"
				Runat="server" MinimumValue="1" MaximumValue="1" id="RangeValidatorChangedId" /><br>
			New salary&nbsp;<asp:textbox id="Salary" Runat="server"></asp:textbox>&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="Salary" ErrorMessage="Required field" Display="Dynamic" Runat="server"
				id="RequiredFieldValidatorSalary" />
			<asp:RegularExpressionValidator ControlToValidate="Salary" ValidationExpression="^\d+$|^\d{1,}\.\d{1,2}$" ErrorMessage="Digits only"
				Runat="server" id="RegularExpressionValidatorSalary" /><br>
			<asp:button id="ButtonSave" Runat="server" Text="Save"></asp:button><br>
			<asp:label id="Output" Runat="server"></asp:label></form>
		<table>
			<tr style="FONT-WEIGHT: bold; COLOR: lime; BACKGROUND-COLOR: blue">
			</tr>
		</table>
		<script language="javascript">
function AddDropClick(ID)
{
   var
     tmp,tmpstr="ChangedId";
     
   tmp=document.getElementById(tmpstr);
   
   if(tmp!=null && tmp!=undefined)
     {
        tmp.value=ID;
     }
     
   tmpstr="Salary";
   tmp=document.getElementById(tmpstr);
   
   if(tmp!=null && tmp!=undefined)
     {
        tmp.focus();
     }     
     
   /*  
   var
     i;
     
   for(i=0; i<document.ADONETForm.elements.length; ++i)
   {
      if(tmpstr==document.ADONETForm.elements[i].name)
        break;
   }   
   
   if(i<document.ADONETForm.elements.length)
     document.ADONETForm.elements[i].focus();
   */
}
		</script>
	</body>
</HTML>
