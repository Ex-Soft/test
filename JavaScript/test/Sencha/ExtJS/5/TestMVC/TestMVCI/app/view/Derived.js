Ext.define("TestMVCI.view.Derived", {
	extend: "TestMVCI.view.Base",
	xtype: "derivedview",

	requires: [
		"Ext.form.field.Date",
		"TestMVCI.view.DerivedController"
	],
	
	controller: "derivedcontroller",
	
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