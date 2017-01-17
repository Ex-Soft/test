var
	MSWord=null;

try
{
	if(MSWord=new ActiveXObject("Word.Application"))
	{
		MSWord.Visible=true;
	}
	else
		alert("!Word.Application");
}
catch(Exception)
{
	alert(Exception.name+": "+Exception.message);
}
