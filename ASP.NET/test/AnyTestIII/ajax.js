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
