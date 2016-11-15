<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSqlDataSourceForm.aspx.cs" Inherits="AnyTest2_1.TestSqlDataSourceForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test SqlDataSource</title>
   	<meta name="vs_snapToGrid" content="False" />
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
</head>
<body>
    <form id="TestSqlDataSourceForm" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" ProviderName="System.Data.OleDb" ConnectionString="<%$ ConnectionStrings:SybaseASEServerFull %>" DataSourceMode="DataSet" SelectCommand="select * from staff order by id" runat="server" />
        <asp:ListBox ID="ListBox1" DataSourceID="SqlDataSource1" DataValueField="id" DataTextField="name" size="5" runat="server" />
        <asp:GridView ID="GridView1" DataSourceID="SqlDataSource1" AutoGenerateColumns="true" AllowPaging="True" PageSize="2" OnDataBound="CustomersGridView_DataBound" runat="server">
            <pagerstyle forecolor="Blue" backcolor="LightBlue" />
            <pagertemplate>
                <table width="100%">                    
                    <tr>                        
                        <td width="70%">
                            <asp:label id="MessageLabel" forecolor="Blue" text="Select a page:" runat="server"/>
                            <asp:dropdownlist id="PageDropDownList" autopostback="true" onselectedindexchanged="PageDropDownList_SelectedIndexChanged" runat="server"/>
                        </td>   
                        <td width="70%" align="right">
                            <asp:label id="CurrentPageLabel" forecolor="Blue" runat="server"/>
                        </td>
                    </tr>                    
                </table>
            </pagertemplate> 
        </asp:GridView>
        <asp:DropDownList ID="DropDownList1" DataSourceID="SqlDataSource1" DataValueField="id" DataTextField="name" AutoPostBack="true" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource2" ProviderName="System.Data.OleDb" ConnectionString="<%$ ConnectionStrings:SybaseASEServerFull %>" DataSourceMode="DataSet" SelectCommandType="StoredProcedure" SelectCommand="sp_SalaryMaxList" runat="server" OnSelected="SqlDataSource2_Selected">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="MaxCount" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br/>
        <asp:Literal ID="LiteralError" runat="server" />
        <br/>
        <asp:GridView ID="GridView2" DataSourceID="SqlDataSource2" AutoGenerateColumns="true" runat="server" />
        <br/>
        <asp:SqlDataSource ID="SqlDataSource3" ProviderName="System.Data.OleDb" ConnectionString="<%$ ConnectionStrings:SybaseASEServerFull %>" DataSourceMode="DataSet" SelectCommand="select * from staff order by id" runat="server" />
        <asp:GridView ID="GridView3" DataSourceID="SqlDataSource3" AutoGenerateColumns="false" OnDataBound="GridView3_DataBound" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="Dep">
                    <ItemTemplate>
                        <img src="<%# Convert.ToInt32(DataBinder.Eval(Container,"DataItem.Dep"))==1 ? "images\\small\\mm_01_small.jpg" : "images\\small\\mm_05_small.jpg" %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dep">
                    <ItemTemplate>
                        <img src="<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem,"Dep"))==1 ? "images\\small\\mm_01_small.jpg" : "images\\small\\mm_05_small.jpg" %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dep">
                    <ItemTemplate>
                        <img src="<%# !((System.Data.DataRowView)Container.DataItem).Row.IsNull("Dep") ? (Convert.ToInt32(((System.Data.DataRowView)Container.DataItem)["Dep"])==1 ? "images\\small\\mm_01_small.jpg" : "images\\small\\mm_05_small.jpg") : "images\\small\\mm_02_small.jpg" %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField HeaderText="Dep" DataImageUrlField="Dep" DataImageUrlFormatString="images\small\mm_0{0}_small.jpg" />
            </Columns>
        </asp:GridView>
        <br/>
        <asp:SqlDataSource ID="SqlDataSource4" ProviderName="System.Data.OleDb" ConnectionString="<%$ ConnectionStrings:SybaseASEServerFull %>" DataSourceMode="DataSet" SelectCommand="select * from staff where BirthDate = ? order by id" OnSelecting="SqlDataSource4_Selecting" runat="server">
            <SelectParameters>
                <asp:Parameter Name="BirthDate" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView4" DataSourceID="SqlDataSource4" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:dd.MM.yyyy}" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
