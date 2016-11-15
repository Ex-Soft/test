<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParamFormII.aspx.cs" Inherits="AnyTest.ParamFormII" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ParamForm II</title>
    <script type="text/javascript">
var
    tmpBool=<%=tmpBool.ToString().ToLower()%>,
    tmpBoolII=<%=tmpBoolII.ToString().ToLower()%>,
    tmpBool_=<%#tmpBoolII.ToString().ToLower()%>,
    tmpStringIsEmpty=<%=string.IsNullOrEmpty(tmpString).ToString().ToLower()%>,
    tmpStringIsEmptyII=<%=string.IsNullOrEmpty(tmpStringII).ToString().ToLower()%>,
    tmpStringIsEmpty_=<%#string.IsNullOrEmpty(tmpStringII).ToString().ToLower()%>;
    </script>
</head>
<body>
    <form id="MainForm" runat="server">
        <div visible="<%=(!string.IsNullOrEmpty(tmpStringII)).ToString().ToLower()%>">
            <b>Test</b>
        </div>
        <div>
            <asp:Label ID="LabelURIInfo" runat="server" />
        </div>
    </form>
</body>
</html>
