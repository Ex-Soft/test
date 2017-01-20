$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log("jQuery: %s", $.fn.jquery);

	var
		cb = function() {
			if (window.console && console.log)
				console.log("jsonpCallback: %o", arguments);
		};

	$.ajax({
		url: "https://v-gamula/ChicagoServer/Resources.svc/Routes",
		dataType: "jsonp",
		crossDomain: true,
		jsonpCallback: cb,
		//jsonp: "cb",
		username: "Administrator",
		password: "123",
		type: "GET",
		headers: {
			"Accept": "application/json;odata=verbose"
		},
		error: function(jqXHR, textStatus, errorThrown) {
			if (window.console && console.log)
				console.log("error: %o", arguments);
		},
		success: function(data, textStatus, jqXHR) {
			if (window.console && console.log)
				console.log("success: %o", arguments);
		}
	});
});
