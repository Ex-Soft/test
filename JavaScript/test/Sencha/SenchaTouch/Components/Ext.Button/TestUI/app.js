Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	launch: function() {
		if (window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.Container", {
			fullscreen: true,
			layout: "hbox",
			items: [{
				xtype: "container",
				flex: 1,
				defaults: {
					xtype: "button"
				},
				items: [
					{ text: "normal", ui: "normal" },
					{ text: "back", ui: "back" },
					{ text: "forward", ui: "forward" },
					{ text: "round", ui: "round" },
					{ text: "action", ui: "action" },
					{ text: "decline", ui: "decline" },
					{ text: "confirm", ui: "confirm" }
				]
			}, {
				xtype: "container",
				flex: 1,
				defaults: {
					xtype: "button"
				},
				items: [
					{ text: "action-round", ui: "action-round" },
					{ text: "decline-round", ui: "decline-round" },
					{ text: "confirm-round", ui: "confirm-round" }
				]
			}]
		}));
	}
});