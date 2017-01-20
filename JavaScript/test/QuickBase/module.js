(function(win){
	var
		querystring=document.location.search,
		msg="";

	if (/dlta=mog/.test(querystring)) {
		//GRID EDIT PAGE ========================================
		msg="You are on the Grid Edit Page";
	} else if(/a=er/.test(querystring)) {
		//EDIT RECORD PAGE ========================================
		msg="You are on the Edit Record Page";
	} else if (/GenNewRecord/.test(querystring)) {
		//ADD RECORD PAGE ========================================
		msg="You are on the Add Record Page";
	} else if(/a=dr/.test(querystring)) {
		//DISPLAY RECORD PAGE
		$("img[qbu=module]").closest("td").css("background-color","#FFFFFF");
		msg="You are on the Display Record Page";
	} else if(/a=q/.test(querystring)) {
		//REPORT PAGE ========================================
		msg="You are on the Report Listing Page";
	} else {
		//OTHER PAGE ========================================
		msg="You are on the Some Other Page";
	}

	if (window.console && console.log) {
		console.log(querystring);
		console.log(msg);
		console.log("%o", QBU)
	}
})(window);