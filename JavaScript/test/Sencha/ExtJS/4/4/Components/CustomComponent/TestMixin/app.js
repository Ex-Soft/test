Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestMixin", {
	mixinConfig: {
        id: "testmixin"
	},
	
	constructor: function(config) {
		if (window.console && console.log)
			console.log("TestMixin.constructor(%o)", arguments);

		this.callParent([config]);

		return this;
	},

	onClassMixedIn: function (cls) {
        if (window.console && console.log)
            console.log("TestMixin.onClassMixedIn(%o)", arguments);
    }
});

Ext.define("CustomPanel", {
	extend: "Ext.panel.Panel",
	alias : "widget.custompanel",

	mixins: {
		testMixin: "TestMixin"
	},

	constructor: function(config) {
		if(window.console && console.log)
			console.log("CustomPanel.constructor(%o)", arguments);

		var me = this;

		me.callParent([config]);
		me.mixins.testMixin.constructor.call(me);

		return me;
	},

	initComponent: function() {
		if(window.console && console.log)
			console.log("CustomPanel.initComponent(%o)", arguments);

		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	//if(window.console && console.clear)
	//	console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		p = Ext.create("CustomPanel", {
			border: 50,
			renderTo: Ext.getBody(),
			listeners: {
				render: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.render(%o)", arguments);
				}
			}
		});
});
