<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageWithXHR.aspx.cs" Inherits="TestFormAuthentication.PageWithXHR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; utf-8" />
        <title>&laquo;Page with XMLHttpRequest&raquo;</title>
        <script type="text/javascript">
<!--
function DoIt()
{
    var
        req,
        Ctrl,
        CtrlStatus,
        cb,
        inpt,
        code,
        CheckBoxWriteToResponse,
        username = "login",
        password = "1";

	if(!(req=initXMLHTTPRequest())
        || !(CtrlStatus=document.getElementById("DivStatus"))
	    || !(Ctrl=document.getElementById("DivResponse"))
	    || !(cb=document.getElementById("cbGenerateStatusCode"))
	    || !(inpt=document.getElementById("InputTextStatusCode"))
	    || !(CheckBoxWriteToResponse=document.getElementById("cbWriteToResponse")))
		return;

    CtrlStatus.innerHTML="";

	req.onreadystatechange=function()
							{
							    CtrlStatus.innerHTML+=req.readyState + ":" + req.status + " ";
	    
								if(req.readyState==4)
								{
								    if(req.status==200)
								    {
								        var
								            headers = req.getAllResponseHeaders();
								        
										Ctrl.innerHTML=req.responseText;
							        }
									else
										alert("status="+req.status+"\r\nstatusText=\""+req.statusText+"\"");

									req=null;
								}
							};

	req.open("POST","PageWithXHRHandler.aspx",true,username,password);
	req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	req.setRequestHeader("X-Requested-With","XMLHttpRequest");
	req.send(cb.checked && !isNaN(code=parseInt(inpt.value,10)) ? "statuscode="+encodeURIComponent(code.toString())+"&writetoresponse="+encodeURIComponent(CheckBoxWriteToResponse.checked.toString()) : null);
}

function initXMLHTTPRequest()
{
	var
		xRequest=null;

	if(window.XMLHttpRequest)
		xRequest=new XMLHttpRequest();
	else if(window.ActiveXObject)
	{
		try
		{
			xRequest=new ActiveXObject("Msxml2.XMLHTTP");
		}
		catch(e)
		{
			try
			{
				xRequest=new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch(e)
			{
				alert(e.name+": "+e.message);
			}
		}
	}

	return(xRequest);
}
// -->
        </script>
    </head>
    <body>
        <form id="PageWithXHRForm" runat="server">
            <h1 style="text-align: center;">Page with XMLHttpRequest</h1>
            <hr />
            <label for="cbGenerateStatusCode">Generate StatusCode</label> <input type="checkbox" id="cbGenerateStatusCode" name="cbGenerateStatusCode" /> <label for="InputTextStatusCode">StatusCode:</label> <input type="text" id="InputTextStatusCode" name="InputTextStatusCode" /> <label for="cbWriteToResponse">Write smth to response</label> <input type="checkbox" id="cbWriteToResponse" name="cbWriteToResponse" /> <input type="button" value="DoIt!" onclick="DoIt()" />
            <hr />
            <div id="DivStatus"></div>
            <div id="DivResponse"></div>
        </form>
    </body>
</html>
