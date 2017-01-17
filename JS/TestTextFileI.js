var
	ForReading=1, /* http://msdn.microsoft.com/en-us/library/314cz14s(VS.85).aspx */
	ForWriting=2,
	ForAppending=8,
	fso=new ActiveXObject("Scripting.FileSystemObject"),
        LogFileName="stub.log",
	ts,
	s;

if(fso.FileExists(LogFileName))
{
	ts=fso.OpenTextFile(LogFileName,ForReading);

	s=ts.ReadAll();
	WScript.Echo(s);

	ts.Close();
}

