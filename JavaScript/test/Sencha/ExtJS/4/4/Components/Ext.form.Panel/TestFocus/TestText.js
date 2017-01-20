Ext.define("TestText", {
	extend: "Ext.form.field.Text",
	alias: "widget.testtext",

	initComponent: function() {
		this.callParent(arguments);
	},

	render: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestText.render(%o)", arguments);

		this.callParent(arguments);

		//component.focus(true);
	},

	onRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestText.onRender(%o)", arguments);

		this.callParent(arguments);

		//component.focus(true);
	},

	afterRender: function(component, eOpts) {
		if(window.console && console.log)
			console.log("TestText.afterRender(%o)", arguments);

		this.callParent(arguments);

		//component.focus(true);
	}
});