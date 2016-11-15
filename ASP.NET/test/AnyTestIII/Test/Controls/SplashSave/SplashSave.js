var
	SecondsCount,
	SplashSaveHandler,
	PropellerStr="|/-\\";

function SplashSaveStart()
{
	SecondsCount=1;
	SplashSaveHandler=setInterval(SplashSaveDo,1000);
}

function SplashSaveDo()
{
	var
		Ctrl;

	if(Ctrl=document.getElementById("SpanPropeller"))
		Ctrl.innerHTML=PropellerStr.charAt(SecondsCount%4);
	if(Ctrl=document.getElementById("SpanStopWatch"))
		Ctrl.innerHTML=SecondsCount++;
}
