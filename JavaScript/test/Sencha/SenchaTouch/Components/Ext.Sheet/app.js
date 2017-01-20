Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.create("Ext.Panel", {
			fullscreen: true,
			layout: "card",
			items: [{
				xtype: "toolbar",
				docked: "top",
				items: [{
					text: "Create Sheet",
					handler: function(btn) {
						var
							panel,
							sheet;

						if(!(panel = btn.up("panel"))
							|| (sheet = panel.getItems().findBy(function(item, key) { return item.xtype === "sheet"; })))
							return;

						sheet = Ext.create("Ext.Sheet", {
							xtype: "sheet",
							enter: "top",
							exit: "top",
							layout: "fit",
							stretchX: true,
							stretchY: true,
							hidden: true,
							hideOnMaskTap: true,
							items: [{
								style: "background-color: #3B7E00; color: white;",
								title: "Green",
								html: "Green"
							}]
						});

						panel.add(sheet);
					}
				}, {
					text: "Show Sheet",
					handler: function(btn) {
						var
							panel,
							sheet;

						if(!(panel = btn.up("panel")))
							return;

						if((sheet = panel.getItems().findBy(function(item, key) { return item.xtype === "sheet"; }))
							&& sheet.getHidden())
							sheet.show();
					}
				}, {
					text: "Hide Sheet",
					handler: function(btn) {
						var
							panel,
							sheet;

						if(!(panel = btn.up("panel")))
							return;

						if((sheet = panel.getItems().findBy(function(item, key) { return item.xtype === "sheet"; }))
							&& !sheet.getHidden())
							sheet.hide();
					}
				}]
			}, {
				style: "background-color: #B22222; color: white;",
				title: "Red",
				html: "Red"
			}]
		});
	}
});