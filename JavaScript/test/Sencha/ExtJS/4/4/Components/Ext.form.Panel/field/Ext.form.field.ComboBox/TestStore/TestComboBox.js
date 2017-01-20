Ext.define("TestComboBox", {
	extend: "Ext.form.field.ComboBox",
	alias: "widget.testcombobox",

	initComponent: function() {
		this.valueField = this.displayField = "name";

		this.store = Ext.create("Ext.data.ArrayStore", {
			autoDestroy: true,
			fields: [
				{ name: this.valueField, type: "string" }
			]
		});

		Ext.apply(this, {
			queryMode: "local",
			editable: false,
			width: 150
		});

		this.callParent(arguments);

		if(this.loadOnRender)
			this.addListener("render", this.load, this);

		this.addListener("afterrender", this.onAfterRender, this);
	},

	load: function(combo, eOpts) {
		if(window.console && console.log)
			console.log("TestComboBox.load() started getCount()=%i", this.getStore().getCount());

		this.getStore().loadData(this.data);

		if(window.console && console.log)
			console.log("TestComboBox.load() finished getCount()=%i", this.getStore().getCount());
	},

	/*
	afterRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestComboBox.afterRender(%o)", arguments);

		this.callParent(arguments);
	}
	*/

	onAfterRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestComboBox.onAfterRender(%o)", arguments);
	}
});
