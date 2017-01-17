var
	httpRequestObject;

try
{
	httpRequestObject = WScript.CreateObject("Msxml2.XMLHTTP");
	WScript.Echo("Msxml2.XMLHTTP");
}
catch(e)
{
	try
	{
		httpRequestObject = WScript.CreateObject("Microsoft.XMLHTTP");
		WScript.Echo("Microsoft.XMLHTTP");
	}
	catch(e)
	{
		WScript.Echo("Could not create neither 'MSXML2.XMLHTTP' nor 'MSXML.XMLHTTPRequest' objects. (" + ((e.description!=null)?e.description:e) + ")");
		WScript.Echo("Аварийное завершение работы скрипта  " + WScript.ScriptName);
		WScript.Quit();
	}
}

WScript.Echo(typeof(httpRequestObject));

if(httpRequestObject==null)
{
	WScript.Echo("httpRequestObject==null");
	WScript.Quit();
}
if(httpRequestObject===null)
{
	WScript.Echo("httpRequestObject===null");
	WScript.Quit();
}

if(httpRequestObject==undefined)
{
	WScript.Echo("httpRequestObject==undefined");
	WScript.Quit();
}
if(httpRequestObject===undefined)
{
	WScript.Echo("httpRequestObject===undefined");
	WScript.Quit();
}

WScript.Echo((!("open" in httpRequestObject) ? "!" : "")+"\"open\" in httpRequestObject");

for(var p in httpRequestObject)
	WScript.Echo(p);

if(!httpRequestObject.open)
{
	WScript.Echo("!httpRequestObject.open");
	WScript.Quit();
}

httpRequestObject.open("GET", "localhost/test.html", false);
httpRequestObject.send(null);
WScript.Echo("httpRequestObject.status " + httpRequestObject.status);
if(httpRequestObject.status == 404)
{
	;
}
else
{
	WScript.Echo(httpRequestObject.ResponseBody);
}
