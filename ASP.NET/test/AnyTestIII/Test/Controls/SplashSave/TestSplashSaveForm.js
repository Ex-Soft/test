function OnSubmit()
{
	var
		IsSubmit,
		Ctrl;

	if(IsSubmit=confirm("”вага!\n«берегти введен≥ дан≥?"))
	{	
		if((Ctrl=document.getElementById("DivMainForm")))
			Ctrl.style.display="none";
		if((Ctrl=document.getElementById("DivSplashSave")))
			Ctrl.style.display="block";
		if((Ctrl=document.getElementById("IFrameSplashSave")))
			Ctrl.contentWindow.SplashSaveStart();
	}
	
	return(IsSubmit);
}
