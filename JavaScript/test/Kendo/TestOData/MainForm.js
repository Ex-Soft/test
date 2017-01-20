$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var 
		username = "Administrator",
		password = "123";

	$.ajaxSetup({
		username: username,
		password: password,
		statusCode: {
			401: function() {
				if (window.console && console.log)
					console.log("statusCode 401: %o", arguments);
			}
		},
		error: function(jqXHR, textStatus, errorThrown) {
			if (window.console && window.console.log)
				console.log("error: xhr.status=%i xhr.statusText=\"%s\" textStatus=\"%s\" errorThrown=\"%s\"", jqXHR.status, jqXHR.statusText, textStatus, errorThrown);
		},
		beforeSend: function (jqXHR, settings) {
			jqXHR.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
			jqXHR.withCredentials = true;
		}
	});

	var
		Route = kendo.data.Model.define({
			id: "Id",
			fields: {
				"Id": {
					type: "number",
					editable: false
				},
				"Name": {
					type: "string",
					editable: true
				},
				"Deleted": {
					type: "boolean",
					editable: true
				},
				"Verstamp": {
					type: "string",
					editable: true
				},
				"Code": {
					type: "string",
					editable: true
				},
				"IsOffice": {
					type: "boolean",
					editable: true
				},
				"IdStore": {
					type: "number",
					editable: true
				},
				"IdLandStore": {
					type: "number",
					editable: true
				}
			}
		}),
		dataSource = new kendo.data.DataSource({
			type: "odata",
			transport: {
				read: {
					/*beforeSend: function (req) {
						req.setRequestHeader("Accept", "application/json;odata=verbose");
					},*/
					url: "https://v-gamula/ChicagoServer/Resources.svc/Routes"
					//url: "https://localhost/ChicagoServer/Resources.svc/Routes"
					/*, contentType: "application/json;odata=verbose"
					, headers: { "accept": "application/json;odata=verbose" }
					, dataType: "jsonp"
					, accept: "application/json;odata=verbose"
					, username: "Administrator"
					, password: "123"*/
				}
				/*
				read: function(options) {
					$.ajax({
						url: "https://v-gamula/ChicagoServer/Resources.svc/Routes",
						dataType: "jsonp",
						jsonpCallback: function() {
							if (window.console && console.log)
								console.log("jsonpCallback: %o", arguments);
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
				}
				*/
			},
			pageSize: 10,
			serverPaging: true,
			serverSorting: true,
			serverFiltering: true,
			schema: {
				model: Route/*,
				data: "value",
				total: "odata.count"*/
			}
		});

	$("#grid").kendoGrid({
		dataSource: dataSource,
		pageable: {
			refresh: true,
			pageSizes: true,
			buttonCount: 5
		},
		sortable: true,
		filterable: true,
		columnMenu: true,
		columns: [
			{ field: "Id", title: "Id", type: "number", width: 140 },
			{ field: "Name", title: "Name", type: "string", width: 190 },
			{ field: "Deleted", title: "Deleted", type: "boolean", width: 190 },
			{ field: "Verstamp", title: "Verstamp", type: "string", width: 190 }
		]
	});
});
