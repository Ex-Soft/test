var
	hInterval=null,
	PropellerStr="|/-\\";

function OnLoad()
{
	ShowTime();
	hInterval=setInterval("ShowTime()",1000);
}

function clInterval()
{
	if(hInterval)
		clearInterval(hInterval);
}

function ShowTime()
{
	var
		DateNow=new Date(),
		SecondsCount=DateNow.getSeconds(),
		Ctrl;

	if(Ctrl=document.getElementById("SpanTime"))
		Ctrl.innerHTML=PadL(DateNow.getHours().toString(),2,"0")+":"+PadL(DateNow.getMinutes().toString(),2,"0")+":"+PadL(SecondsCount.toString(),2,"0")+"."+PadR(DateNow.getMilliseconds().toString(),7,"0");
	if(Ctrl=document.getElementById("SpanHelicopter"))
		Ctrl.innerHTML=PropellerStr.charAt(SecondsCount%4);
}

function PadL(aStr,aLen,aFillChar)
{
   if(aStr.length>=aLen)
     return(aStr);

   if(arguments.length==2)
     aFillChar=" ";

   var
     PadCount=aLen-aStr.length;
     PadStr="";

   for(var i=0; i<PadCount; ++i)
      PadStr+=aFillChar;

   return(PadStr+aStr);
}

function PadR(aStr,aLen,aFillChar)
{
   if(aStr.length>=aLen)
     return(aStr);

   if(arguments.length==2)
     aFillChar=" ";

   var
     PadCount=aLen-aStr.length;
     PadStr="";

   for(var i=0; i<PadCount; ++i)
      PadStr+=aFillChar;

   return(aStr+PadStr);
}
