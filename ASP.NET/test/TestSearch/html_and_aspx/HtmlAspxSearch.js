function OnLoad()
{
	var
		Ctrl;

	if(!(Ctrl=parent.document.getElementById("IFrameSearchResult")))
		return;

	Ctrl.contentWindow.location.reload();
}