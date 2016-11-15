var
	SecondsCount,
	SplashSaveHandler,
	PropellerStr="|/-\\",
	SecondsCountMax=300,
	SecondsCountMaxMessage="Зв\'язок з сервером втрачено.\r\nПеревірте чи зберіглася інформація, що Ви вводили.";

function SplashSaveStart()
{
	SecondsCount=1;
	SplashSaveHandler=setInterval(SplashSaveDo,1000);
}

function SplashSaveStop()
{
	clearInterval(SplashSaveHandler);
}

function SplashSaveDo()
{
	var
		Ctrl;

	if(Ctrl=document.getElementById("SpanPropeller"))
		Ctrl.innerHTML=PropellerStr.charAt(SecondsCount%4);
	if(Ctrl=document.getElementById("SpanStopWatch"))
		Ctrl.innerHTML=SecondsCount++;
	if(SecondsCount==SecondsCountMax)
		alert(SecondsCountMaxMessage);
}

function getArgs()
{
	var
		args=new Object(),
		query=location.search.substring(1),
		pairs=query.split("&"),
		pos,
		argname,
		value;

	for(var i=0; i<pairs.length; ++i)
	{
		pos=pairs[i].indexOf("=");
		if(pos==-1)
			continue;
		argname=pairs[i].substring(0,pos);
		value=pairs[i].substring(pos+1);
		args[argname.toLowerCase()]=unescape(value);
		//args[argname]=decodeURIComponent(value);
	}

	return(args);
}

function CheckArgs()
{
	var
		args=getArgs();

	if(args.message)
	{
		var
			Ctrl;

		if(Ctrl=document.getElementById("PMess"))
			Ctrl.innerHTML=args.message;
	}
}