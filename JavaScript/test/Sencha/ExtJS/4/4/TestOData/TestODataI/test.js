Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("Route", {
	extend: "Ext.data.Model",
	idProperty: "Id",
	fields: [
		{ name: "Id", type: "int" },
		{ name: "Name", type: "string" },
		{ name: "Deleted", type: "boolean" },
		{ name: "Verstamp", type: "string" },
		{ name: "Code", type: "string" },
		{ name: "IsOffice", type: "boolean" },
		{ name: "IdStore", type: "int" },
		{ name: "IdLandStore", type: "int" }
	]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.Ajax.on("requestexception", function(connection, response, options, eOpts) {
		var
			headers = response.getAllResponseHeaders();

		if(response.status==401)
		{
			alert(response.status);
			return;
		}
	});

	var
		store = Ext.create("Ext.data.Store", {
			model: "Route",
			autoload: false,
			autosync: false,
			proxy: {
				type: "odata",
				url: "https://localhost/ChicagoServer/Resources.svc/Routes",
				headers: {
					Accept: "application/json;odata=verbose",
					Authorization: "Basic QWRtaW5pc3RyYXRvcjoxMjM="
				},
				params: {
					username: "Administrator",
					password: "123",
				},
				listeners: {
					exception: function (proxy, response, operation, eOpts) {
						if(window.console && console.log)
							console.log("proxy.exception(%o)", arguments);
					}
				}
			}
		});

	store.load();
});