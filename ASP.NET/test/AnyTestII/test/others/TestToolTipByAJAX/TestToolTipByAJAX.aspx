<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestToolTipByAJAX.aspx.cs" Inherits="AnyTestII.TestToolTipByAJAXForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
    <title>Test ToolTip By AJAX</title>
    <script type="text/javascript" charset="windows-1251" src="LoadNSI.js"></script>
	<script type="text/javascript">
<!--
var
	//TEST_STRING_IN_XML_WITH_1251=false;
	TEST_STRING_IN_XML_WITH_1251=true;
	
function ShowToolTip(obj)
{
	if(!obj)
		return;
		
	if(!("arr" in window))
	{
		eval("arr=new Array()");
		
		var
			Ctrl;
			
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if(Ctrl=document.getElementById("DivSplashSave"))
			Ctrl.style.display="block";
		if(Ctrl=document.getElementById("IFrameSplashSave"))
			Ctrl.contentWindow.SplashSaveStart();

		LoadToolTip("data.dat");
	}
	
	if(arr[obj.id]!=undefined)
		alert(arr[obj.id]);
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

function LoadToolTip(url, params, HttpMethod)
{
	if(req=initXMLHTTPRequest())
	{
		var
			FileName=document.location.href,
			pos=FileName.lastIndexOf("/");

		if(pos!=-1)
			FileName=FileName.substr(0,pos+1)+url;
		if(!HttpMethod)
			HttpMethod="GET";
		req.onreadystatechange=onReadyState;
		req.open(HttpMethod,FileName,true);
		req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		req.send(params);
	}
}

function onReadyState()
{
	if(req.readyState==4)
		AppendInfo(req.responseText);
}

function AppendInfo(data)
{
	var
		lines,
		Ctrl;

	data=data.replace(/\s/g,"");
	lines=data.split(/[;\s]/);
	
	for(var i=0; i<lines.length; ++i)
		if(lines[i].length)
			eval(lines[i]);
		else
			continue;
			
	if((Ctrl=document.getElementById("DivMainForm")))
		Ctrl.style.display="block";
	if(Ctrl=document.getElementById("DivSplashSave"))
		Ctrl.style.display="none";
	if(Ctrl=document.getElementById("IFrameSplashSave"))
		Ctrl.contentWindow.SplashSaveStop();
}
//---------------------------------------------------------------------------

function CreateNSITxt()
{
	if(!("NSITxt" in window))
	{
		eval("NSITxt=new Array()");
		
		var
			Ctrl;
			
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if(Ctrl=document.getElementById("DivSplashSave"))
			Ctrl.style.display="block";
		if(Ctrl=document.getElementById("IFrameSplashSave"))
			Ctrl.contentWindow.SplashSaveStart();

		LoadNSITxt("CreateNSIForm.aspx");
	}
	else
		alert("(\"NSITxt\" in window)");
}

function LoadNSITxt(url, params, HttpMethod)
{
	if(req=initXMLHTTPRequest())
	{
		var
			FileName=document.location.href,
			pos=FileName.lastIndexOf("/");

		if(pos!=-1)
			FileName=FileName.substr(0,pos+1)+url+"?mode=txt";
		if(!HttpMethod)
			HttpMethod="GET";
		req.onreadystatechange=onReadyStateTxt;
		req.open(HttpMethod,FileName,true);
		req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		req.send(params);
	}
}

function onReadyStateTxt()
{
	if(req.readyState==4)
		AppendInfoTxt(req.responseText);
}

function AppendInfoTxt(data)
{
	var
		lines,
		Ctrl;

	data=data.replace(/\s/g,"");
	lines=data.split(/[;\s]/);
	
	for(var i=0; i<lines.length; ++i)
		if(lines[i].length)
			eval(lines[i]);
		else
			continue;
			
	if((Ctrl=document.getElementById("DivMainForm")))
		Ctrl.style.display="block";
	if(Ctrl=document.getElementById("DivSplashSave"))
		Ctrl.style.display="none";
	if(Ctrl=document.getElementById("IFrameSplashSave"))
		Ctrl.contentWindow.SplashSaveStop();
}

function ShowNSITxt()
{
	if("NSITxt" in window)
	{
		var
			str="";

		for(var i=0; i<NSITxt.length; ++i)
			if(NSITxt[i]!=undefined)
				str+="NSITxt["+i+"]="+NSITxt[i]+"\r\n";
			
		alert(str);
	}
	else
		alert("!(\"NSITxt\" in window)");
}
//---------------------------------------------------------------------------

function CreateNSIXml()
{
	if(!("NSIXml" in window))
	{
		eval("NSIXml=new Array()");
		
		var
			Ctrl;
			
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if(Ctrl=document.getElementById("DivSplashSave"))
			Ctrl.style.display="block";
		if(Ctrl=document.getElementById("IFrameSplashSave"))
			Ctrl.contentWindow.SplashSaveStart();

		LoadNSIXml("CreateNSIForm.aspx");
	}
	else
		alert("(\"NSIXml\" in window)");
}

function LoadNSIXml(url, params, HttpMethod)
{
	if(req=initXMLHTTPRequest())
	{
		var
			FileName=document.location.href,
			pos=FileName.lastIndexOf("/");

		if(pos!=-1)
			FileName=FileName.substr(0,pos+1)+url+"?mode=xml";
		if(!HttpMethod)
			HttpMethod="GET";
		req.onreadystatechange=onReadyStateXml;
		req.open(HttpMethod,FileName,true);
		req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		req.send(params);
	}
}

function onReadyStateXml()
{
	if(req.readyState==4)
		AppendInfoXml(req.responseXML);
}

function AppendInfoXml(doc)
{
	var
		NSIXmlDataRoot=doc.getElementsByTagName("NSIXmlData"),
		NSIXmlDataItems;

	if(NSIXmlDataRoot.length==0)
	{
		alert(NSIXmlDataRoot.length);
		return;
	}
	
	NSIXmlDataItems=NSIXmlDataRoot[0].getElementsByTagName("NSIXml")
	
	for(var i=0; i<NSIXmlDataItems.length; ++i)
		NSIXml[parseInt(NSIXmlDataItems[i].getAttribute("Index"),10)] = TEST_STRING_IN_XML_WITH_1251 ? NSIXmlDataItems[i].getAttribute("Value") : parseInt(NSIXmlDataItems[i].getAttribute("Value"),10);

	if((Ctrl=document.getElementById("DivMainForm")))
		Ctrl.style.display="block";
	if(Ctrl=document.getElementById("DivSplashSave"))
		Ctrl.style.display="none";
	if(Ctrl=document.getElementById("IFrameSplashSave"))
		Ctrl.contentWindow.SplashSaveStop();
}

function ShowNSIXml()
{
	if("NSIXml" in window)
	{
		var
			str="";

		for(var i=0; i<NSIXml.length; ++i)
			if(NSIXml[i]!=undefined)
				str+="NSIXml["+i+"]="+NSIXml[i]+"\r\n";
			
		alert(str);
	}
	else
		alert("!(\"NSIXml\" in window)");
}
//---------------------------------------------------------------------------

function CreateNSIXmlSync()
{
	if(!("NSIXml" in window))
	{
		eval("NSIXml=new Array()");
		
		var
			Ctrl;
			
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if(Ctrl=document.getElementById("DivSplashSave"))
			Ctrl.style.display="block";
		if(Ctrl=document.getElementById("IFrameSplashSave"))
			Ctrl.contentWindow.SplashSaveStart();

		LoadNSIXmlSync("CreateNSIForm.aspx");
	}
	else
		alert("(\"NSIXml\" in window)");
}

function LoadNSIXmlSync(url, params, HttpMethod)
{
	if(req=initXMLHTTPRequest())
	{
		var
			FileName=document.location.href,
			pos=FileName.lastIndexOf("/");

		if(pos!=-1)
			FileName=FileName.substr(0,pos+1)+url+"?mode=xml";
		if(!HttpMethod)
			HttpMethod="GET";
		req.open(HttpMethod,FileName,false);
		req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		req.send(params);
		if(req.readyState==4)
		{
			switch(req.status)
			{
				case 200 :
				{
					AppendInfoXmlSync(req.responseXML);
					
					break;
				}
				case 404 :
				{
					alert("!"+FileName);

					break;
				}
			}
		} 
	}
}

function AppendInfoXmlSync(doc)
{
	var
		NSIXmlDataRoot=doc.documentElement; //doc.lastChild;

	// alert("doc.childNodes.length="+doc.childNodes.length);

	if(!NSIXmlDataRoot)
	{
		alert("!doc.documentElement");
		return;
	}
	
	for(var Node=NSIXmlDataRoot.firstChild; Node; Node=Node.nextSibling)
		NSIXml[parseInt(Node.getAttribute("Index"),10)] = TEST_STRING_IN_XML_WITH_1251 ? Node.getAttribute("Value") : parseInt(Node.getAttribute("Value"),10)*Node.firstChild.data+" ("+Node.getAttribute("Value")+"*"+Node.firstChild.data+")";
	
	if((Ctrl=document.getElementById("DivMainForm")))
		Ctrl.style.display="block";
	if(Ctrl=document.getElementById("DivSplashSave"))
		Ctrl.style.display="none";
	if(Ctrl=document.getElementById("IFrameSplashSave"))
		Ctrl.contentWindow.SplashSaveStop();
}
//---------------------------------------------------------------------------

function CreateNSIXmlExtern()
{
	if(!("NSIXml" in window))
	{
		eval("NSIXml=new Array()");
		
		var
			Ctrl;
			
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if(Ctrl=document.getElementById("DivSplashSave"))
			Ctrl.style.display="block";
		if(Ctrl=document.getElementById("IFrameSplashSave"))
			Ctrl.contentWindow.SplashSaveStart();

		_LoadNSIXml_(AppendInfoXmlSync,"CreateNSIForm.aspx");
	}
	else
		alert("(\"NSIXml\" in window)");
}
//---------------------------------------------------------------------------
// -->
	</script>
</head>
<body>
	<div id="DivSplashSave" style="display: none; ">
		<iframe id="IFrameSplashSave" name="IFrameSplashSave" src="SplashSave.html?message=Зачекайте, завантажується НСІ..." frameborder="0" scrolling="no" style="width: 100%; height: 100%; border-style: none; "></iframe>
	</div>
	<div id="DivMainForm">
        <form id="TestToolTipByAJAXForm" runat="server">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
	            <tr>
		            <td>
			            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
				            <tr>
					            <td><input type="button" id="Button1" value="Do It! (Button1)" onclick="ShowToolTip(this)" /></td>
					            <td><input type="button" id="Button2" value="Do It! (Button2)" onclick="ShowToolTip(this)" /></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
	            <tr>
		            <td>
			            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
				            <tr>
					            <td><input type="button" id="ButtonCreateNSITxt" value="Create NSI (txt)" onclick="CreateNSITxt()" /></td>
					            <td><input type="button" id="ButtonShowNSITxt" value="Show NSI (txt)" onclick="ShowNSITxt()" /></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
	            <tr>
		            <td>
			            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
				            <tr>
					            <td><input type="button" id="ButtonCreateNSIXml" value="Create NSI (xml)" onclick="CreateNSIXml()" /></td>
					            <td><input type="button" id="ButtonShowNSIXml" value="Show NSI (xml)" onclick="ShowNSIXml()" /></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
	            <tr>
		            <td>
			            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
				            <tr>
					            <td><input type="button" id="ButtonCreateNSIXmlSync" value="Create NSI (xml) (sync)" onclick="CreateNSIXmlSync()" /></td>
					            <td><input type="button" id="ButtonShowNSIXmlSync" value="Show NSI (xml) (sync)" onclick="ShowNSIXml()" /></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
	            <tr>
		            <td>
			            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; ">
				            <tr>
					            <td><input type="button" id="ButtonCreateNSIXmlExtern" value="Create NSI (xml) (extern)" onclick="CreateNSIXmlExtern()" /></td>
					            <td><input type="button" id="ButtonShowNSIXmlExtern" value="Show NSI (xml)" onclick="ShowNSIXml()" /></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
            </table>
        </form>
    </div>
</body>
</html>
