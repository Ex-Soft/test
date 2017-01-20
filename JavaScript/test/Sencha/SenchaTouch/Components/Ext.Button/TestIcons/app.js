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
					{ text: "calendar", iconCls: "calendar" },
					{ text: "action", iconCls: "action" },
					{ text: "add", iconCls: "add" },
					{ text: "arrow_down", iconCls: "arrow_down" },
					{ text: "arrow_left", iconCls: "arrow_left" },
					{ text: "arrow_right", iconCls: "arrow_right" },
					{ text: "arrow_up", iconCls: "arrow_up" },
					{ text: "compose", iconCls: "compose" },
					{ text: "delete", iconCls: "delete" },
					{ text: "organize", iconCls: "organize" },
					{ text: "refresh", iconCls: "refresh" },
					{ text: "reply", iconCls: "reply" },
					{ text: "search", iconCls: "search" },
					{ text: "settings", iconCls: "settings" }
				]
			}, {
				xtype: "container",
				flex: 1,
				defaults: {
					xtype: "button"
				},
				items: [
					{ text: "star", iconCls: "star" },
					{ text: "trash", iconCls: "trash" },
					{ text: "maps", iconCls: "maps" },
					{ text: "locate", iconCls: "locate" },
					{ text: "home", iconCls: "home" },
					{ text: "bookmarks", iconCls: "bookmarks" },
					{ text: "download", iconCls: "download" },
					{ text: "favorites", iconCls: "favorites" },
					{ text: "info", iconCls: "info" },
					{ text: "more", iconCls: "more" },
					{ text: "time", iconCls: "time" },
					{ text: "user", iconCls: "user" },
					{ text: "team", iconCls: "team" },
					{ text: "list", iconCls: "list" }
				]
			}]
		}));
	}
});