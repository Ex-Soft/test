function SetPageLoadInfo(VarStartLoadName,SpanStartedId,SpanFinishedId,SpanDiffTimeId)
{
	var
		finish=new Date();

	if(arguments.length<4)
		throw new Error("Too few parameters in call to 'SetPageLoadInfo(VarStartLoadName,SpanStartedId,SpanFinishedId,SpanDiffTimeId)'");

	if(!(VarStartLoadName in this))
		return;

	var
		Ctrl,
		start;

	eval("start="+VarStartLoadName);

	Ctrl = typeof(SpanStartedId)=="string" ? document.getElementById(SpanStartedId) : SpanStartedId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=start.getHours()+":"+start.getMinutes()+":"+start.getSeconds()+"."+start.getMilliseconds();

	Ctrl = typeof(SpanFinishedId)=="string" ? document.getElementById(SpanFinishedId) : SpanFinishedId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=finish.getHours()+":"+finish.getMinutes()+":"+finish.getSeconds()+"."+finish.getMilliseconds();

	Ctrl = typeof(SpanDiffTimeId)=="string" ? document.getElementById(SpanDiffTimeId) : SpanDiffTimeId;
	if(!Ctrl)
		return;
	Ctrl.innerHTML=(finish-start)/1000;
}