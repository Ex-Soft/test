Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.data.AbstractStore.prototype.destroyStore = Ext.Function.createSequence(Ext.data.AbstractStore.prototype.destroyStore, function() {
		if(window.console && console.log)
			console.log("Ext.data.AbstractStore.prototype.destroyStore(%o)", arguments);
	});

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "create",
			handler: function(btn, e) {
				store = new Ext.data.Store({
					fields: [
						{ name: "id", type: "int" },
						"name"
					],
					data: [
						{ id: 1, name: "Record# 1" },
						{ id: 2, name: "Record# 2" },
						{ id: 3, name: "Record# 3" },
						{ id: 4, name: "Record# 4" },
						{ id: 5, name: "Record# 5" }
					]
				})
			}
		}, {
			text: "watch",
			handler: function(btn, e) {
				if(window.console && console.log)
				{
					if(Ext.isDefined(window.store))
						console.log("%o", store);
					else
						console.log("%s", typeof window.store);
				}
			}
		}, {
			text: "destroy",
			handler: function(btn, e) {
				if(Ext.isDefined(store))
					store = null;
			}
		}],
		renderTo: Ext.getBody()
	});
});