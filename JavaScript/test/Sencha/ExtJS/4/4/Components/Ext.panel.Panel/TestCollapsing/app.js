Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create('Ext.panel.Panel', {
		width: 800,
		height: 400,
		title: 'Border Layout',
		layout: 'border',
		items: [{
			region: "north",
			xtype: "toolbar",
			items: [{
				text: "Collapse",
				handler: function(btn) {
					var panel,
						layout,
						layoutItems,
						eastRegion;

					if (!(panel = btn.up("panel"))
						|| !(layout = panel.getLayout())
						|| Ext.isEmpty(layoutItems = layout.getLayoutItems())
						|| !(eastRegion = layoutItems.find(item => item.id == "east-region-container")))
						return;

					if (!eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.collapse();
					}
					if (!eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.collapse();
					}
					if (!eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.collapse();
					}
				}
			}, {
				text: "Expand",
				handler: function(btn) {
					var panel,
						layout,
						layoutItems,
						eastRegion;

					if (!(panel = btn.up("panel"))
						|| !(layout = panel.getLayout())
						|| Ext.isEmpty(layoutItems = layout.getLayoutItems())
						|| !(eastRegion = layoutItems.find(item => item.id == "east-region-container")))
						return;

					if (eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.expand();
					}
					if (eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.expand();
					}
					if (eastRegion.collapsed) {
						if (window.console && console.log)
							console.log("collapsed = %o", eastRegion.collapsed);
						eastRegion.expand();
					}
				}
			}]
		},{
			title: 'South Region is resizable',
			region: 'south',     // position for region
			xtype: 'panel',
			height: 100,
			split: true,         // enable resizing
			margins: '0 5 5 5'
		},{
			// xtype: 'panel' implied by default
			title: 'West Region is collapsible',
			region:'west',
			xtype: 'panel',
			margins: '5 0 0 5',
			width: 200,
			collapsible: true,   // make collapsible
			split: true,
			id: 'west-region-container',
			layout: 'fit'
		},{
			title: 'Center Region',
			region: 'center',     // center region is required, no width/height specified
			xtype: 'panel',
			layout: 'fit',
			margins: '5 0 0 0'
		},{
			region: "east",
			xtype: "panel",
			id: "east-region-container",
			title: "East Region",
			width: 200,
			collapsible: true,
			collapsed: true,
			split: true,
			margins: "5 5 0 0"
		}],
		listeners: {
			afterrender: function(panel) {
				if (window.console && console.log)
					console.log("afterrender(%o)", arguments);

				var layout,
					layoutItems,
					eastRegion;

				if (!(layout = panel.getLayout())
					|| Ext.isEmpty(layoutItems = layout.getLayoutItems())
					|| !(eastRegion = layoutItems.find(item => item.id == "east-region-container")))
					return;

				eastRegion.expand();
			}
		},
		renderTo: Ext.getBody()
	});
});
