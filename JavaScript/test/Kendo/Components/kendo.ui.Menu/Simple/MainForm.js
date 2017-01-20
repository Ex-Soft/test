$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		kMenu = $("#menu").kendoMenu({
			activate: function() {
				if(window.console && console.log)
					console.log("kendoMenu.activate(%o)", arguments);
			},
			deactivate: function() {
				if(window.console && console.log)
					console.log("kendoMenu.deactivate(%o)", arguments);
			},
			open: function() {
				if(window.console && console.log)
					console.log("kendoMenu.open(%o)", arguments);
			},
			close: function() {
				if(window.console && console.log)
					console.log("kendoMenu.close(%o)", arguments);
			},
			select: function(e) {
				if(window.console && console.log)
					console.log("kendoMenu.select(%o)", arguments);
			}
		});
});
