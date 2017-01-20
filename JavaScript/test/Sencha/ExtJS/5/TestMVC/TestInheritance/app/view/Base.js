Ext.define("TestInheritance.view.Base", {
	extend: "Ext.form.Panel",
	xtype: "baseview",

	requires: [ "TestInheritance.view.BaseController" ],
	
	buttons: [{
		text: "Save",
		handler: "onSaveClick",
		reference: "btnSave"
	}, {
		text: "Cancel",
		handler: "onCancelClick"
	}],

	controller: "basecontroller",
	
	initComponent: function() {
		if(window.console && console.log)
			console.log("view.Base.initComponent(%o)", arguments);

		Ext.applyIf(this, {
			items: [{
				xtype: "textfield",
				name : "name",
				fieldLabel: "Name"
			}, {
				xtype: "textfield",
				name : "email",
				fieldLabel: "Email"
			}]
		});

		this.callParent(arguments);
	}
});