<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewFullForm.aspx.cs" Inherits="AnyTest2_1.GridViewFullForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GridView (Full)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
    <meta name="vs_snapToGrid" content="False">
    <script type="text/javascript">
<!--
var
    Counter=0,
    LastValue="";
    
function DoIt(obj, text)
{
	var
		Ctrl;

	if(!(Ctrl=document.getElementById("Label1")))
		return;

    Counter+=obj.checked ? 1 : -1;
    if(obj.checked)
    {
        LastValue=Ctrl.innerHTML;
        Ctrl.innerHTML=text;
    }
    else
    {
        if(!Counter)
            LastValue="";
        Ctrl.innerHTML=LastValue;
    }
        
	Ctrl.style.display=Ctrl.innerHTML!="" ? "block" : "none";
}
// -->
    </script>
</head>
<body>
    <form id="GridViewFullForm" runat="server">
    <div>
        <asp:GridView ID="GridViewFull" DataKeyNames="Id" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PageSize="2" BorderColor="lightgray" Font-Names="Verdana" Font-Size="8pt" GridLines="vertical" BorderStyle="None" BorderWidth="1" CellPadding="2" Width="100%" BackColor="White" PagerSettings-Position="TopAndBottom" runat="server" OnSorting="GridView_Sorting" OnPageIndexChanging="GridView_PageIndexChanging" OnRowDataBound="GridView_RowDataBound" OnRowCommand="GridView_RowCommand">
            <HeaderStyle ForeColor="white" BackColor="teal" Font-Bold="true" />
			<RowStyle ForeColor="darkblue" BackColor="white" />
			<AlternatingRowStyle ForeColor="darkblue" BackColor="beige" />
			<PagerStyle HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="N п/п" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
				<asp:BoundField DataField="Dep" SortExpression="Dep" HeaderText="Отдел" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
				<asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
				<asp:BoundField DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
				<asp:TemplateField HeaderText="ДР" SortExpression="BirthDate" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
					<ItemTemplate>
						<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("BirthDate") ? Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["BirthDate"]).ToString("dd.MM.yyyy") : "" %>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="CheckBox" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
					<ItemTemplate>
						<asp:CheckBox ID="tmpCheckBox" Runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:ButtonField ButtonType="Link" CommandName="aaa" Text="LinkButton" />
    			<asp:ButtonField ButtonType="Button" CommandName="bbb" Text="PushButton" />
	            <asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton id="LinkButtonDelete" CommandName="Delete" CausesValidation="false" runat="server">
							<img src="../controls/images/wall.gif" alt="Видалити" style="cursor:pinter; " border="0">
						</asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField>
				    <ItemTemplate>
				        <input type="button" value="Push Me" onclick="alert('<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("BirthDate") ? Convert.ToDateTime(((System.Data.DataRowView)Container.DataItem)["BirthDate"]).ToString("dd.MM.yyyy") : "" %>')" />
				    </ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField>
				    <ItemTemplate>
				        <asp:CheckBox id="chkRow" runat="server" />
				    </ItemTemplate>
				</asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" style="display: none; " runat="server" />
    </div>
    </form>
</body>
</html>
