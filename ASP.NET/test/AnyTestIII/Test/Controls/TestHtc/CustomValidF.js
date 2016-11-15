function CheckTextBoxWithDate(source, args)
{
	var
		Ctrl;
	
	if(!(Ctrl=document.getElementById(source.controltovalidate))
		|| IsBlank(args.Value))
	{
		args.IsValid=true;
		return;
	}
	
	Ctrl.value=FormatDateStrDot(Ctrl.value);
	args.IsValid=CheckDateStrDMY(args.Value);
}
