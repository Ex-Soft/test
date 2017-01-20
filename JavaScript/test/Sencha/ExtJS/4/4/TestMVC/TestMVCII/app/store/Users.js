Ext.define("AM.store.Users", {
	extend: "Ext.data.Store",
	model: "AM.model.User",
	autoLoad: true,
	proxy: {
		type: "ajax",
		api: {
			read: "data/users.json",
			update: "data/updateUsers.json"
		},
		reader: {
			type: "json",
			root: "users",
			totalProperty: "total",
			successProperty: "success",
			messageProperty: "message"
		},
		listeners: {
			exception: function (proxy, response, operation, eOpts) {
				if (window.console && console.log)
					console.log("Proxy.Exception");
			}
		}
	},
	listeners: {
		load: function (store, records, successful, operation) {
			if (window.console && console.log)
				console.log("Store.Load: successful=%s (Users)", successful);
		},
		update: function (store, record, operation, eOpts) {
			if (window.console && console.log)
				console.log("Store.Update");
		}
	}
});
