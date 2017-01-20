(function setupOnLoad(global) {
	if(global)
	{
		if(global.addEventListener)
			global.addEventListener("load", onLoad, false);
		else if(global.attachEvent)
			global.attachEvent("onload", onLoad);
		else
			global.onload = onLoad;
	}
	
	function onLoad()
	{
		var img = document.createElement("img");
		
		if(img.addEventListener)
			img.addEventListener("load", toLog, false);
		else if(global.attachEvent)
			img.attachEvent("onload", toLog);
		else
			img.onload = toLog;
		
		img.src = "http://www.sql.ru/forum/images/smoke.gif";
		
		document.body.appendChild(img);
	}
	
	function toLog()
	{
		Log("script.img.onload");
	}
})(this);
