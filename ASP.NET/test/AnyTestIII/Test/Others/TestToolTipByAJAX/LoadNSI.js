function _initXMLHTTPRequest_()
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

function _LoadNSIXml_(CallbackFunction, url, params, HttpMethod)
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
		req.onreadystatechange=function(){if(req.readyState==4) CallbackFunction(req.responseXML);};
		req.open(HttpMethod,FileName,true);
		req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		req.send(params);
	}
}
