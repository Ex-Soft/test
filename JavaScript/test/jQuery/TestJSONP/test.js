$(document).ready(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("jquery: %s", $.fn.jquery);

	$.ajax({
		url: "http://www.sencha.com/forum/topics-browse-remote.php",
		//url: "http://www.sencha.com/forum/remote_topics/index.php"
		//url: "http://www.sencha.com/forum/topics-remote.php"
		//url: "https://www.googleapis.com/books/v1/volumes"
		//url: "http://api.worldbank.org/countries?format=jsonp"
		crossDomain: true,
		dataType: "jsonp",
		data: {
			start: 0,
			limit: 1,
			page: 1,
			sort: "lastpost",
			dir: "DESC"
		},
		xhrFields: {
			withCredentials: true
		},
		complete: function(jqXHR, textStatus) {
			if(window.console && console.log)
				console.log("complete(%o)", arguments);
		},
		error: function(jqXHR, textStatus, errorThrown) {
			if(window.console && console.log)
				console.log("error(%o)", arguments);
		},
		success: function(data, textStatus, jqXHR) {
			if(window.console && console.log)
				console.log("success(%o)", arguments);
		}
		
		//, jsonp: "onJSONPLoad"
		
		//, jsonpCallback: "jsonpCB"
		
		//, jsonp: false
		, jsonpCallback: function(data) {
			if(window.console && console.log)
				console.log("jsonpCallback(%o)", arguments);

			return "_jsonpCB_";
		}
		
	});
});

function jsonpCB(data) {
	if(window.console && console.log)
		console.log("jsonpCB(%o)", arguments);
}