var
	wsh=WScript.CreateObject("WScript.Shell");

wsh.Run('cmd /k echo y|del "e:\\Program Files\\test\\*.*" & exit');
/* wsh.Exec('del "e:\\Program Files\\test\\*.*"'); */