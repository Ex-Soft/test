var
	v;

v = [] + [];
WScript.Echo(v);

v = [] + {};
WScript.Echo(v);

v = {} + [];
WScript.Echo(v);

v = {} + {};
WScript.Echo(v);

v = Array(16);
WScript.Echo(v);

v = Array(16).join("wat");
WScript.Echo(v);

v = Array(16).join("wat" + 1);
WScript.Echo(v);

v = Array(16).join("wat" - 1) + " Batman!";
WScript.Echo(v);