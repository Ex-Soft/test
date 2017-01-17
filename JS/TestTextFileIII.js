var
	ForReading=1, /* http://msdn.microsoft.com/en-us/library/hwfw5c59(VS.85).aspx */
	ForWriting=2,
	ForAppending=8,
	fso=new ActiveXObject("Scripting.FileSystemObject"),
        LogFileName="stub.log",
	lf,
	ts,
	s;

if(fso.FileExists(LogFileName))
{
	lf=fso.GetFile(LogFileName);
	ts=lf.OpenAsTextStream(ForReading)
	while(!ts.AtEndOfStream)
	{
		s=ts.ReadLine();
		WScript.Echo(s)
	}
   	ts.Close();
}
