<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewABCForm.aspx.cs" Inherits="AnyTest2_1.GridViewABCForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GridViewABC</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="GridViewABCForm" runat="server">
        <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td>
                    <table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td><asp:TextBox ID="TextBox1" runat="server" /></td>
                            <td><asp:Button ID="Button1" Text=" -> " runat="server" OnClick="Button1_Click" /></td>
                            <td><asp:Label ID="Label1" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" AllowPaging="False" PageSize="2" AllowSorting="true" AutoGenerateColumns="true" OnDataBinding="GridView1_DataBinding" OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" DataKeyNames="Id" AllowPaging="false" PageSize="2" AllowSorting="true" AutoGenerateColumns="false" ShowFooter="true" OnDataBinding="GridView1_DataBinding" OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" runat="server">
                        <Columns>
                            <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
				            <asp:BoundField DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
				            <asp:TemplateField HeaderText="Зряплата" SortExpression="Salary" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right">
					            <ItemTemplate>
						            <%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("Salary") ? Convert.ToDecimal(((System.Data.DataRowView)Container.DataItem)["Salary"]).ToString("c") : "" %>
					            </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
				                <ItemTemplate>
				                    <asp:ImageButton ID="Delete" ImageUrl="../controls/images/wall.gif" AlternateText="Delete" ToolTip="Delete" CausesValidation="false" CommandName="Delete" OnClientClick='<%# Eval("Name", "return confirm(\"Delete the {0}?\");") %>' OnClick="ImageButtonDelete_Click" BorderWidth="0" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
				                <ItemTemplate>
				                    <asp:ImageButton ID="Delete_Alt" ImageUrl="../controls/images/wall.gif" AlternateText="Delete" ToolTip="Delete" CausesValidation="false" CommandName="Delete" OnClientClick='<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("Name") ? "return confirm(\"Delete the "+Convert.ToString(((System.Data.DataRowView)Container.DataItem)["Name"]).Replace("\"","\\\"")+"?\")" : string.Empty %>' OnClick="ImageButtonDelete_Click" BorderWidth="0" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView3" DataKeyNames="Id" AllowPaging="false" PageSize="2" AllowSorting="true" AutoGenerateColumns="false" OnDataBinding="GridView1_DataBinding" OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" runat="server">
                        <Columns>
                            <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
				            <asp:BoundField DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
				            <asp:TemplateField HeaderText="Зряплата" SortExpression="Salary" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right">
					            <ItemTemplate>
						            <%# Convert.ToDecimal(DataBinder.Eval(Container,"DataItem.Salary")).ToString("c") %>
					            </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="Зряплата" SortExpression="Salary" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right">
					            <ItemTemplate>
						            <%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem,"Salary")).ToString("c") %>
					            </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="Зряплата" SortExpression="Salary" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right">
					            <ItemTemplate>
						            <%# Convert.ToDecimal(((System.Data.IDataRecord)Container.DataItem)["Salary"]).ToString("c") %>
					            </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField>
				                <ItemTemplate>
				                    <asp:Button ID="GridView3Button" Text="Push me" OnClick="GridViewButton_Click" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView4" DataKeyNames="Id" AllowPaging="false" PageSize="2" AllowSorting="false" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField DataField="Val" HeaderText="Val" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="#" onclick="alert('<%#Eval("Val")%>');return(false);">DoIt!</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="#" onclick="alert('<%#Eval("Val","{0}")%>');return(false);">DoIt!</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="#" onclick="alert('<%#string.Format("{0}",Eval("Val"))%>');return(false);">DoIt!</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink Text="DoIt!" NavigateUrl="<%$AppSettings:AppSettingsSmthValue%>" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink Text="DoIt!" NavigateUrl="<%#string.Format("{0}",AnyTest2_1.MainForm.SmthStaticMethod(Eval("Val")))%>" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
