Ext.define("AM.view.Base", {
	extend: "Ext.form.Panel",
	alias: "widget.baseview",

	buttons: [{
		text: "Save",
		action: "save"
	}, {
		text: "Cancel",
		action: "cancel"
	}],

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