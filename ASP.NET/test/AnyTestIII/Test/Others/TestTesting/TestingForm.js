var
	hIntervalNextPage=null,
	hIntervalRemainingTimeTimer=null,
	SecondsCount,
	PropellerStr="|/-\\";

function OnLoad()
{
	if(!("DelaySleepNextPage" in this)
		|| !DelaySleepNextPage)
		return;

	SecondsCount=DelaySleepNextPage;
	RemainingTimeTimerDo();
	hIntervalNextPage=setInterval("GoToNextPage()",DelaySleepNextPage*1000);
	hIntervalRemainingTimeTimer=setInterval("RemainingTimeTimerDo()",1000);
}

function clInterval()
{
	if(hIntervalNextPage)
		clearInterval(hIntervalNextPage);
	if(hIntervalRemainingTimeTimer)
		clearInterval(hIntervalRemainingTimeTimer);
}

function GoToNextPage()
{
	clInterval();
	document.forms[0].submit();
}

function RemainingTimeTimerDo()
{
	var
		Ctrl;

	if(Ctrl=document.getElementById("SpanRemainingTimePropeller"))
		Ctrl.innerHTML=PropellerStr.charAt(SecondsCount%4);
	if(Ctrl=document.getElementById("SpanRemainingTimeTimer"))
		Ctrl.innerHTML=SecondsCount--;
}