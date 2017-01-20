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
				xtype: "carousel",
				items: [
					{ style: "background-color: #D55B5B;" },
					{ style: "background-color: #B22222;" },
					{ style: "background-color: #7C0505;" }
				]
			},
			amber = {
				xtype: "carousel",
				items: [
					{ style: "background-color: #FFDD00;" },
					{ style: "background-color: #FFBF00;" },
					{ style: "background-color: #FF8F00;" }
				]
			},
			green = {
				xtype: "carousel",
				items: [
					{ style: "background-color: #7BB300;" },
					{ style: "background-color: #3B7E00;" },
					{ style: "background-color: #0E3E00;" }
				]
			};
		
		Sencha.container = Ext.create("Ext.Container", {
			fullscreen: true,
			layout: "vbox",
			defaults: { flex: 1},
			items: [red, amber, green]
		});
	}
});