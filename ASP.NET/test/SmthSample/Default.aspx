<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmthSample.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Main Page</title>
    <meta name="vs_snapToGrid" content="False" />
    <script type="text/javascript" charset="windows-1251" src="/MainForm.js"></script>
</head>
<body>
    <form id="MainPageForm" runat="server">
        <asp:GridView ID="GridView1" DataKeyNames="Id" AutoGenerateColumns="false" runat="server">
            <HeaderStyle ForeColor="white" BackColor="teal" Font-Bold="true" />
			<RowStyle ForeColor="darkblue" BackColor="white" />
			<AlternatingRowStyle ForeColor="darkblue" BackColor="beige" />
            <Columns>
                <asp:BoundField DataField="Value" HeaderText="Value" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <input type="button" value="Edit" onclick="OpenDetail(<%#Convert.ToInt64(((System.Data.DataRowView)Container.DataItem)["Id"]).ToString()%>)" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <input type="button" value="Add" onclick="OpenDetail(null)" />
    </form>
</body>
</html>