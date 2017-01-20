﻿Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.application({
	name: "Sencha",
	requires: ["Ext.carousel.Carousel"],
	
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		var
			red = {
				style: "background-color: #B22222; color: white;",
				title: "Red",
				html: "Red"
			},
			amber = {
				style: "background-color: #FFBF00; color: white;",
				title: "Amber",
				html: "Amber"
			},
			green = {
				style: "background-color: #3B7E00; color: white;",
				title: "Green",
				html: "Green"
			};
		
		Sencha.container = Ext.create("Ext.carousel.Carousel", {
			fullscreen: true,
			direction: "vertical",
			items: [red, amber, green]
		});
	}
});