Ext.onReady(function() {
	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var options = [];

	for(var i = 1; i < 21; ++i)
		options.push({ id: i, title: i});

	var
		store = Ext.create("Ext.data.Store", {
			fields: ["id", "title"],
			data : options
		}),
		comboBox = Ext.create("Ext.form.ComboBox", {
			fieldLabel: "Select",
			store: store,
			queryMode: "local",
			displayField: "title",
			valueField: "id",
			renderTo: Ext.getBody()
		});

	comboBox.setXY([100, 300]);
});
