Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestPanel", {
	extend: "Ext.panel.Panel",

	initComponent: function() {
		Ext.override(TestPanel, {
			foo1: function() {
				if(window.console && console.log)
					console.log("foo1(%o) (b4 original)", arguments);

				this.callOverridden(arguments);

				if(window.console && console.log)
					console.log("foo1(%o) (after original)", arguments);
			}
		});

		TestPanel.override({
			foo2: function() {
				if(window.console && console.log)
					console.log("foo2(%o) (b4 original)", arguments);

				this.callOverridden(arguments);

				if(window.console && console.log)
					console.log("foo2(%o) (after original)", arguments);
			}
		});

		this.callParent(arguments);
	},

	foo1: function() {
		if(window.console && console.log)
			console.log("foo1(%o) (original)", arguments);
	},

	foo2: function() {
		if(window.console && console.log)
			console.log("foo2(%o) (original)", arguments);
	}
});

Ext.define("DerivedTestPanel", {
	extend: "TestPanel",

	initComponent: function() {
		this.callParent(arguments);
	}
});

Ext.onReady(function() {
	var
		p = Ext.create("TestPanel", {
			renderTo: Ext.getBody()
		}),
		dp = Ext.create("DerivedTestPanel", {
			renderTo: Ext.getBody()
		});

	p.foo1(100);
	p.foo2(100);
	dp.foo1(1000);
	dp.foo2(1000);
});
