// https://www.ibm.com/developerworks/library/x-xpathjquery/

$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log("jQuery: %s", $.fn.jquery);

	$.ajax({
		url: "API_GetRecordInfo.xml",
		dataType: "xml",
		type: "GET",
		success: function(data, textStatus, jqXHR) {
			if (window.console && console.log)
				console.log("success: %o", arguments);

			var
				fieldName = "FText",
				field = $("field name:contains(\"" + fieldName + "\")", data).parent(),
				fieldId = parseInt($("fid", field).text(), 10),
				fieldType = $("type", field).text(),
				fieldValue = $("value", field).text();

			if (window.console && console.log)
				console.log("{fid: %i, name: \"%s\", type: \"%s\", value: \"%s\"}", fieldId, fieldName, fieldType, fieldValue);
		},
		error: function(jqXHR, textStatus, errorThrown) {
			if (window.console && console.log)
				console.log("error: %o", arguments);
		}
	});
});
