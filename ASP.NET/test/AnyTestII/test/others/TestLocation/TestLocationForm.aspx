<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Location</title>
    <script type="text/javascript">
<!--
function DoIt(ByReload)
{
    if(ByReload)
        window.location.reload();
    else
        window.location.href=window.location.href;
}
// -->
    </script>
</head>
<body>
    <form id="TestLocationForm" runat="server">
        <asp:Label id="LabelInfo" runat="server" />
        <hr />
        <input type="button" value="href" onclick="DoIt(false)" /><input type="button" value="reload()" onclick="DoIt(true)" />
    </form>
</body>
</html>

<script language="C#" runat="server">
void Page_Load(object sender, EventArgs e)
{
    LabelInfo.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff")+" (IsPostBack="+IsPostBack.ToString().ToLower()+")";
}
</script>