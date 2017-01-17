var WSHShell = WScript.CreateObject("WScript.Shell"); 
var fso = new ActiveXObject("Scripting.FileSystemObject");
if (fso.FileExists("E:\\backup\\command\\stop.end")) 
   {
        fso.MoveFile("E:\\backup\\command\\stop.end", "E:\\backup\\command\\_stop_.end");
   }
objArgs = WScript.Arguments;
var min1=10;
var min2=10;
kl=objArgs.Count();
//WSHShell.Popup(kl);
if (kl > 0) { 
   min1=objArgs(0);
//   WSHShell.Popup("1+"+objArgs(0));
//   WSHShell.Popup("1+"+min1);
  }
if (kl > 1)
  {
   min2=objArgs(1);
//   WSHShell.Popup("2+"+objArgs(1));
//   WSHShell.Popup("2+"+min2);
  }
min1=min1*60000;
min2=min2*60000;
var dt1 = new Date();
var lf = fso.CreateTextFile("Mess"+dt1.getFullYear()+dt1.getMonth()+dt1.getDate()+dt1.getHours()+dt1.getMinutes()+dt1.getSeconds()+".log");
lf.WriteLine("Старт     "+dt1);
var dt2 = new Date(Date.UTC(dt1.getUTCFullYear(),dt1.getUTCMonth(),dt1.getUTCDate(),dt1.getUTCHours(),dt1.getUTCMinutes(),dt1.getUTCSeconds())+min1); 
var dt3 = new Date(Date.UTC(dt2.getUTCFullYear(),dt2.getUTCMonth(),dt2.getUTCDate(),dt2.getUTCHours(),dt2.getUTCMinutes(),dt2.getUTCSeconds())+min2);
var ts = fso.CreateTextFile("D:\\WEB\\bill\\admin\\sysmess.inc");
ts.Write("\\n    Технологічна перерва з "+(((dt2.getHours()<10) ? "0" : "")+dt2.getHours())+"-"+(((dt2.getMinutes()<10) ? "0" : "")+dt2.getMinutes())+" до "+(((dt3.getHours()<10) ? "0" : "")+dt3.getHours())+"-"+(((dt3.getMinutes()<10) ? "0" : "")+dt3.getMinutes())+". \\n\\n            Прохання зберегти всі дані.\\n\\nВ цей час робота з задачею буде неможлива.\\n");
ts.Close();
var dt1 = new Date();
var dt3 = new Date(Date.UTC(dt1.getUTCFullYear(),dt1.getUTCMonth(),dt1.getUTCDate(),dt1.getUTCHours(),dt1.getUTCMinutes(),dt1.getUTCSeconds()));

var mts = fso.CreateTextFile("E:\\backup\\command\\rest_mes.js");
mts.WriteLine("var WSHShell = WScript.CreateObject(\"WScript.Shell\");");
mts.WriteLine("WSHShell.Popup (\"ВНИМАНИЕ!!! Компьютер будет перезагружен. Для отмены перезагрузки необходимо в каталоге возле этого скрипта создать файл STOP.END.\");");
mts.WriteLine("WSHShell.Popup (\"ВНИМАНИЕ!!! И не забудьте очистить файл сообщений D:\\\\WEB\\\\bill\\\\admin\\\\sysmess.inc.\");");

mts.Close();
WSHShell.Run("E:\\backup\\command\\rest_mes.js",0);

while  (dt3 < dt2)
  {
	var dt1 = new Date();
	var dt3 = new Date(Date.UTC(dt1.getUTCFullYear(),dt1.getUTCMonth(),dt1.getUTCDate(),dt1.getUTCHours(),dt1.getUTCMinutes(),dt1.getUTCSeconds()));
      if (fso.FileExists("E:\\backup\\command\\stop.end")) 
        {
         min1=-999;
	        lf.WriteLine("Отмена    "+dt1);	
	      break;
        }
  }
if (min1 != -999)
   {
      lf.WriteLine("Рестарт   "+dt1);
        WSHShell.Run("C:\\WINDOWS\\system32\\shutdown.exe /r /f")
   }
lf.Close();


