Ext.define("CLabel", {
	extend: "Ext.form.Label",
	alias: "widget.clabel",

	initComponent: function() {
		if(window.console && console.log)
			console.log("CLabel.initComponent(%o)", arguments);

		this.callParent(arguments);
	}
});