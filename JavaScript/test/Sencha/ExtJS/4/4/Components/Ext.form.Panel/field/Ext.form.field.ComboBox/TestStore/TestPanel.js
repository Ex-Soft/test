Ext.define("TestPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel",

	requires: ["TestComboBox"],

	initComponent: function() {
		Ext.apply(this, {
			items: [{
				xtype: "testcombobox",
				data: [
					{ name: "#1" },
					{ name: "#2" },
					{ name: "#3" }
				],
				loadOnRender: true
			}]
		});

		this.callParent(arguments);

		//this.addListener("render", this.onPanelRender, this);
		this.addListener("afterrender", this.onPanelAfterRender, this);
	},

	/*onRender: function() {
		if(window.console && console.log)
			console.log("TestPanel.onRender()");

		this.callParent(arguments);
		//this.callOverridden(arguments); // method.$previous is undefined
	},*/

	/*onPanelRender: function() {
		if(window.console && console.log)
			console.log("TestPanel.onPanelRender()");
	},*/
	
	/*afterRender: function() {
		if(window.console && console.log)
			console.log("TestPanel.afterRender()");

		this.callParent(arguments);
		//this.callOverridden(arguments); // method.$previous is undefined
	},*/

	onPanelAfterRender: function() {
		if(window.console && console.log)
			console.log("TestPanel.onPanelAfterRender()");

		var
			cb = this.down("testcombobox");

		cb.setValue("#2");
	}
});
