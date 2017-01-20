Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	customPropertyII: { prop: "customPropertyII" },

	constructor: function(config) {
		//this.initConfig(config);

		this.callParent([config]);

		return this;
	},

	initComponent: function() {
		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	var
		p = Ext.create("CustomPanel", {
			title: "CustomPanel",
			border: 50,
			customPropertyI: { prop: "customPropertyI" },
			items: [{
				xtype: "button",
				text: "DoIt!",
				handler: function(btn, e) {
					if(window.console && console.log)
					{
						console.log("typeof this.ownerCt.customPropertyI = \"%s\"", typeof this.ownerCt.customPropertyI);
						console.log("typeof this.ownerCt.getcustomPropertyI = \"%s\"", typeof this.ownerCt.getcustomPropertyI);
						console.log("typeof this.ownerCt.applycustomPropertyI = \"%s\"", typeof this.ownerCt.applycustomPropertyI);
						console.log("typeof this.ownerCt.setcustomPropertyI = \"%s\"", typeof this.ownerCt.setcustomPropertyI);

						console.log("typeof this.ownerCt.customPropertyII = \"%s\"", typeof this.ownerCt.customPropertyII);
						console.log("typeof this.ownerCt.getcustomPropertyII = \"%s\"", typeof this.ownerCt.getcustomPropertyII);
						console.log("typeof this.ownerCt.applycustomPropertyII = \"%s\"", typeof this.ownerCt.applycustomPropertyII);
						console.log("typeof this.ownerCt.setcustomPropertyII = \"%s\"", typeof this.ownerCt.setcustomPropertyII);
					}
				}
			}],
			renderTo: Ext.getBody()
		});
});
