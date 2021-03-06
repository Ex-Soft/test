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

