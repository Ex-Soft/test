Ext.define("TestRouting.store.NavStore", {
	extend: "Ext.data.TreeStore",
	alias: "store.navstore",

	model: "TestRouting.model.NavModel",

	autoLoad: true,
	
	root: {
		id: 0,
		text: "RootRoot",
		expanded: true
	},

	listeners: {
		load: function() {
			if (window.console && console.log)
				console.log("load(%o)", arguments);
		}
	}
});