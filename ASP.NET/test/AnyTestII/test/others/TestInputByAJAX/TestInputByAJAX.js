function LoadNSI(str, ctrl)
{
	var
		MinLength=3,
		req;
		
	if(str.replace(/\s/g,"").length<MinLength)
	{
		alert("Подстрока поиска должна содержать не менеее "+MinLength+" символа(ов)");
		return;
	}
	
	if(!(req=initXMLHTTPRequest()))
		return;
	
	req.onreadystatechange=function(){
						if(req.readyState==4)
						{
							if(req.status==200)
								ProcessWithNSI(req.responseXML, ctrl);
							else
								alert("status="+req.status+"\r\nstatusText=\""+req.statusText+"\"\r\nresponseText=\""+req.responseText+"\"");

							req=null;
						}
					};
	req.open("POST","TestInputByAJAXHandler.aspx",true);
	req.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	req.send("substr="+encodeURIComponent(str));
}

function ProcessWithNSI(doc, ctrl)
{
	var
		NSIXmlDataRoot=doc.getElementsByTagName("NSIData"),
		NSIXmlDataItems;

	if(NSIXmlDataRoot.length==0)
	{
		alert(NSIXmlDataRoot.length);
		return;
	}
	
	NSIXmlDataItems=NSIXmlDataRoot[0].getElementsByTagName("NSI");
	
	ctrl.options.length=0;	
	for(var i=0; i<NSIXmlDataItems.length; ++i)
		ctrl.options.add(new Option(NSIXmlDataItems[i].getAttribute("text"),NSIXmlDataItems[i].getAttribute("value")));
	
}
