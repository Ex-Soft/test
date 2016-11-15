function SetPageLoadInfo(VarStartLoadName,SpanStartedId,SpanFinishedId,SpanDiffTimeId)
{
	var
		finish=new Date();

	if(!(VarStartLoadName in this))
		return;

	var
		Ctrl,
		start;

	eval("start="+VarStartLoadName);

	Ctrl = typeof(SpanStartedId)=="string" ? document.getElementById(SpanStartedId) : SpanStartedId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=PadL(start.getHours().toString(),2,"0")+":"+PadL(start.getMinutes().toString(),2,"0")+":"+PadL(start.getSeconds().toString(),2,"0")+"."+start.getMilliseconds();

	Ctrl = typeof(SpanFinishedId)=="string" ? document.getElementById(SpanFinishedId) : SpanFinishedId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=PadL(finish.getHours().toString(),2,"0")+":"+PadL(finish.getMinutes().toString(),2,"0")+":"+PadL(finish.getSeconds().toString(),2,"0")+"."+finish.getMilliseconds();

	Ctrl = typeof(SpanDiffTimeId)=="string" ? document.getElementById(SpanDiffTimeId) : SpanDiffTimeId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=(finish-start)/1000;
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
