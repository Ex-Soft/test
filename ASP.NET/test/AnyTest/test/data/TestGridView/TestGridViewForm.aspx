<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGridViewForm.aspx.cs" Inherits="AnyTest.TestGridViewForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Test GridView</title>
    <style type="text/css">
 .data:hover
 {
     background-color: Lime !important;
 }
    </style>
</head>
<body>
    <form id="TestGridViewForm" runat="server">
        <asp:GridView ID="GridView1" DataKeyNames="Id" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PageSize="2" BorderColor="lightgray" Font-Names="Verdana" Font-Size="8pt" GridLines="vertical" BorderStyle="None" BorderWidth="1" CellPadding="2" Width="100%" BackColor="White" PagerSettings-Position="TopAndBottom" OnRowDataBound="GridView_RowDataBound" runat="server">
            <HeaderStyle ForeColor="white" BackColor="teal" Font-Bold="true" />
			<RowStyle ForeColor="darkblue" BackColor="white" />
			<AlternatingRowStyle ForeColor="darkblue" BackColor="beige" />
			<PagerStyle HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="N п/п" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
                <asp:BoundField DataField="Dep" SortExpression="Dep" HeaderText="Отдел" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
                <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Ф. И. О." HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Salary" SortExpression="Salary" HeaderText="Зряплата" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="right" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
