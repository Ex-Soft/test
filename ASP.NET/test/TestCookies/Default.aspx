<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestCookies._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
function s()
{
    var r;
    
    if (window.XMLHttpRequest)
		r=new XMLHttpRequest();
	else if(window.ActiveXObject)
	{
		try
		{
			r=new ActiveXObject("Msxml2.XMLHTTP");
		}
		catch(e)
		{
			try
			{
				r=new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch(e)
			{
				;
			}
		}
	}

    r.open("POST","Data.aspx",true);
    r.send();
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="submit" onclick="s()" />
    </form>
</body>
</html>
