Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestMixin", {
	mixinConfig: {
        id: "testmixin"
	},
	
	constructor: function(cls) {
		if (window.console && console.log)
			console.log("TestMixin.constructor(%o)", arguments);

		var me = this;

		me.callParent([cls]);

		cls.addEvents({
			"testEvent1": true,
			"testEvent2": true,
			"testEvent3": true
		});

		cls.on("testEvent1", me.onTestEvent1, me);
		cls.on({
			testEvent2: me.onTestEvent2,
			scope: me
		});
		cls.on({
			testEvent3: me.onTestEvent3,
			single: true,
			scope: me
		});

		return this;
	},

	onClassMixedIn: function (cls) {
        if (window.console && console.log)
            console.log("TestMixin.onClassMixedIn(%o)", arguments);
	},

	onTestEvent1: function () {
		if(window.console && console.log)
			console.log("TestMixin.onTestEvent1(%o)", arguments);
	},

	onTestEvent2: function () {
		if(window.console && console.log)
			console.log("TestMixin.onTestEvent2(%o)", arguments);
	},

	onTestEvent3: function () {
		if(window.console && console.log)
			console.log("TestMixin.onTestEvent3(%o)", arguments);
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

		me.mixins.testMixin.constructor.call(me, me);

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
			tbar: [{
				xtype: "button",
				text: "testEvent1",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent1");
				}
			}, {
				xtype: "button",
				text: "testEvent2",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent2");
				}
			}, {
				xtype: "button",
				text: "testEvent3",
				handler: function (btn) {
					var panel;

					if (!(panel = btn.up("panel")))
						return;

					panel.fireEvent("testEvent3");
				}
			}],
			renderTo: Ext.getBody(),
			listeners: {
				render: function(panel, eOpts) {
					if(window.console && console.log)
						console.log("CustomPanel.render(%o)", arguments);
				}
			}
		});
});
