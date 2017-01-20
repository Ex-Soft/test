Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		windowBar = Ext.create("Ext.toolbar.Toolbar", {
			flex: 1,
			items: [ "&#160;" ],
			layout: {
				overflowHandler: "Scroller"
			},
			border: 0 //"0 0 0 0" //false
		}),
		taskBar = Ext.create("Ext.toolbar.Toolbar", {
			//region: "south",
			//height: 45,
			border: 0, //"0 0 0 0", //false,
			items: [{
				text: "add",
				handler: function(btn, e) {
					if(typeof windowBar.buttonNo==="undefined")
						windowBar.buttonNo=0;

					windowBar.add(Ext.create("Ext.button.Button", { text: "button# "+windowBar.buttonNo++ }));
				}
			}, {
				xtype: "splitter",
				html: "&#160;",
				height: 14,
				width: 2,
				cls: "x-toolbar-separator x-toolbar-separator-horizontal"
			},
				windowBar
			],
			renderTo: Ext.getBody()
		});
/*
	Ext.create("Ext.container.Viewport", {
		layout: "border",
		border: false,
		items: [{
			region: "center",
			html: "center"
		},
			taskBar
		]
	}); */
});
