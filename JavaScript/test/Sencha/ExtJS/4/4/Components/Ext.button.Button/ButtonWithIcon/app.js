Ext.onReady(function() {
	var
		b = Ext.create("Ext.button.Button", {
			renderTo: Ext.getBody(),
			text: "Ext.button.Button",
			iconCls: "iconTest",
			iconAlign: "top"
		}),
		s = Ext.create("Ext.button.Split", {
			renderTo: Ext.getBody(),
			text: "Ext.button.Split",
			handler: function(button, e) {
				if (window.console && console.log)
				{
					console.log("Ext.button.Split.handler(%o)", arguments);
					console.log("button.isXType(\"button\") = \"%s\"", button.isXType("button"));
					console.log("button.isXType(\"splitbutton\") = \"%s\"", button.isXType("splitbutton"));

					button.menu.items.items.forEach(function(item) {
						console.log("\"%s\" xtype:\"%s\"", item.text, item.xtype);
					});
				}
			},
			menu: new Ext.menu.Menu({
				items: [{
					text: "Item# 1",
					handler: function(button, e) {
						if (window.console && console.log)
							console.log("Ext.button.Split.menu.item.handler(%o) button.isXType(\"menuitem\") = \"%s\"", arguments, button.isXType("menuitem"));

						button.setDisabled(true);
					}
				}, {
					text: "Item# 2",
					disabled: true,
					handler: function(button, e) {
						if (window.console && console.log)
							console.log("Ext.button.Split.menu.item.handler(%o)", arguments);
					}
				}]
			})
		});
});
