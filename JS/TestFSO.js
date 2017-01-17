var
	WSHShell=WScript.CreateObject("WScript.Shell"),
	fso=new ActiveXObject("Scripting.FileSystemObject"),
	f=fso.GetFolder("c:"),
	fc=new Enumerator(f.SubFolders),
	s="";

for(; !fc.atEnd(); fc.moveNext())
	s+=fc.item()+"\r\n";

WSHShell.Popup(s);

f=fso.GetFolder("e:\\temp");
fc=fc=new Enumerator(f.Files);
s="";

for(; !fc.atEnd(); fc.moveNext())
	s+=fc.item().name+" "+fc.item().DateCreated+"\r\n";

WSHShell.Popup(s);