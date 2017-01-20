Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "Sencha",
	
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		var
			red = {
				style: "background-color: #B22222; color: white;",
				title: "Red",
				html: "Red"
				//, flex: 1
			},
			amber = {
				style: "background-color: #FFBF00; color: white;",
				title: "Amber",
				html: "Amber"
				//, flex: 1
			},
			green = {
				style: "background-color: #3B7E00; color: white;",
				title: "Green",
				html: "Green"
				//, flex: 1
			};
		
		Sencha.container = Ext.create("Ext.Container", {
			fullscreen: true,
			layout: {
				type: "hbox",
				//pack: "start"
				pack: "center"
			},
			defaults: { flex: 1},
			items: [red, amber, green]
		});
	}
});