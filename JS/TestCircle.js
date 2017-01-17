var
	ForReading=1,
	wsh=WScript.CreateObject("WScript.Shell"),
	fso=new ActiveXObject("Scripting.FileSystemObject"),
	StartId=0,
	Delta=10000,
	StopId=StartId+Delta,
	AppFileName="E:\\Soft.src\\CBuilder\\Tests\\Stub\\Stub.exe",
        LogFileName="stub",
	LogFileExt=".log",
	LogFileNameFull=LogFileName+LogFileExt,
	LogFileNameFullNew,
	LogFile,
	ts,
	s,
	HasError,
	DateStart,
	DateStop;

while(StartId<=20000) /* 555989 */
{
	WScript.Echo("StartId="+StartId+" StopId="+StopId);
	DateStart=new Date();
	RetValue=wsh.Run(AppFileName+" "+StartId+" "+StopId,0,true);
	DateStop=new Date();
	WScript.Echo("RetValue="+RetValue+" "+(DateStop.getTime()-DateStart.getTime())/1000+" sec");
	if(fso.FileExists(LogFileName+LogFileExt))
	{
		HasError=false;
		LogFile=fso.GetFile(LogFileName+LogFileExt);
		ts=LogFile.OpenAsTextStream(ForReading)
		while(!ts.AtEndOfStream)
		{
			s=ts.ReadLine();
			if(s.indexOf("finished")!=-1)
			{
				HasError=true;
				WScript.Echo("Yes!");
				break;
			}
		}
   		ts.Close();

		if(fso.FileExists(LogFileNameNew=LogFileName+"_"+StartId+"_"+StopId+LogFileExt))
			fso.DeleteFile(LogFileNameNew);
		LogFile.Move(LogFileNameNew);
	}

	if(!HasError)
	{
		StartId=StopId+1;
		StopId=StartId+Delta;
	}
}

WScript.Sleep(5000);