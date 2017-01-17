var
	wsh=new ActiveXObject("WScript.Shell"),
	AppFileName="E:\\Soft.src\\CBuilder\\Tests\\Stub\\Stub.exe",
	DateStart,
	DateStop;

WScript.Sleep(5000);

DateStart=new Date();
WScript.Echo("Run(\""+AppFileName+"\","+i+",true)");
RetValue=wsh.Run(AppFileName,8,true); /* http://msdn.microsoft.com/en-us/library/d5fk67ky(VS.85).aspx */
DateStop=new Date();
WScript.Echo("RetValue="+RetValue+" "+(DateStop.getTime()-DateStart.getTime())/1000+" sec");

for(var i=0; i<=10; ++i)
{
	DateStart=new Date();
	WScript.Echo("Run(\""+AppFileName+"\","+i+",true)");
	RetValue=wsh.Run(AppFileName,i,true);
	DateStop=new Date();
	WScript.Echo("RetValue="+RetValue+" "+(DateStop.getTime()-DateStart.getTime())/1000+" sec");
}

WScript.Sleep(5000);