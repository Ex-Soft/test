var
	d,
	dd;

d=new Date(2011, 2, 30);
dd=new Date(2011, 2, 30);

WScript.Echo("d==dd "+(d==dd)); /* false */
WScript.Echo("d===dd "+(d===dd)); /* false */

dd=d=new Date(2011, 2, 30);
WScript.Echo("d==dd "+(d==dd)); /* true */
WScript.Echo("d===dd "+(d===dd)); /* true */
