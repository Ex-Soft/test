Ext.onReady(function() {
	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			fields: ["id", "title"],
			autoLoad: true,
			proxy: {
				type: "ajax",
				url: "data.json",
				reader: {
					type: "json"
				}
			},
			listeners: {
				load: function (store, records, successful, operation, eOpts) {
					if (window.console && console.log)
						console.log("Ext.data.Store.load(%o)", arguments);
				}
			}
		}),
		comboBox = Ext.create("Ext.form.ComboBox", {
			fieldLabel: "Select",
			store: store,
			queryMode: "local",
			displayField: "title",
			valueField: "id",
			typeAhead: true,
			anyMatch: true,
			renderTo: Ext.getBody()
		});

	comboBox.setXY([50, 50]);
});
