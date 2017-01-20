Ext.define("AM.view.Derived", {
	extend: "AM.view.Base",
	alias: "widget.derivedview",

	strong: "Derived",
	
	initComponent: function() {
		if(window.console && console.log)
			console.log("view.Derived.initComponent(%o)", arguments);

		this.items = [{
			xtype: "datefield",
			name : "date",
			fieldLabel: "Date"
		}];

		this.callParent(arguments);
	}
});