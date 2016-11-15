$(function(){OnLoad(false)});

function OnLoad(isObjects)
{
	$.getJSON("GenerateDataJSONHandler.ashx"+(isObjects ? "?q=1" :""),
		{},
		function(data){
			if(!isObjects)
				alert("{id: \""+data.id+"\", name: \""+data.name+"\"}");
			else
				$.each(data, function(i,item){
					alert("["+i+"]={id: \""+item.id+"\", name: \""+item.name+"\"}");
				});
		});
}