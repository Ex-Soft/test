$(document).ready(function(){OnLoad("full")});
$(function(){OnLoad("short")});

function OnLoad(arg)
{
	alert("OnLoad(\""+arg+"\")!");

	var
		Ctrl;

	if(Ctrl=$("li + li"))
		alert(typeof(Ctrl));
}

//$("li + li").addClass("classBold");