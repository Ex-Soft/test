Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestModel", {
	extend: "Ext.data.Model",
	idProperty: "id",
	fields: [
		{ name: "id", type: "int" },
		{ name: "name", type: "string" }
	]
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		maxRecordsCount = 5,
		createData = function(max) {
			var
				data = [];

			for(var i=0; i<max; ++i)
				data.push( [ i, "Record# "+i ] );

			return data;

		},
		store = Ext.create("Ext.data.ArrayStore", {
			model: "TestModel",
			listeners: {
				datachanged: function(store, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.datachanged(%o)", arguments);
				},
				load: function(store, records, successful, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.load(%o)", arguments);
				},
				refresh: function(store, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.Store.refersh(%o)", arguments);
				}
			}
		}),
		combo;

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "isDirty()",
			handler: function(btn, e) {
				if(window.console && console.log)
					console.log("isDirty() = %s", combo.isDirty());
			}
		}, {
			text: "getValue()",
			handler: function(btn, e) {
				if(window.console && console.log)
					console.log("getValue() = %s", combo.getValue());
			}
		}],
		renderTo: Ext.getBody()
	});

	combo = Ext.create("Ext.form.field.ComboBox", {
		store: store,
		valueField: "id",
		displayField: "name",
		queryMode: "local",
		editable: true,
		minChars: 0,
		width: 300,
		listeners: {
			afterrender: function(combo, eOpts) {
				var
					o = {};

				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.afterrender(%o)", arguments);

				combo.value = combo.lastValue = combo.originalValue = 2;
				combo.setRawValue("Record# 2");
				o[combo.valueField] = 2;
				o[combo.displayField] = "Record# 2";
				combo.displayTplData = [ o ];

				Ext.Function.defer(function() {
					combo.getStore().loadData(createData(maxRecordsCount));
				}, 3000);
			},
			boxready: function(combo, width, height, eOpts) {
				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.boxready(%o)", arguments);
			},
			change: function(combo, newValue, oldValue, eOpts) {
				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.change(%o)", arguments);
			},
			dirtychange: function(combo, isDirty, eOpts) {
				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.dirtychange(%o)", arguments);
			},
			select: function(combo, records, eOpts) {
				if(window.console && console.log)
					console.log("Ext.form.field.ComboBox.select(%o)", arguments);
			}
		},
		renderTo: Ext.getBody()
	});
});